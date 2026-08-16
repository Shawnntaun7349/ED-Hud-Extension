using System.Threading;
using static Functions;
using static Globals;

namespace ED_Hud_Extension
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
    }
}
