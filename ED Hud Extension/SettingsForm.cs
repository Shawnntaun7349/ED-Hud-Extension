using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace ED_Hud_Extension
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            //default out the values so the user doesn't get an error for only changing one setting
            List<string> monitorList = GetMonitorList();
            prefDisplayMenu.DataSource = monitorList;
            prefDisplayMenu.SelectedIndex = 0;

            fullscreenMenu.SelectedIndex = 0;

            if (Globals.journalPath is not null) //check for valid journal selection rq
            {
                pathTextbox.Text = Globals.journalPath;
                prefDisplayMenu.SelectedIndex = Globals.savedPrefDisplayIndex;
            }
        }

        private void browseButton_Click(object sender, EventArgs e) //gimme the god damn journal folder
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "";
                folderDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    pathTextbox.Text = selectedPath;
                    Globals.journalPath = selectedPath;
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e) //check for errors, then save the user's settings
        {
            //then verify the journal folder
            string pathToCheck = Globals.journalPath;
            if (pathToCheck is null) //make sure the input isn't fucking empty
            {
                MessageBox.Show("The selection is empty. Please select the journal folder or click close.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (File.Exists(Path.Combine(pathToCheck, "ModulesInfo.json"))) //make sure that the folder is the correct one by checking for guaranteed files like the ModulesInfo file
            {
                Directory.CreateDirectory("C:\\EDHE"); //Create the EDHE directory if it doesn't exist
                string confirmedPath = pathToCheck;

                var path = new Dictionary<string, string>
                {
                    { "Path", confirmedPath },
                    { "Preferred Display", prefDisplayMenu.SelectedIndex.ToString() }

                };

                string json = JsonSerializer.Serialize(path, new JsonSerializerOptions { WriteIndented = true }); //json-ify that shit
                File.WriteAllText("C:\\EDHE\\settings.json", json); //create settings.json and write the data to it
                MessageBox.Show("Settings saved successfully! Application will now restart.", "Selection complete", MessageBoxButtons.OK);
                Application.Restart();

                //start out by attempting to adjust to the user's selected display
                MainForm mf = new MainForm();
                try
                {

                }
                catch
                {
                    MessageBox.Show("There was an issue with your display settings, please try again.", "Display Error", MessageBoxButtons.OK);
                    return;
                }
                return;
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
