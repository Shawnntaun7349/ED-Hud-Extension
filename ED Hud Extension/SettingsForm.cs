using System.Text.Json;
using System.Diagnostics;
using static Globals;
using static ED_Hud_Extension.OAuth2;
using static ED_Hud_Extension.MainForm;
using static ED_Hud_Extension.StatisticsHandler;

namespace ED_Hud_Extension
{
    public partial class SettingsForm : Form
    {
        private readonly UpdateService updateService = new UpdateService(new UpdateService.GitHubUpdateChecker());

        public event EventHandler SettingsUpdated;
        public event EventHandler StatsListUpdated;

        public SettingsForm()
        {
            InitializeComponent();

            //Functions.loadSettings();

            //try to load the user's saved settings
            prefDisplayMenu.DataSource = GetMonitorList();
            prefDisplayMenu.SelectedIndex = savedPrefDisplayIndex;
            currentDisplay = prefDisplayMenu.GetItemText(savedPrefDisplayIndex);
            journalPathTextbox.Text = journalPath;
            gamePathTextbox.Text = gamePath;
            skipAnimationToggle.Checked = skipInitAnims;
            statReadToggle.Checked = statusEnabled;
            autoSwitchToggle.Checked = autoPanelSwitch;
            combatSwitchToggle.Checked = autoCombatSwitch;
            autoShutdownToggle.Checked = autoShutDownEnabled;

            foreach (CheckBox box in currentSessionTab.Controls.OfType<CheckBox>())
            {
                string valueToCheck = box.Name.Substring(0, box.Name.Length - 8); //trim the 'CheckBox' suffix from the end of the string to align the
                box.Checked = currentSessionEnabled[valueToCheck];                //checkbox w/ the relevant dictionary key to represent the loaded settings
            }

            foreach (CheckBox box in careerStatisticsTab.Controls.OfType<CheckBox>())
            {
                string valueToCheck = box.Name.Substring(0, box.Name.Length - 8); //do the same for the career statis tab
                box.Checked = careerEnabled[valueToCheck];
            }

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

            if (currentPanel == "Home") { settingsTabControl.SelectedTab = genTab; }
            if (currentPanel == "Exploration") { settingsTabControl.SelectedTab = uiTab; pageTabControl.SelectedTab = explorationPageTab; }
            if (currentPanel == "Missions") { settingsTabControl.SelectedTab = uiTab; pageTabControl.SelectedTab = missionsPageTab; }
            if (currentPanel == "Stations") { settingsTabControl.SelectedTab = uiTab; pageTabControl.SelectedTab = stationsPageTab; }

            if (currentPanel == "Combat")
            {
                settingsTabControl.SelectedTab = uiTab;
                pageTabControl.SelectedTab = combatPageTab;
                if (currentCombatRecord == "Current Session") { combatStatisticsTabControl.SelectedTab = currentSessionTab; }
                else { combatStatisticsTabControl.SelectedTab = careerStatisticsTab; }
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

        public async void applyButton_Click(object sender, EventArgs e) //check for errors, then save the user's settings
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

                chosenDisplay = prefDisplayMenu.GetItemText(prefDisplayMenu.SelectedIndex);
                formSize = targetScreen.WorkingArea.Size;
                skipInitAnims = skipAnimationToggle.Checked;
                statusEnabled = statReadToggle.Checked;
                gamePath = gamePathTextbox.Text;
                journalPath = journalPathTextbox.Text;
                autoPanelSwitch = autoSwitchToggle.Checked;
                autoCombatSwitch = combatSwitchToggle.Checked;
                autoShutDownEnabled = autoShutdownToggle.Checked;


                foreach (CheckBox box in currentSessionTab.Controls.OfType<CheckBox>())
                {
                    string valueToCheck = box.Name.Substring(0, box.Name.Length - 8); //trim the 'CheckBox' suffix from the end of the string to align the
                    currentSessionEnabled[valueToCheck] = box.Checked;                //checkbox w/ the relevant dictionary to save the set values
                }

                foreach (CheckBox box in careerStatisticsTab.Controls.OfType<CheckBox>())
                {
                    string valueToCheck = box.Name.Substring(0, box.Name.Length - 8); //do the same for the career statis tab
                    careerEnabled[valueToCheck] = box.Checked;
                }

                if (chosenDisplay != currentDisplay) //if we need to change screens
                {
                    //do a bunch of shit to prep for a restart to avoid disrupting the user's session as much as possible
                    savePreviousSession = true;
                    saveSession();
                    Functions.saveSettings();
                    prepForShutdown();
                    ProcessThreadCollection threadsList = Process.GetCurrentProcess().Threads;

                    foreach (ProcessThread thread in threadsList)
                    {
                        thread.Dispose();
                    }
                    Thread.Sleep(500);
                    Application.Restart();
                }
                else
                {
                    savePreviousSession = false;
                    applyButton.Enabled = false;
                    if (Functions.saveSettings())
                    {
                        SettingsUpdated?.Invoke(this, EventArgs.Empty);
                        //MessageBox.Show("Settings saved successfully.", "Settings Saved", MessageBoxButtons.OK);
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        applyButton.Enabled = true;
                    }
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
            Close();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            DialogResult restart = MessageBox.Show("Are you sure you want to restart?", "Restart EDHE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (restart == DialogResult.Yes)
            {
                savePreviousSession = true;
                saveSession();
                prepForShutdown();
                Thread.Sleep(500);
                Application.Restart();
            }
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
            //do settings stuff
            capiEnabled = true;

            //do capi stuff
            OAuth2 oauth = new OAuth2();
            try
            {
                OAuth2.Load().Refresh();
            }
            catch
            {
                oauth = await new OAuth2Request().AuthorizeAsync(OAuth2.cts.Token);
                oauth.Save();
            }

            var journal = new CAPI(oauth).GetJournal();
            var profile = new CAPI(oauth).GetProfile();
            File.WriteAllText("C:\\EDHE\\res\\capi\\profile.json", profile.ToString());
            File.WriteAllText("C:\\EDHE\\res\\capi\\journal.json", journal.ToString());
            capiStatusTag.Text = "Connected";

            capiEnabled = true;
            capiDisconnectButton.Enabled = true;
            capiConnectButton.Enabled = false;

            //pull capi data
            string journalReadout = File.ReadAllText("C:\\EDHE\\res\\capi\\journal.json");
            using JsonDocument doc = JsonDocument.Parse(journalReadout);

            capiAccountTag.Text = doc.RootElement.GetProperty("id").ToString();
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

        private void currentToggleAll_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (CheckBox box in currentSessionTab.Controls.OfType<CheckBox>()) { if (box.Checked) { i++; } }

            foreach (CheckBox box in currentSessionTab.Controls.OfType<CheckBox>())
            {
                if (i == 0) { box.Checked = true; }
                else if (i == currentSessionTab.Controls.OfType<CheckBox>().Count()) { box.Checked = false; }
                else { box.Checked = true; }
            }

            SettingsUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void careerToggleAll_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (CheckBox box in careerStatisticsTab.Controls.OfType<CheckBox>()) { if (box.Checked) { i++; } }

            foreach (CheckBox box in careerStatisticsTab.Controls.OfType<CheckBox>())
            {
                if (i == 0) { box.Checked = true; }
                else if (i == careerStatisticsTab.Controls.OfType<CheckBox>().Count()) { box.Checked = false; }
                else { box.Checked = true; }
            }

            SettingsUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void statsListUpdated(object sender, EventArgs e) //fires when any of the checkboxes are clicked on, specifically
        {
            CheckBox senderBox = (CheckBox)sender;
            string key = senderBox.Name.Substring(0, senderBox.Name.Length - 8);

            //currentSessionTab careerStatisticsTab
            if (senderBox.Parent.Name == "currentSessionTab")
            {
                currentSessionEnabled[key] = senderBox.Checked;
            }
            else if (senderBox.Parent.Name == "careerStatisticsTab")
            {
                careerEnabled[key] = senderBox.Checked;
            }

            SettingsUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void resetCurrentSessionButton_Click(object sender, EventArgs e)
        {
            DialogResult resetConfirm = MessageBox.Show("Are you sure you want to restart the current combat log session?", "Reset Combat Log", MessageBoxButtons.YesNo);
            if (resetConfirm == DialogResult.Yes)
            {
                savePreviousSession = false;
                sessionNumber++;
                saveSession();
            }
        }
    }
}