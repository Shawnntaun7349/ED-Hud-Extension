using System.Threading;
using System.IO;
using System.Text.Json;
using static Functions;
using static Globals;

namespace ED_Hud_Extension
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            string sPath = "C:\\EDHE\\settings.json"; //check for a settings file
            try
            {
                //read the settings file
                string jPath = File.ReadAllText(sPath);
                using JsonDocument doc = JsonDocument.Parse(jPath);

                //read the journal folder path, assign it to the global & remove the 'hey wheres the journal?' warning
                string journalPath = doc.RootElement.GetProperty("Path").GetString();
                Globals.journalPath = $"{journalPath}";

                //read the saved preferred display index value
                try
                {
                    savedPrefDisplayIndex = Int32.Parse(doc.RootElement.GetProperty("Preferred Display").GetString()); //fucken frankenstein ass method
                }
                catch //if that fails, just default to the primary display
                {
                    savedPrefDisplayIndex = 0;
                }

                //make sure the form loads on the preferred display
                Screen displayScreen = Screen.AllScreens[savedPrefDisplayIndex];
                Globals.location = displayScreen.WorkingArea.Location;
                StartPosition = FormStartPosition.Manual;
                Location = location;

                InitializeComponent();
                initPanel.Visible = false;

            }
            catch
            {
                MessageBox.Show("No journal folder detected, please select the journal folder location in the settings menu.", "Journals not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void restartSessionButton_Click(object sender, EventArgs e) //used to manually reset the player's session if it doesn't reset automatically
        {

        }

        private void simulateButton_Click(object sender, EventArgs e)
        {

            simulateCombat(true, "potato", "Keelback", 100, 100);

            combatStatTag.Text = "Active";
            combatStatTag.ForeColor = Color.Red;

            targetTag.Text = targetName;
            shipTag.Text = targetShip;
            shieldTag.Text = targetShield.ToString();
            hullTag.Text = targetHull.ToString();
        }

        private void settingsButton_Click(object sender, EventArgs e) //opens the settings menu
        {
            SettingsForm sf = new SettingsForm();

            sf.FormClosed += (s, args) =>
            {
                initPanel.Visible = false;
            };

            sf.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
