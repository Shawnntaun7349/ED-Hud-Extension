using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

using static Globals;

namespace ED_Hud_Extension
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            //try to load the user's saved settings
            
            prefDisplayMenu.DataSource = GetMonitorList();
            prefDisplayMenu.SelectedIndex = savedPrefDisplayIndex;

            fullscreenMenu.SelectedIndex = selectedIndex;
            journalPathTextbox.Text = journalPath;
            gamePathTextbox.Text = gamePath;
            statReadToggle.Checked = statusEnabled;
            autoSwitchToggle.Checked = autoPanelSwitch;
            combatSwitchToggle.Checked = autoCombatSwitch;
            autoShutdownToggle.Checked = autoShutDownEnabled;
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

        private void applyButton_Click(object sender, EventArgs e) //check for errors, then save the user's settings
        {
            //then verify the journal folder
            string pathToCheck = journalPath;
            if (pathToCheck is null) //make sure the input isn't fucking empty
            {
                MessageBox.Show("The selection is empty. Please select the journal folder or click close.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Directory.Exists(pathToCheck)) //make sure that the folder is the correct one by checking for guaranteed files like the ModulesInfo file
            {
                chosenDisplay = prefDisplayMenu.SelectedIndex;
                statusEnabled = statReadToggle.Checked;
                gamePath = gamePathTextbox.Text;
                journalPath = journalPathTextbox.Text;
                autoPanelSwitch = autoSwitchToggle.Checked;
                autoCombatSwitch = combatSwitchToggle.Checked;
                autoShutDownEnabled = autoShutdownToggle.Checked;

                Functions.saveSettings();
                MessageBox.Show("Settings saved successfully! Application will now restart.", "Selection complete", MessageBoxButtons.OK);
                
                Application.Restart();
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
                "Are you sure?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
