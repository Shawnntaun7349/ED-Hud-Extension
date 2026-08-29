using EliteJournalReader;
using EliteJournalReader.Events;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using static ED_Hud_Extension.SystemData;
using static Functions;
using static Globals;
using static StatusReader;

namespace ED_Hud_Extension
{
    public partial class MainForm : Form
    {
        //timers for timing things 
        private static System.Threading.Timer localTimer;//multi-threading timers are a hassle 
        private static System.Threading.Timer connectingTimer;
        private static System.Threading.Timer scanTimer;
        private static System.Threading.Timer fsdTimer;

        //bits for the connection 'animation'
        private static System.Threading.Timer animTimer;
        public static string animConnectionText = "establishing uplink connection.";
        public static string animConnectionTextBase = "establishing uplink connection.";
        public static string animClientText = "awaiting client response.";
        public static string animClientTextBase = "awaiting client response.";
        public static int animDots = 1;
        public static int conDots = 1;
        public static int steps = 1;
        public static bool timeToClear = false;

        //bits for notifications / status updates
        public static bool scanReset;
        public static int fsdCooldown;

        public static string statBase = "Status : ";

        public static bool currentJournal = false; //is the game running? use the most recent journal
        public static bool newJournal = false; //is the game not running? wait for a new journal
        public static bool clientReady = false; //is the game running but we're idling on the main menu? wait for a game mode selection
        public static bool watcherLive = false; //has the watcher already been initialized? [don't do it twice things break]
        public static ShipFlag _flag = new ShipFlag();
        public static StatusReader statReader = new StatusReader();
        public SystemData systemData = new SystemData();


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

        public bool inMainMenu(ShipFlag _flag)
        {
            if (_flag.HasFlag(ShipFlag.None))
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

            DoubleBuffered = true;

            loadSettings();

            if (statusEnabled) { statusLabel.Visible = true; }

            StartPosition = FormStartPosition.Manual;
            Location = location; //this is thisForm.Location property being set to the Globals.location value
            animTimer = new System.Threading.Timer(animCallbackMethod, "Timer State", 500, 1000);
            scanTimer = new System.Threading.Timer(scanCallbackMethod, "Timer State", Timeout.Infinite, Timeout.Infinite);

            if (statusEnabled) { statusLabel.Text = statBase + ("mainform initialized, timers started, settings loaded\n"); }

            initPanel.BringToFront();
            dividerPanel.Visible = false;

            oxaniumFont.AddFontFile("C:\\EDHE\\res\\Oxanium\\Oxanium-Bold.ttf");

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainFormLoaded = true;
            if (statusEnabled) { statusLabel.Text = statBase + "initiating service"; }
            loopTimer = new System.Threading.Timer(readTimerCallback, "Timer State", 50, 50); //start the loop for the status reader
            localTimer = new System.Threading.Timer(localCallbackMethod, "Timer State", 100, 250);

            DateTimeOffset yOffset = DateTimeOffset.UtcNow.AddYears(1286);
            string starTime = DateTime.UtcNow.ToString("HH:mm");
            string starDate = yOffset.ToString();
            locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm");
            starDateTag.Text = starDate;
            starTimeTag.Text = starTime;

            if (gameRunning() && (!inMainMenu(_flag))) //if the game is already running when EDHE spins up, also if we're not in the main menu (status Flag1 reads 0 until player loads into game proper) 
            {
                initiateWatcher();
                currentJournal = true;
                if (statusEnabled) { statusLabel.Text = statBase + "mainform loaded, game is running"; }
                //animTimer.Dispose();
                dividerPanel.Visible = true;
            }
            else //otherwise, start the loop & wait for the game to spin up
            {
                if (statusEnabled) { statusLabel.Text = statBase + "waiting for client"; }
                initPanel.BringToFront();
                dividerPanel.Visible = false;
            }
        }

        // --------------------- methods for handling Journal Reader events ---------------------
        public JournalWatcher watcher = new JournalWatcher(journalPath);
        public static System.Threading.Timer loopTimer;
        public static ShipFlag sf = new ShipFlag();
        public static OnFootFlag ff = new OnFootFlag();

        private void initiateWatcher()
        {
            watcherLive = true;
            watcher.Path = journalPath;
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "initiating journal watcher")); }

            watcher.StartWatching(); //start the watcher to monitor for events

            // event subscriptions
            //starting up
            startUpTime = DateTime.UtcNow;
            watcher.GetEvent<NewJournalFileEvent>().Fired += newJournalMethod;
            watcher.GetEvent<LoadGameEvent>().Fired += loadInitialData;
            watcher.GetEvent<RankEvent>().Fired += rankEvent;
            watcher.GetEvent<ProgressEvent>().Fired += progressEvent;
            watcher.GetEvent<ReputationEvent>().Fired += repEvent;
            watcher.GetEvent<LocationEvent>().Fired += locationEvent;

            //shutting down
            watcher.GetEvent<ShutdownEvent>().Fired += gameShutDown;

            //refueling
            watcher.GetEvent<RefuelAllEvent>().Fired += refuelAllEvent;
            watcher.GetEvent<RefuelPartialEvent>().Fired += refuelPartialEvent;

            //scanning
            watcher.GetEvent<ScanEvent>().Fired += scanEvent;
            watcher.GetEvent<ShipTargetedEvent>().Fired += shipTargetedEvent;

            //fsd events
            watcher.GetEvent<FSDTargetEvent>().Fired += fsdTarget;
            watcher.GetEvent<FSDJumpEvent>().Fired += fsdJump;
            watcher.GetEvent<StartJumpEvent>().Fired += fsdStartJump;

            //nav events
            watcher.GetEvent<NavRouteClearEvent>().Fired += navCleared;
        }

        //journal events
        private void newJournalMethod(object? sender, NewJournalFileEvent.NewJournalFileEventArgs args) //fires on startup
        {
            newJournal = true;
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "new journal file generated, initiating reader")); }
        }

        private void loadInitialData(object? sender, LoadGameEvent.LoadGameEventArgs args) //fires on startup
        {
            if (newJournal) { if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "new journal generated, parsing")); } }
            else { if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "current journal identified, parsing")); } }

            Invoke(new Action(() => linkLabel.Text = "uplink integrity: high"));
            Invoke(new Action(() => linkLabel.ForeColor = Color.FromArgb(192, 64, 0)));

            Invoke(new Action(() => welcomeLabel.Text = ""));
            Invoke(new Action(() => welcomeLabel.Text += "Welcome, Commander\n" + args.Commander));
            clientReady = true;

            currentFuelLevel = args.FuelLevel;
            maxFuelLevel = args.FuelCapacity;
            pShipType = args.Ship;
            pShipName = args.ShipName;
            pShipID = args.ShipIdent;

            gameMode = args.GameMode.ToString();

            pCreditBalance = args.Credits;
            pLoan = args.Loan;

            string pCreditBalanceFormatted = string.Format("{0:N0}", pCreditBalance);
            string pLoanBalanceFormatted = string.Format("{0:N0}", pLoan);
            Invoke(new Action(() => homeCredBalanceTag.Text = pCreditBalanceFormatted));

            if (pLoan == 0) { Invoke(new Action(() => homeLBTag.Text = "None")); }
            else { Invoke(new Action(() => homeLBTag.Text = pLoanBalanceFormatted)); }

            Invoke(new Action(() => curShipTag.Text = args.Ship));
            Invoke(new Action(() => curShipDesTag.Text = args.ShipName));
            Invoke(new Action(() => curShipIDTag.Text = args.ShipIdent));
            Invoke(new Action(() => curShipFuelTag.Text = (currentFuelLevel + " / " + maxFuelLevel)));

            Invoke(new Action(() => homeLSTag.Text = "scanning..."));
            Invoke(new Action(() => homeSysTag.Text = "scanning..."));
        }

        private void rankEvent(object? sender, RankEvent.RankEventArgs e) //fires on startup
        {
            //its an obnoxious amount of 'possible null value' warnings, but we gotta include the .ToString() call in case the rank *isn't* Elite
            pCombatRank = eliteTier(e.Combat).ToString();
            pExploreRank = eliteTier(e.Explore).ToString();
            pTradeRank = eliteTier(e.Trade).ToString();
            pArenaRank = eliteTier(e.CQC).ToString();
            pExoBioRank = eliteTier(e.Exobiologist).ToString();
            pMercRank = eliteTier(e.Soldier).ToString();
            pFedRank = e.Federation.ToString();
            pEmpRank = e.Empire.ToString();

            Invoke(new Action(() => homeCRTag.Text = pCombatRank));
            Invoke(new Action(() => homeMRTag.Text = pMercRank));
            Invoke(new Action(() => homeARTag.Text = pArenaRank));
            Invoke(new Action(() => homeEXRTag.Text = pExoBioRank));
            Invoke(new Action(() => homeERTag.Text = pExploreRank));
            Invoke(new Action(() => homeTRTag.Text = pTradeRank));
        }

        private void progressEvent(object? sender, ProgressEvent.ProgressEventArgs e) //fires on startup
        {
            pCombatProgress = e.Combat;
            pExploreProgress = e.Explore;
            pTradeProgress = e.Trade;
            pArenaProgress = e.CQC;
            pExoBioProgress = e.Exobiologist;
            pMercProgress = e.Soldier;
            pFedProgress = e.Federation;
            pEmpProgress = e.Empire;
        }

        private void repEvent(object? sender, ReputationEvent.ReputationEventArgs e) //fires on startup *after* rank & progress events
        {
            pEmpRep = e.Empire;
            pFedRep = e.Federation;
            pAllyRep = e.Alliance;
            pIndieRep = e.Independent;

            pEmpRepType = e.EmpireStatus.ToString();
            pFedRepType = e.FederationStatus.ToString();
            pAllyRepType = e.AllianceStatus.ToString();
            pIndieRepType = e.IndependentStatus.ToString();
        }

        private void locationEvent(object? sender, LocationEvent.LocationEventArgs e) //fires on startup or at a station post-death
        {
            pCurrentSystem = e.StarSystem;
            starFaction = e.SystemFaction.ToString();
            pFactionRep = e.SystemFaction.MyReputation.ToString(); //this is a number value, needs converted to keywords for readability
            pWanted = e.Wanted;
            starFactionState = e.SystemFaction.FactionState;
            systemAllegiance = e.SystemAllegiance.ToString();
            systemPrimEconomy = e.SystemEconomy_Localised;
            systemSecEconomy = e.SystemSecondEconomy_Localised;
            systemGovernment = e.SystemGovernment_Localised;
            systemSecurity = e.SystemSecurity_Localised;

            pDocked = e.Docked;
            if (pDocked)
            {
                stationName = e.StationName;
                stationType = e.StationType;
                marketID = e.MarketID;
            }

            if (pWanted) { Invoke(new Action(() => homeLSTag.Text = "Wanted")); Invoke(new Action(() => homeLSTag.ForeColor = Color.DarkRed)); }
            else { Invoke(new Action(() => homeLSTag.Text = "Clean")); Invoke(new Action(() => homeLSTag.ForeColor = Color.FromArgb(192, 64, 0))); }
            Invoke(new Action(() => homeSysTag.Text = pCurrentSystem));

            Invoke(new Action(() => combatSysAllegianceTag.Text = systemAllegiance));
            Invoke(new Action(() => combatSysGovTag.Text = systemGovernment));
            Invoke(new Action(() => combatSysSecTag.Text = systemSecurity));

            Invoke(new Action(() => updateLocationData(e.StarSystem)));
        }

        private void underAttack(object? sender, UnderAttackEvent.UnderAttackEventArgs e) //take a fucken guess what this one's for
        {
            attackerTarget = e.Target.ToString();
            pUnderAttack = true;
            if (autoPanelSwitch || autoCombatSwitch) { combatPanel.BringToFront(); }
        }

        private void scanEvent(object? sender, ScanEvent.ScanEventArgs e) //for when a player scans an astral body
        {

        }

        private void shipTargetedEvent(object? sender, ShipTargetedEvent.ShipTargetedEventArgs e) //for when the player scans a ship
        {
            if (e.Timestamp > startUpTime) //if this event fired *after* the current journal reader fired up
            {
                if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = "scanning target")); }

                scanLevel = e.ScanStage;
                //scanTimer = new System.Threading.Timer(scanCallbackMethod, "Timer State", 0, 500);

                if (!scanDone)
                {
                    string scanStageBase = "scanning.";
                    Invoke(new Action(() => scanStageTag.Text = scanStageBase));
                    scanLevel = e.ScanStage;
                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "scan stage 0")); }
                }

                if (e.TargetLocked)
                {
                    targetLocked = true; Invoke(new Action(() => targetDataLabel.Text = "Target Data [Current]"));

                    //clear out the old data
                    foreach (Label lbl in combatPanel.Controls.OfType<Label>().Where(lbl => lbl.Tag != null && lbl.Tag.ToString() == "combatTag"))
                    {
                        Invoke(new Action(() => lbl.Text = "[awaiting scan]"));
                    }

                    targetShip = e.Ship_Localised;
                    Invoke(new Action(() => targetShipTag.Text = targetShip.ToString()));
                    scanLevel = e.ScanStage;
                }
                else
                {
                    scanLevel = e.ScanStage;
                    targetLocked = false;
                    Invoke(new Action(() => targetDataLabel.Text = "Target Data [Previous]"));
                    Invoke(new Action(() => scanStageTag.Text = "no target"));
                }

                if (scanLevel >= 1)
                {
                    scanLevel = e.ScanStage;
                    pTargeting = true;
                    targetName = e.PilotName_Localised;
                    targetRank = e.PilotRank.ToString(); //don't convert the target's rank to Elite tiers, the player doesn't get to know that detail

                    Invoke(new Action(() => targetTag.Text = targetName));
                    Invoke(new Action(() => targetRankTag.Text = correctedRank((targetRank.ToString()))));

                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "scan stage 1")); }
                }
                if (scanLevel >= 2)
                {
                    scanLevel = e.ScanStage;
                    targetShield = e.ShieldHealth;
                    targetHull = e.HullHealth;

                    Invoke(new Action(() => targetShieldTag.Text = targetShield.ToString() + "%"));
                    Invoke(new Action(() => targetHullTag.Text = targetHull.ToString() + "%"));

                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "scan stage 2")); }
                }
                if (scanLevel >= 3)
                {
                    scanLevel = e.ScanStage;
                    scanDone = true;
                    scanTimer.Change(0, Timeout.Infinite);
                    targetFaction = e.Faction;
                    targetPower = e.Power;

                    targetLegal = e.LegalStatus;
                    targetBounty = e.Bounty;
                    int totalBounty = 0;

                    if (e.LegalStatus == "Clean") //if they appear clean locally
                    {
                        Invoke(new Action(() => targetLegalStatusTag.Text = "Clean"));
                        Invoke(new Action(() => targetBountyTag.Text = "None"));
                        Invoke(new Action(() => targetLegalStatusTag.ForeColor = Color.White));
                        totalBounty = 0;
                    }
                    if (e.LegalStatus == "Hunter") //if a KWS comes back with this status, they're wanted outside of this system but clean locally
                    {
                        Invoke(new Action(() => targetLegalStatusTag.Text = "Warranted"));
                        Invoke(new Action(() => targetLegalStatusTag.ForeColor = Color.DarkRed));
                        totalBounty += (int)e.Bounty;
                        Invoke(new Action(() => targetBountyTag.Text = totalBounty.ToString()));
                    }
                    if (e.LegalStatus == "Wanted") //if they're wanted here
                    {
                        Invoke(new Action(() => targetLegalStatusTag.ForeColor = Color.DarkRed));
                        if (totalBounty + (int)e.Bounty > totalBounty) //and they're wanted elsewhere
                        {
                            totalBounty += (int)e.Bounty;
                            Invoke(new Action(() => targetLegalStatusTag.Text = "Wanted && Warranted")); //fucken get em
                            Invoke(new Action(() => targetBountyTag.Text = totalBounty.ToString()));
                        }
                        else //but they're not wanted elsewhere
                        {
                            Invoke(new Action(() => targetLegalStatusTag.Text = "Wanted")); //still smoke em, but with less enthusiasm
                            Invoke(new Action(() => targetBountyTag.Text = totalBounty.ToString()));
                        }
                    }
                    if (e.LegalStatus == "Lawless") //if laws don't apply here
                    {
                        Invoke(new Action(() => targetLegalStatusTag.ForeColor = Color.DarkRed));
                        Invoke(new Action(() => targetLegalStatusTag.Text = "Lawless")); //might not have a bounty, but you *can* shoot them if you want
                        Invoke(new Action(() => targetBountyTag.Text = totalBounty.ToString()));
                    }

                    Invoke(new Action(() => scanStageTag.Text = "Target Locked"));

                    if (e.Power is not null && e.Faction == "0")
                    {
                        targetFaction = targetPower;
                    }

                    if (e.Power is null)
                    {
                        targetPower = "None";
                    }

                    Invoke(new Action(() => targetPowerTag.Text = targetPower));
                    Invoke(new Action(() => targetFactionTag.Text = targetFaction));

                    Invoke(new Action(() => targetBountyTag.Text = string.Format("{0:N0}", e.Bounty)));

                    targetSubSystem = e.SubSystem_Localised; //fuck me sideways i misspelled that shit
                    targetSSHealth = e.SubSystemHealth;

                    if (e.SubSystem != null)
                    {
                        Invoke(new Action(() => targetSSTag.Text = targetSubSystem));
                        Invoke(new Action(() => targetSSHTag.Text = e.SubSystemHealth.ToString() + "%"));
                    }

                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "scan stage 3")); }
                }

            }
            else { /*ignore the event as it occured before edhe started*/ }
        }

        private void fsdTarget(object? sender, FSDTargetEvent.FSDTargetEventArgs e)
        {
            if (e.Timestamp > startUpTime)
            {
                Invoke(new Action(() => expNextSystemTag.Text = e.Name.ToString()));
            }
            else { /*ignore the event as it occured before edhe started*/ }
        }

        private void fsdStartJump(object? sender, StartJumpEvent.StartJumpEventArgs e)
        {
            if (e.Timestamp > startUpTime)
            {
                Invoke(new Action(() => fsdTag.Text = "energizing"));
            }
            else { /*ignore the event as it occured before edhe started*/ }
        }

        private void fsdJump(object? sender, FSDJumpEvent.FSDJumpEventArgs e)
        {
            if (e.Timestamp > startUpTime)
            {
                Invoke(new Action(() => fsdTag.Text = "cooling..."));
                fsdCooldown = 0;
                fsdTimer = new System.Threading.Timer(fsdCooldownCallbackMethod, "Timer State", 0, 1000);
                pCurrentSystem = e.StarSystem;
                Invoke(new Action(() => updateLocationData(e.StarSystem)));
            }
            else { /*ignore the event as it occured before edhe started*/ }
        }

        private void navCleared(object? sender, NavRouteClearEvent.NavRouteClearEventArgs e)
        {
            while (fsdCooldown != 0)
            {
                //wait for cooldown to complete
            }

            Invoke(new Action(() => fsdTag.Text = "ready"));

        }

        private void refuelAllEvent(object? sender, RefuelAllEvent.RefuelAllEventArgs args) //journal watcher requires full and partial refueling calls to be seperate, so 
        {                                                                                   //seperate messages / callouts maybe?
            currentFuelLevel = maxFuelLevel;
            Invoke(new Action(() => curShipFuelTag.Text = (currentFuelLevel + " / " + maxFuelLevel)));
        }

        private void refuelPartialEvent(object? sender, RefuelPartialEvent.RefuelPartialEventArgs args)
        {
            currentFuelLevel += args.Amount;
            Invoke(new Action(() => curShipFuelTag.Text = (currentFuelLevel + " / " + maxFuelLevel)));
        }

        private void gameShutDown(object? sender, ShutdownEvent.ShutdownEventArgs e)
        {
            if (autoShutDownEnabled && e.Timestamp > startUpTime)
            {
                Invoke(new Action(() => MessageBox.Show(this, "Elite Dangerous has shut down. EDHE will now shut down.", "Shutting Down", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                Application.Exit();
            }
            else if (e.Timestamp > startUpTime)
            {
                Invoke(new Action(() => MessageBox.Show(this, "Elite Dangerous has shut down. EDHE will remain operational but will need restarted in the case of a new session.", "Uplink Lost", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                Invoke(new Action(() => linkLabel.Text = " uplink integrity lost"));
                Invoke(new Action(() => linkLabel.ForeColor = Color.DarkRed));
                shutdownTime = DateTime.Now;
            }
        }

        private void updateLocationData(string system)
        {            
            Invoke(new Action(() => expCurrentSystemTag.Text = system));
            fetchStarData("https://www.edsm.net/api-system-v1/bodies?systemName=" + system); //get the system data

            clearBodyList();
            systemData.loadSystemData(bodyListPanel, system);
        }

        //--------------------- sidebar ui methods ---------------------

        private void restartSessionButton_Click(object sender, EventArgs e) //used to manually reset the player's session if it doesn't reset automatically
        {
            Invoke(new Action(() => MessageBox.Show(this, "Elite Dangerous has shut down. EDHE will remain operational but will need restarted in the case of a new session.", "Uplink Lost", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            Invoke(new Action(() => linkLabel.Text = " uplink integrity lost"));
            Invoke(new Action(() => linkLabel.ForeColor = Color.DarkRed));
        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            updateLocationData(pCurrentSystem);
        }

        private void settingsButton_Click(object sender, EventArgs e) //opens the settings menu
        {
            SettingsForm sf = new SettingsForm();

            sf.Show(this);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult exitBox = MessageBox.Show("Are you sure?", "Terminate Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitBox == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        // --------------------- Home panel methods ---------------------
        //timer methods
        private void localCallbackMethod(object state)
        {
            DateTimeOffset yOffset = DateTimeOffset.UtcNow.AddYears(1286);
            string starTime = DateTime.UtcNow.ToString("HH:mm");
            string starDate = yOffset.ToString();
            Invoke(new Action(() => locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm")));
            Invoke(new Action(() => starDateTag.Text = starDate));
            Invoke(new Action(() => starTimeTag.Text = starTime));
        }

        public static void readTimerCallback(object? sender)
        {
            readStatus(journalPath, sf, ff);
        }

        private void fsdCooldownCallbackMethod(object state)
        {
            if (fsdCooldown < 10)
            {
                fsdCooldown++;
            }
            else
            {
                Invoke(new Action(() => fsdTag.Text = "ready"));
                fsdTimer.Dispose();
            }
        }

        //'animation' methods
        private void animCallbackMethod(object state)
        {
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "service loaded, running anim loop while waiting for game to load")); }

            if (mainFormLoaded)
            {
                if (steps == 1)
                {
                    Invoke(new Action(() => initDone.Visible = true));
                    Invoke(new Action(() => diagLabel.Visible = true));
                    steps++;
                }
                else if (steps == 2)
                {
                    Invoke(new Action(() => diagDone.Visible = true));
                    enviroLabel.Invoke(new Action(() => enviroLabel.Visible = true));
                    steps++;
                }
                else if (steps == 3)
                {
                    Invoke(new Action(() => enviroDone.Visible = true));
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
                    else if (!newJournal)//if that string has all 3 periods, reset it it back to one.
                    {
                        animConnectionText = animConnectionTextBase;
                        waitingConnectLabel.Invoke(new Action(() => waitingConnectLabel.Text = animConnectionText));
                        animDots = 1;

                        if (gameRunning())
                        {
                            initiateWatcher();
                            animTimer.Dispose();
                            Invoke(new Action(() => waitingConnectLabel.Text = "establishing uplink connection..."));
                            Invoke(new Action(() => uplinkDone.Visible = true));
                            Invoke(new Action(() => waitingClientLabel.Visible = true));
                            connectingTimer = new System.Threading.Timer(connectingCallBackMethod, "Timer State", 500, 500);
                            animDots = 1;

                            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "moving to trigger client timer")); }
                        }
                    }
                    else if (gameRunning())
                    {
                        initiateWatcher();
                        animTimer.Dispose();
                        Invoke(new Action(() => waitingConnectLabel.Text = "establishing uplink connection..."));
                        Invoke(new Action(() => uplinkDone.Visible = true));
                        Invoke(new Action(() => waitingClientLabel.Visible = true));
                        connectingTimer = new System.Threading.Timer(connectingCallBackMethod, "Timer State", 500, 500);
                        animDots = 1;



                        if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "client loaded, waiting for game start")); }
                    }
                }
            }
        }



        private void connectingCallBackMethod(object state)
        {
            if (!mainFormLoaded)
            {
                if (!watcherLive)
                {
                    initiateWatcher();
                }

                if (conDots < 3 && !clientReady) //runs if there are less than three dots in the animation string and the client's not ready
                {
                    animClientText += ".";
                    Invoke(new Action(() => waitingClientLabel.Text = animClientText));
                    conDots++;
                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "client loaded, waiting for game start [anim 1]")); }
                }
                else if (conDots >= 3 && !clientReady) //if we reach 3 dots and the client's not ready yet
                {
                    animClientText = animClientTextBase;
                    Invoke(new Action(() => waitingClientLabel.Text = animClientTextBase));
                    conDots = 1;
                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "client loaded, waiting for game start [anim 2]")); }
                }
                else if (clientReady && (!inMainMenu(_flag))) //if we've reached 3 dots and the client is ready
                {
                    Invoke(new Action(() => waitingClientLabel.Text = "awaiting client response..."));
                    Invoke(new Action(() => clientDone.Visible = true));
                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "client loaded, waiting for game start")); }
                }
            }
        }

        private void scanCallbackMethod(object sender)
        {
            if (scanDone) { return; } //if the scan is done fuck off

            //if (!targetLocked && !scanReset) //if the user lost the target but we havent started the 'lost target' scanner
            //{
            //    scanTimer.Change(0, 5000);
            //    scanReset = true;
            //}
            else if (!targetLocked & scanReset) //if the timer has elapsed & we still dont have a target
            {
                Invoke(new Action(() => scanStageTag.Text = "no target"));
                Invoke(new Action(() => statusLabel.Text = statBase + "no target to scan"));
                scanTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            else
            {
                if (animDots < 3 && !scanDone)
                {
                    //animateLabel(animTimer, scanStageTag, "scanning.", 1, true);
                    //Invoke(new Action(() => scanStageTag.Text = "target locked"));
                    Invoke(new Action(() => scanStageTag.Text += "."));
                    animDots++;
                }
                else if (animDots >= 3 && !scanDone)
                {
                    Invoke(new Action(() => scanStageTag.Text = "scanning."));
                    animDots = 1;
                }
            }
        }

        private void clearInitPanel()
        {
            animDots = 1;
            initPanel.Dispose();
            //animTimer.Dispose();
            homePanel.BringToFront();
            dividerPanel.BringToFront();
            dividerPanel.Visible = true;
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "session started, parsing journal")); }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            clearInitPanel();
            homePanel.BringToFront();
            dividerPanel.BringToFront();
        }

        private void combatButton_Click(object sender, EventArgs e)
        {
            clearInitPanel();
            combatPanel.BringToFront();
            dividerPanel.BringToFront();
        }

        private void explorationButton_Click(object sender, EventArgs e)
        {
            clearInitPanel();
            explorePanel.BringToFront();
            dividerPanel.BringToFront();
            Debug.WriteLine("explore button clicked");
        }

        private void welcomeLabel_TextChanged(object sender, EventArgs e)
        {
            clearInitPanel();
        }

        public void loadDetails(string bodyName, Bodies bodyList)
        {
            foreach (var body in system.bodies)
            {
                if (body.name == bodyName)
                {
                    if (body.type == "Planet")
                    {
                        planetDetailView.BringToFront();
                        bodyNameTag.Text = body.name;
                        bodyTypeTag.Text = body.subType;
                        bodyDiscoveryTag.Text = body.discoveryInfo.First<Discovery>().ToString();
                        if (body.isLandable == true) { bodyLandableTag.Text = "Yes"; } else { bodyLandableTag.Text = "No"; }
                        bodyGravityTag.Text = body.gravity.ToString() + " G";
                        bodyMassTag.Text = body.earthMasses.ToString();
                        bodyRadiusTag.Text = body.radius.ToString();
                        bodyTempTag.Text = body.surfaceTemperature.ToString() + " K";
                        if (body.surfacePressure != null) { bodyPressureTag.Text = body.surfacePressure.ToString(); } else { bodyPressureTag.Text = "None"; }
                        bodyVolcanismTag.Text = body.volcanismType;
                        bodyAtmosphereTag.Text = body.atmosphereType;

                        bodyOrbitalTag.Text = body.orbitalPeriod.ToString() + " Days";
                        bodyRotationalTag.Text = body.rotationalPeriod.ToString() + " Days";
                    }
                    else if (body.type == "Star")
                    {
                        starDetailView.BringToFront();
                        starNameTag.Text = body.name;
                        starClassTag.Text = body.subType;
                        starAgeTag.Text = body.age.ToString();
                        if (body.isScoopable == true) { starScoopableTag.Text = "Yes"; } else { starScoopableTag.Text = "No"; }
                        starSpectralClassTag.Text = body.spectralClass;
                        starLuminosityTag.Text = body.luminosity;
                        starAbsoluteMagnitutdeTag.Text = body.absoluteMagnitude.ToString();
                        starSolarMassTag.Text = body.solarMasses.ToString();
                        starSolarRadiusTag.Text = body.solarRadius.ToString();
                        starTempTag.Text = body.surfaceTemperature.ToString() + " K"; ;
                        if (body.orbitalPeriod != null) { starOrbitalTag.Text = body.orbitalPeriod.ToString(); } else { starOrbitalTag.Text = "n/a"; }
                        starRotationalTag.Text = body.rotationalPeriod.ToString() + " Days";
                    }
                }
            }
        }
        /* the following method is the basis for the method that will be employed when the player arrives at a new system for exploration. 
           it is currently awaiting the proper implementation of the exploration panel as a whole, but it was a horrible nightmare to get it
           to work for some reason so it's just going to live here until it's ready to be updated and employed
        */
        public static async Task fetchStarData(string url, CancellationToken ct = default) //thank you EDSM
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.ConnectionClose = true;
            using var response = await _client.SendAsync(request, ct).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
            await File.WriteAllTextAsync("C:\\EDHE\\res\\systemdata.json", json, ct).ConfigureAwait(false);

        }

        private static readonly HttpClient _client = new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2),
            PooledConnectionIdleTimeout = TimeSpan.FromSeconds(30),
        })
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        public void clearBodyList()
        {
            Invoke(new Action(() => bodyListPanel.Controls.Clear()));
            foreach (Label lbl in bodyListPanel.Controls)
            {
                lbl.Dispose();
            }
        }
    }
}

