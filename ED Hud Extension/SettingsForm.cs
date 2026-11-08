using static Globals;
using static ED_Hud_Extension.OAuth2;
using System.Diagnostics;

namespace ED_Hud_Extension
{
    public partial class SettingsForm : Form
    {
        private readonly UpdateService updateService = new UpdateService(new UpdateService.GitHubUpdateChecker());

        public SettingsForm()
        {
            InitializeComponent();

            //try to load the user's saved settings
            prefDisplayMenu.DataSource = GetMonitorList();
            prefDisplayMenu.SelectedIndex = savedPrefDisplayIndex;
            journalPathTextbox.Text = journalPath;
            gamePathTextbox.Text = gamePath;
            skipAnimationToggle.Checked = skipInitAnims;
            statReadToggle.Checked = statusEnabled;
            autoSwitchToggle.Checked = autoPanelSwitch;
            combatSwitchToggle.Checked = autoCombatSwitch;
            autoShutdownToggle.Checked = autoShutDownEnabled;

            if (capiConnected)
            {
                capiStatusTag.Text = "Connected";
                capiConnectButton.Enabled = false;
                capiDisconnectButton.Enabled = true;
            }
            else
            {
                capiStatusTag.Text = "Disconnected";
                capiConnectButton.Enabled = true;
                capiDisconnectButton.Enabled = false;
            }

        }

        private void pathBrowseButton_Click(object sender, EventArgs e) //gimme the god damn journal folder
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.InitialDirectory = defaultJournalPath;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    journalPathTextbox.Text = selectedPath;
                    journalPath = selectedPath;
                }
            }
        }

        private async void applyButton_Click(object sender, EventArgs e) //check for errors, then save the user's settings
        {
            //then verify the journal folder
            string pathToCheck = journalPath;
            if (pathToCheck is null) //make sure the input isn't fucking empty
            {
                MessageBox.Show("The selection is empty. Please select the journal folder or click close.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Directory.Exists(pathToCheck)) //make sure that the folder is the correct one by checking for guaranteed files like the ModulesInfo file
            {
                Screen targetScreen = Screen.AllScreens[prefDisplayMenu.SelectedIndex];

                chosenDisplay = prefDisplayMenu.SelectedIndex;
                formSize = targetScreen.WorkingArea.Size;
                skipInitAnims = skipAnimationToggle.Checked;
                statusEnabled = statReadToggle.Checked;
                gamePath = gamePathTextbox.Text;
                journalPath = journalPathTextbox.Text;
                autoPanelSwitch = autoSwitchToggle.Checked;
                autoCombatSwitch = combatSwitchToggle.Checked;
                autoShutDownEnabled = autoShutdownToggle.Checked;

                if (Functions.saveSettings()) //save the settings
                {
                    ProcessThreadCollection threadsList = Process.GetCurrentProcess().Threads;

                    foreach (ProcessThread thread in threadsList)
                    {
                        thread.Dispose();
                    }

                    Application.Restart();
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("The provided directory appears to be incorrect. Please verify the directory, or launch the game to generate journal files.", "Could not locate journal files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<string> GetMonitorList() //grab a list of every monitor connected to the system
        {
            List<string> monitorList = new List<string>();
            foreach (Screen screen in Screen.AllScreens)
            {
                //format of "DeviceName: Height / Width (Primary if applicable)"
                if (screen.Primary == true)
                {
                    monitorList.Add($"{screen.DeviceName}: {screen.WorkingArea.Width}, {screen.WorkingArea.Height} [Primary Display]");
                }
                else
                {
                    monitorList.Add($"{screen.DeviceName}: {screen.WorkingArea.Width}, {screen.WorkingArea.Height}");
                }
            }

            return monitorList;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show(
                this,
                "Are you sure?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Close();
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            DialogResult restart = MessageBox.Show("Are you sure you want to restart?", "Restart EDHE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (restart == DialogResult.Yes) { Application.Restart(); }
        }

        private async void checkUpdateButton_Click(object sender, EventArgs e)
        {
            checkUpdateButton.Enabled = false;
            try
            {
                await updateService.CheckForUpdatesAsync(silent: false);
            }
            finally
            {
                checkUpdateButton.Enabled = true;
            }
        }

        private async void capiConnectButton_Click(object sender, EventArgs e)
        {
            //do capi stuff
            OAuth2 oauth = await new OAuth2Request().AuthorizeAsync(OAuth2.cts.Token);
            oauth.Save();

            var capi = new CAPI(oauth).GetProfile();
            File.WriteAllText("C:\\EDHE\\res\\capi\\profile.json", capi.ToString());
            capiStatusTag.Text = "Connected";

            capiEnabled = true;
            capiDisconnectButton.Enabled = true;
            capiConnectButton.Enabled = false;

            //pull capi data
        }

        private void capiDisconnectButton_Click(object sender, EventArgs e)
        {
            DialogResult disconnect = MessageBox.Show("Are you sure you want to disconnect?", "Disconnect from Frontier cAPI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (disconnect == DialogResult.Yes) 
            {
                File.Delete(tokenPath);
                capiDisconnectButton.Enabled = false;
                capiEnabled = false;
                capiConnectButton.Enabled = true;
                capiStatusTag.Text = "Disconnected";
            }
        }
    }
}