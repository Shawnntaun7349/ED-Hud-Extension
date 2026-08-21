using EliteJournalReader;
using EliteJournalReader.Events;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms.Design;
using static Functions;
using static Globals;

namespace ED_Hud_Extension
{
    public partial class MainForm : Form
    {
        private static System.Threading.Timer animTimer;//multi-threading timers are a hassle 
        private static System.Threading.Timer localTimer;//multi-threading timers are a hassle 
        private static System.Threading.Timer connectingTimer;

        //bits for the connection 'animation'
        public static string animConnectionText = "establishing uplink connection."; //waitingConnectLabel label
        public static string animConnectionTextBase = "establishing uplink connection.";
        public static string animClientText = "awaiting client response.";
        public static string animClientTextBase = "awaiting client response.";
        public static int animDots = 1;
        public static int conDots = 1;
        public static int animCycles = 0;
        public static int steps = 1;
        public static bool timeToClear = false;

        public static string statBase = "Status : ";

        public static bool currentJournal = false; //is the game running? use the most recent journal
        public static bool newJournal = false; //is the game not running? wait for a new journal
        public static bool clientReady = false;

        public bool gameRunning()
        {
            if (Process.GetProcessesByName("EliteDangerous64").Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            loadSettings();

            if (statusEnabled) { statusLabel.Visible = true; }

            StartPosition = FormStartPosition.Manual;
            Location = location; //this is thisForm.Location property being set to the Globals.location value
            animTimer = new System.Threading.Timer(animCallbackMethod, "Timer State", 500, 1000);
            localTimer = new System.Threading.Timer(localCallbackMethod, "Timer State", 100, 500);

            if (statusEnabled) { statusLabel.Text = ("mainform initialized, timers started, settings loaded\n"); }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (statusEnabled) { statusLabel.Text = "initiating service"; }
            locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm");

            if (gameRunning()) //if the game is already running when EDHE spins up
            {
                initiateWatcher();
                currentJournal = true;
                if (statusEnabled) { statusLabel.Text = ("mainform loaded, game is running"); }
            }
            else //otherwise, start the loop & wait for the game to spin up
            {
                if (statusEnabled) { statusLabel.Text = statBase + "waiting for client"; }
            }
        }
        public JournalWatcher watcher = new JournalWatcher(journalPath);

        private void initiateWatcher()
        {
            watcher.Path = journalPath;

            watcher.StartWatching(); //start the watcher to monitor for events
            watcher.GetEvent<NewJournalFileEvent>().Fired += newJournalMethod;
            watcher.GetEvent<LoadGameEvent>().Fired += loadInitialData;
            if (statusEnabled) { statusLabel.Invoke(new Action(() => statusLabel.Text = statBase + "initiating journal watcher")); }
        }

        private void newJournalMethod(object? sender, NewJournalFileEvent.NewJournalFileEventArgs args)
        {
            newJournal = true;
            if (statusEnabled) { statusLabel.Invoke(new Action(() => statusLabel.Text = statBase + "new journal file generated, initiating reader")); }
        }

        private void loadInitialData(object? sender, LoadGameEvent.LoadGameEventArgs args)
        {
            if (newJournal)
            {
                cmdrNameLabel.Invoke(new Action(() => cmdrNameLabel.Text = args.Commander));
                shipLabel.Invoke(new Action(() => shipLabel.Text = args.Ship));
                shipNameLabel.Invoke(new Action(() => shipNameLabel.Text = args.ShipName));

                clientReady = true;
                if (statusEnabled) { statusLabel.Invoke(new Action(() => statusLabel.Text = statBase + "new journal generated, parsing")); }
            }
            else
            {
                cmdrNameLabel.Invoke(new Action(() => cmdrNameLabel.Text = args.Commander));
                shipLabel.Invoke(new Action(() => shipLabel.Text = args.Ship));
                shipNameLabel.Invoke(new Action(() => shipNameLabel.Text = args.ShipName));

                clientReady = true;
                if (statusEnabled) { statusLabel.Invoke(new Action(() => statusLabel.Text = statBase + "current journal identified, parsing")); }
            }
        }

        private void restartSessionButton_Click(object sender, EventArgs e) //used to manually reset the player's session if it doesn't reset automatically
        {
            TestForm tf = new TestForm();
            tf.Show();
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

            //sf.FormClosed += (s, args) =>
            //{
            //    initPanel.Visible = false;
            //};

            sf.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult exitBox = MessageBox.Show("Are you sure?", "Terminate Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitBox == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        // --------------------- methods for Home panel ui ---------------------
        //timer methods
        private void localCallbackMethod(object state)
        {
            locDTTag.Invoke(new Action(() => locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm")));

            //create the two ends of the tag, then insert the modified year
            string starTimeStart = DateTime.UtcNow.ToString("dddd, MMMM dd, ");
            string startTimeEnd = DateTime.UtcNow.ToString("\nHH:mm");
            string fullText = starTimeStart + starYear.ToString() + startTimeEnd;
            starDTTag.Invoke(new Action(() => starDTTag.Text = fullText));
        }

        private void starDTTag_TextChanged(object sender, EventArgs e)
        {
            starDTTag.Visible = true;
            waitingSTTag.Visible = false;
            starDTTag.TextChanged -= starDTTag_TextChanged; //unsubscribe so that this method doesn't fire ad-nauseum for no reason
        }

        //'animation' methods
        private void animCallbackMethod(object state)
        {
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "service loaded, running anim loop while waiting for game to load")); }

            if (steps == 1)
            {
                initLabel.Invoke(new Action(() => initLabel.Text += "done"));
                diagLabel.Invoke(new Action(() => diagLabel.Visible = true));
                steps++;
            }
            else if (steps == 2)
            {
                diagLabel.Invoke(new Action(() => diagLabel.Text += "done"));
                enviroLabel.Invoke(new Action(() => enviroLabel.Visible = true));
                steps++;
            }
            else if (steps == 3)
            {
                enviroLabel.Invoke(new Action(() => enviroLabel.Text += "done"));
                waitingConnectLabel.Invoke(new Action(() => waitingConnectLabel.Visible = true));
                steps++;
            }
            else if (!timeToClear) // ... animation loop ///run while waiting for the journalwatcher to identify the proper journal to read
            {
                animTimer.Change(500, 500);
                if (animDots < 3) //if that string has less than 3 periods
                {
                    animConnectionText = animConnectionText + ".";
                    waitingConnectLabel.Invoke(new Action(() => waitingConnectLabel.Text = animConnectionText));
                    animDots++;
                }
                else if (!newJournal || !timeToClear)//if that string has all 3 periods, reset it it back to one.
                {
                    animConnectionText = animConnectionTextBase;
                    waitingConnectLabel.Invoke(new Action(() => waitingConnectLabel.Text = animConnectionText));
                    animDots = 1;
                    animCycles++;

                    if (gameRunning())
                    {
                        Invoke(new Action(() => waitingClientLabel.Visible = true));
                        animTimer.Dispose();
                        waitingConnectLabel.Invoke(new Action(() => waitingConnectLabel.Text = "establishing uplink connection...      done"));
                        Invoke(new Action(() => waitingClientLabel.Visible = true));
                        connectingTimer = new System.Threading.Timer(connectingCallBackMethod, "Timer State", 500, 500);
                        animDots = 1;
                        newJournal = true;

                        if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "moving to trigger client timer")); }
                    }
                }
                else if (gameRunning())
                {
                    Invoke(new Action(() => waitingClientLabel.Visible = true));
                    animTimer.Dispose();
                    waitingConnectLabel.Invoke(new Action(() => waitingConnectLabel.Text = "establishing uplink connection...      done"));
                    Invoke(new Action(() => waitingClientLabel.Visible = true));
                    connectingTimer = new System.Threading.Timer(connectingCallBackMethod, "Timer State", 500, 500);
                    animDots = 1;
                    newJournal = true;

                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = "client loaded, waiting for game start")); }
                }
            }
        }

        private void connectingCallBackMethod(object state)
        {
            if (conDots < 3) //runs if there are less than three dots in the animation string.
            {
                animClientText += ".";
                Invoke(new Action(() => waitingClientLabel.Text = animClientText));
                conDots++;
                if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = "client loaded, waiting for game start [anim 1]")); }
            }
            else if (conDots >= 3 && !clientReady) //if we reach 3 dots and the client's not ready yet
            {
                animClientText = animClientTextBase;
                Invoke(new Action(() => waitingClientLabel.Text = animClientTextBase));
                conDots = 1;
                if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = "client loaded, waiting for game start [anim 2]")); }
            }
            else if (clientReady) //if we've reached 3 dots and the client is ready
            {
                Invoke(new Action(() => waitingClientLabel.Text = "awaiting client response...             done"));
                initiateWatcher();
            }
        }


        private void cmdrNameLabel_TextChanged(object sender, EventArgs e)
        {
            initPanel.Dispose();
            animTimer.Dispose();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}

