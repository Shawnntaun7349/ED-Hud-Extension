using EliteJournalReader;
using EliteJournalReader.Events;
using System.Diagnostics;
using System.Reflection;
using static ED_Hud_Extension.DisplayHandler;
using static ED_Hud_Extension.NavData;
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
        private static System.Threading.Timer scanTimer;
        private static System.Threading.Timer restartTimer;
        private static System.Threading.Timer readTimer;

        //bits for the connection 'animation'
        private static System.Threading.Timer uplinkTimer;
        private static System.Threading.Timer clientTimer;
        public static string animUplinkText = "establishing uplink connection.";
        public static string animUplinkTextBase = "establishing uplink connection.";
        string animClientText = "waiting for client response.";
        public static string animClientTextBase = "waiting for client response.";
        public static string scanText = "scanning";
        public static string scanTextBase = "scanning";
        public static int animDots = 1;
        public static int conDots = 1;
        public static int steps = 1;

        //bits for notifications / status updates
        public static bool scanReset;
        public static int fsdCooldown;

        public static string statBase = "Status : ";

        public static bool detailPanelNormal;
        public static bool currentJournal = false; //is the game running? use the most recent journal
        public static bool newJournal = false; //is the game not running? wait for a new journal
        public static bool watcherLive = false; //has the watcher already been initialized? [don't do it twice things break]
        public static StatusReader statReader = new StatusReader();


        public static ShipFlag _flag = new ShipFlag();
        public SystemData systemData = new SystemData();
        private readonly UpdateService updateService = new UpdateService(new UpdateService.GitHubUpdateChecker());


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

            DoubleBuffered = true;

            loadSettings();
            if (capiEnabled)
            {
                try
                {
                    OAuth2 auth = new OAuth2();
                    auth.Refresh();
                    capiConnected = true;
                }
                catch
                {
                    MessageBox.Show("Frontier cAPI Authorization Error", "Authorization with Frontier's cAPI has encountered an error, please re-authorize manually.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    capiConnected = false;
                    return;
                }
            }

            if (statusEnabled) { statusLabel.Visible = true; }

            StartPosition = FormStartPosition.Manual;
            Location = location; //this is thisForm.Location property being set to the Globals.location value
            Size = formSize;

            uplinkTimer = new System.Threading.Timer(animCallbackMethod, "Timer State", 500, 1000);
            clientTimer = new System.Threading.Timer(clientCallbackMethod, "Timer State", Timeout.Infinite, Timeout.Infinite);
            scanTimer = new System.Threading.Timer(scanCallbackMethod, "Timer State", Timeout.Infinite, Timeout.Infinite);

            dividerPanel.Visible = false;

            oxaniumFont.AddFontFile("C:\\EDHE\\res\\Oxanium\\Oxanium-Bold.ttf");

            if (statusEnabled) { statusLabel.Text = statBase + ("mainform initialized, timers started, settings loaded\n"); }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _ = updateService.CheckForUpdatesAsync(silent: true);

            resizePanels(initPanel); //resize all the shit
            resizePanels(dividerPanel);
            resizeControlsPanel(controlsPanel);
            resizeControlsPanel(constDisplayPanel);
            setWorkingArea(workingAreaPanel);
            workingAreaPanel.Visible = false;
            initPanel.BringToFront();

            mainFormLoaded = true;
            if (statusEnabled) { statusLabel.Text = statBase + "initiating service"; }
            localTimer = new System.Threading.Timer(localCallbackMethod, "Timer State", 100, 250);

            //1286 year offset
            locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm");
            starDateTag.Text = DateTime.UtcNow.ToString("dddd, MMMM dd,") + " " + ((int)DateTime.UtcNow.Year + 1286).ToString();
            starTimeTag.Text = DateTime.UtcNow.ToString("HH:mm");

            verLabel.Text = "version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (!inMainMenu()) //if the game is already running when EDHE spins up, also if we're not in the main menu (status Flag1 reads 0 until player loads into game proper) 
            {
                initiateWatcher();
                currentJournal = true;
                if (statusEnabled) { statusLabel.Text = statBase + "mainform loaded, game is running"; }
                clearInitPanel();
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
        public static ShipFlag sf = new ShipFlag();
        public static OnFootFlag ff = new OnFootFlag();

        private void initiateWatcher()
        {
            statusLabel.Visible = statusEnabled;

            watcherLive = true;
            watcher.Path = journalPath;
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "initiating journal watcher")); }

            watcher.StartWatching(); //start the watcher to monitor for events
            readTimer = new System.Threading.Timer(readTimerCallback, "Timer State", 50, 50);

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
            watcher.GetEvent<ShutdownEvent>().Fired += gameShutDownEvent;

            //refueling
            watcher.GetEvent<RefuelAllEvent>().Fired += refuelAllEvent;
            watcher.GetEvent<RefuelPartialEvent>().Fired += refuelPartialEvent;

            //scanning
            watcher.GetEvent<ScanEvent>().Fired += scanEvent;
            watcher.GetEvent<ShipTargetedEvent>().Fired += shipTargetedEvent;

            //fsd events
            watcher.GetEvent<FSDTargetEvent>().Fired += fsdTargetEvent;
            watcher.GetEvent<FSDJumpEvent>().Fired += fsdJumpEvent;
            watcher.GetEvent<StartJumpEvent>().Fired += fsdStartJumpEvent;

            //nav events
            watcher.GetEvent<NavRouteClearEvent>().Fired += navClearedEvent;

            //on foot events
            watcher.GetEvent<SuitLoadoutEvent>().Fired += suitLoadoutEvent;
            //backpack events
            watcher.GetEvent<BackpackEvent>().Fired += backpackEvent;
            watcher.GetEvent<BackpackChangeEvent>().Fired += backpackChangeEvent;
            watcher.GetEvent<UseConsumableEvent>().Fired += useConsumableEvent;
            watcher.GetEvent<CollectItemsEvent>().Fired += collectItemsEvent;

            //srv / vessel events
            watcher.GetEvent<LaunchSRVEvent>().Fired += launchSrvEvent;
            watcher.GetEvent<LaunchVesselEvent>().Fired += launchVesselEvent;
            watcher.GetEvent<DockSRVEvent>().Fired += dockSrvEvent;

            //ship events
            watcher.GetEvent<ShipyardSwapEvent>().Fired += shipyardSwapEvent;
            watcher.GetEvent<LoadoutEvent>().Fired += loadoutEvent;
            watcher.GetEvent<EmbarkEvent>().Fired += embarkEvent;
            watcher.GetEvent<DisembarkEvent>().Fired += disembarkEvent;
        }

        //journal events
        private void newJournalMethod(object? sender, NewJournalFileEvent.NewJournalFileEventArgs e) //fires on startup
        {
            newJournal = true;
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "new journal file generated, initiating reader")); }
        }

        private void loadInitialData(object? sender, LoadGameEvent.LoadGameEventArgs e) //fires on startup
        {
            if (newJournal) { if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "new journal generated, parsing")); } }
            else { if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "current journal identified, parsing")); } }

            Invoke(new Action(() => linkLabel.Enabled = true));
            Invoke(new Action(() => linkLabel.ForeColor = Color.FromArgb(192, 64, 0)));
            Invoke(new Action(() => linkLabel.Text = "uplink established"));

            Invoke(new Action(() => cmdrNameTag.Text = e.Commander));
            currentFuelLevel = e.FuelLevel;
            maxFuelLevel = e.FuelCapacity;
            pShipName = e.ShipName;
            pShipID = e.ShipIdent;

            if (e.Ship_Localised != null) { pShipType = e.Ship_Localised; }
            else { pShipType = convertName(e.Ship); }

            gameMode = e.GameMode.ToString();

            pCreditBalance = e.Credits;
            pLoan = e.Loan;

            string pCreditBalanceFormatted = string.Format("{0:N0}", pCreditBalance);
            string pLoanBalanceFormatted = string.Format("{0:N0}", pLoan);
            Invoke(new Action(() => homeCredBalanceTag.Text = pCreditBalanceFormatted));

            if (pLoan == 0) { Invoke(new Action(() => homeLBTag.Text = "None")); }
            else { Invoke(new Action(() => homeLBTag.Text = pLoanBalanceFormatted)); }

            if (StatusTags.OnFoot)
            {
                Invoke(new Action(() => curVesselTag.Text = "-embark to reestablish vessel uplink-"));
                Invoke(new Action(() => curVesselNameTag.Text = "-waiting for embarkation-"));
                Invoke(new Action(() => curVesselIDTag.Text = "-waiting for embarkation-"));
                Invoke(new Action(() => curShipFuelTag.Text = "-waiting for embarkation-"));
            }
            else
            {
                if (e.Ship_Localised != null)
                {
                    Invoke(new Action(() => curVesselTag.Text = e.Ship_Localised.ToString()));
                    motherShip = e.Ship_Localised;
                }
                else
                {
                    Invoke(new Action(() => curVesselTag.Text = convertName(e.Ship)));
                    motherShip = curVesselTag.Text;
                }

                Invoke(new Action(() => curVesselNameTag.Text = e.ShipName));
                Invoke(new Action(() => curVesselIDTag.Text = e.ShipIdent));
                Invoke(new Action(() => curShipFuelTag.Text = (currentFuelLevel + " / " + maxFuelLevel)));

                Invoke(new Action(() => homeLSTag.Text = "scanning..."));
                Invoke(new Action(() => homeSysTag.Text = "scanning..."));

                Invoke(new Action(() => fetchNavRoute(expCurrentSystemTag, expDestinationTag, this)));
            }
        }

        private void rankEvent(object? sender, RankEvent.RankEventArgs e) //fires on startup
        {
            pCombatRank = eliteTier(e.Combat);
            pExploreRank = eliteTier(e.Explore);
            pTradeRank = eliteTier(e.Trade);
            pArenaRank = eliteTier(e.CQC);
            pExoBioRank = eliteTier(e.Exobiologist);
            pMercRank = eliteTier(e.Soldier);
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



            Invoke(new Action(() => combatSysAllegianceTag.Text = systemAllegiance));
            Invoke(new Action(() => combatSysGovTag.Text = systemGovernment));
            Invoke(new Action(() => combatSysSecTag.Text = systemSecurity));
            if (this.InvokeRequired) { BeginInvoke(new Action(() => updateLocationData(pCurrentSystem))); }
            else { updateLocationData(pCurrentSystem); }
        }

        private void embarkEvent(object? sender, EmbarkEvent.EmbarkEventArgs e) //get on the ship/srv/slv
        {

        }

        private void disembarkEvent(object? sender, DisembarkEvent.DisembarkEventArgs e) //get off the ship/srv/slv
        {

        }

        private void underAttackEvent(object? sender, UnderAttackEvent.UnderAttackEventArgs e) //take a fucken guess what this one's for
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
                animDots = 1;
                scanTimer = new System.Threading.Timer(scanCallbackMethod, "Timer State", 0, 500);

                if (e.TargetLocked)
                {
                    targetLocked = true; Invoke(new Action(() => targetDataLabel.Text = "Target Data [Current]"));

                    //clear out the old data
                    foreach (Label lbl in combatPanel.Controls.OfType<Label>().Where(lbl => lbl.Tag != null && lbl.Tag.ToString() == "combatTag"))
                    {
                        Invoke(new Action(() => lbl.Text = "[awaiting scan]"));
                        Invoke(new Action(() => lbl.ForeColor = Color.White));
                    }

                    if (e.Ship_Localised != null) //some ships have Ship:"[ship-name] Ship_Localised:"[in-game ship-name]". Why. But I ask again, why.
                    {
                        targetShip = e.Ship_Localised;
                        Invoke(new Action(() => targetShipTag.Text = targetShip.ToString()));
                    }
                    else
                    {
                        targetShip = convertName(e.Ship);
                        Invoke(new Action(() => targetShipTag.Text = targetShip.ToString()));
                    }
                    scanLevel = e.ScanStage;
                }
                else
                {
                    scanLevel = e.ScanStage;
                    targetLocked = false;
                    scanDone = false;
                    scanTimer.Dispose();
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
                    scanTimer.Dispose();
                    targetFaction = e.Faction;
                    targetPower = e.Power;

                    targetLegal = e.LegalStatus;
                    targetBounty = e.Bounty;
                    int totalBounty = 0;

                    Invoke(new Action(() => scanStageTag.Text = "Target Locked"));

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
                        totalBounty += (int)e.Bounty;
                        Invoke(new Action(() => targetLegalStatusTag.ForeColor = Color.DarkRed));
                        if (totalBounty != (int)e.Bounty && totalBounty + (int)e.Bounty > totalBounty) //and they're wanted elsewhere
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

        private void fsdTargetEvent(object? sender, FSDTargetEvent.FSDTargetEventArgs e)
        {
            if (e.Timestamp > startUpTime)
            {
                Invoke(new Action(() => fetchNavRoute(expNextSystemTag, expDestinationTag, this)));
                if (routeLength == 0)
                {
                    Invoke(new Action(() => expNextSystemTag.Text = e.Name));
                    Invoke(new Action(() => expDestinationTag.Text = e.Name));
                }
            }
            else { /*ignore the event as it occured before edhe started*/ }
        }

        private void fsdStartJumpEvent(object? sender, StartJumpEvent.StartJumpEventArgs e) //fires when the player starts a star-to-star jump, or when entering supercruise
        {
            if (e.Timestamp > startUpTime)
            {
                //Invoke(new Action(() => fsdTag.Text = "engaging"));
            }
            else { /*ignore the event as it occured before edhe started*/ }
        }

        private void fsdJumpEvent(object? sender, FSDJumpEvent.FSDJumpEventArgs e)
        {
            pCurrentSystem = e.StarSystem.ToString();

            Invoke(new Action(() => expCurrentSystemTag.Text = pCurrentSystem));

            Invoke(new Action(() => clearBodyList()));
            Invoke(new Action(() => updateLocationData(pCurrentSystem)));

            if (routeActive) { Invoke(new Action(() => updateRoute(expNextSystemTag, expDestinationTag))); }

            //if (StatusTags.Supercruise) { Invoke(new Action(() => fsdTag.Text = "supercruise")); }
        }

        private void navClearedEvent(object? sender, NavRouteClearEvent.NavRouteClearEventArgs e)
        {
            if (e.Timestamp > startUpTime)
            {
                Invoke(new Action(() => expNextSystemTag.Text = "none"));
                Invoke(new Action(() => expDestinationTag.Text = "none"));
                clearRoute();
            }
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

        private void gameShutDownEvent(object? sender, ShutdownEvent.ShutdownEventArgs e)
        {
            if (!initPanel.Visible) //if the init panel is visible, that means we're just adjusting animations, no need to flag the user yet
            {
                if (autoShutDownEnabled && e.Timestamp > startUpTime)
                {
                    Invoke(new Action(() => MessageBox.Show(this, "Elite Dangerous has shut down. EDHE will now shut down.", "Shutting Down", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                    System.Windows.Forms.Application.Exit();
                }
                else if (e.Timestamp > startUpTime)
                {
                    Invoke(new Action(() => MessageBox.Show(this, "Elite Dangerous has shut down. EDHE will remain operational in a limited capacity until the game client is restarted.", "Uplink Lost", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                    Invoke(new Action(() => linkLabel.Text = "uplink lost"));
                    Invoke(new Action(() => linkLabel.ForeColor = Color.DarkRed));
                    restartTimer = new System.Threading.Timer(waitForRestart, "Timer State", 1000, 100);
                }
            }
            else { /*do nothing*/ }
        }

        private void suitLoadoutEvent(object? sender, SuitLoadoutEvent.SuitLoadoutEventArgs e)
        {
            //update the landing page data
            Invoke(new Action(() => curVesselTag.Text = "-embark to reestablish vessel uplink-"));
            Invoke(new Action(() => curVesselNameTag.Text = "-waiting for embarkation-"));
            Invoke(new Action(() => curVesselIDTag.Text = "-waiting for embarkation-"));
            Invoke(new Action(() => curShipFuelTag.Text = "-waiting for embarkation-"));

            //do a whole bunch of shit pertaining to suit loadout data
            //suit name and mods list
            Invoke(new Action(() => equippedSuitTag.Text = convertName(e.SuitName)));
            string suitModList = "";
            foreach (string mod in e.SuitMods)
            {
                if (!suitModList.Contains(mod))
                {
                    suitModList += convertName(mod) + ",  ";
                }
            }
            if (suitModList.Length != 0)
            { suitModList = suitModList.TrimEnd(',', ' ') + "."; }
            else { suitModList = "-none-"; }
            Invoke(new Action(() => suitModsTag.Text = suitModList));

            int weaponCount = e.Modules.Length;
            if (equippedSuitTag.Text.Contains("Dominator")) //if they've got three weapon slots
            {
                //adjust the weapon label set
                Invoke(new Action(() => weaponOneLabel.Text = "Primary Slot 1 : "));
                Invoke(new Action(() => weaponTwoLabel.Text = "Primary Slot 2 : "));
                Invoke(new Action(() => weaponThreeLabel.Text = "Secondary Slot : "));
                Invoke(new Action(() => weaponThreeModsLabel.Text = "Weapon Mods : "));

            }
            else //if they've only got two weapon slots
            {
                //adjust the labels, hide the third set
                Invoke(new Action(() => weaponOneLabel.Text = "Primary Slot : "));
                Invoke(new Action(() => weaponTwoLabel.Text = "Secondary Slot : "));
                Invoke(new Action(() => weaponThreeLabel.Text = ""));
                Invoke(new Action(() => weaponThreeTag.Text = ""));
                Invoke(new Action(() => weaponThreeModsLabel.Text = ""));
                Invoke(new Action(() => weaponThreeModTag.Text = ""));
            }
            //weapon one name and mods list
            if (e.Modules.Length >= 1)
            {
                //it's the same principle for all equipped weapons: get the weapon name, grade, & mod list
                Invoke(new Action(() => weaponOneTag.Text = e.Modules[0].ModuleName_Localised + ", Grade " + e.Modules[0].Class));

                string weaponOneModList = "";
                foreach (string mod in e.Modules[0].WeaponMods) //make a list of the weapon's mods
                {
                    if (!weaponOneModList.Contains(convertName(mod))) //if the mod list for this weapon doesn't have this mod, add it
                    { weaponOneModList += convertName(mod) + ",  "; } //importantly, a weapon cannot have multiples of a mod, so neither can our list
                }
                if (weaponOneModList.Length != 0) //okey dokey if our mod list does, in fact, have mods: tidy it up so we can show the user
                { weaponOneModList = weaponOneModList.TrimEnd(',', ' ') + "."; }
                else { weaponOneModList = "-none-"; } //if it has no mods, drop the whole thing n just show a clean [ -none- ] as opposed to an empty list. empty lists look like a bug
                Invoke(new Action(() => weaponOneModTag.Text = weaponOneModList)); //display our masterfully crafted mods list
            }
            else { Invoke(new Action(() => weaponTwoModTag.Text = "-none-")); Invoke(new Action(() => weaponTwoTag.Text = "-none-")); } //if they don't have a weapon in slot, see above note about empty lists

            //rinse and repeat
            //weapon two name and mods list
            if (e.Modules.Length >= 2)
            {
                Invoke(new Action(() => weaponTwoTag.Text = e.Modules[1].ModuleName_Localised + ", Grade " + e.Modules[1].Class));

                string weaponTwoModList = "";
                foreach (string mod in e.Modules[1].WeaponMods)
                {
                    if (!weaponTwoModList.Contains(convertName(mod)))
                    { weaponTwoModList += convertName(mod) + ",  "; }
                }
                if (weaponTwoModList.Length != 0)
                { weaponTwoModList = weaponTwoModList.TrimEnd(',', ' ') + "."; }
                else { weaponTwoModList = "-none-"; }
                Invoke(new Action(() => weaponTwoModTag.Text = weaponTwoModList));
            }
            else { Invoke(new Action(() => weaponTwoModTag.Text = "-none-")); Invoke(new Action(() => weaponTwoTag.Text = "-none-")); }

            if (e.Modules.Length == 3)
            {
                //weapon three name and mods list
                Invoke(new Action(() => weaponThreeTag.Text = e.Modules[2].ModuleName_Localised + ", Grade " + e.Modules[2].Class));

                string weaponThreeModList = "";
                foreach (string mod in e.Modules[2].WeaponMods)
                {
                    if (!weaponThreeModList.Contains(convertName(mod)))
                    { weaponThreeModList += convertName(mod) + ",  "; }
                }
                if (weaponThreeModList.Length != 0)
                { weaponThreeModList = weaponThreeModList.TrimEnd(',', ' ') + "."; }
                else { weaponThreeModList = "-none-"; }
                Invoke(new Action(() => weaponThreeModTag.Text = weaponThreeModList));
            }
            else { Invoke(new Action(() => weaponThreeModTag.Text = "")); Invoke(new Action(() => weaponThreeTag.Text = "")); }
        }

        private void launchVesselEvent(object? sender, LaunchVesselEvent.LaunchVesselEventArgs e)
        {
            //despite the fact that the player can assign Designations & Callsigns to SLVs, the journal won't actually offer them in the output
            Invoke(new Action(() => curVesselTag.Text = "SLV"));
            Invoke(new Action(() => curVesselNameTag.Text = e.VesselType_Localised));
            Invoke(new Action(() => curVesselIDTag.Text = e.ID.ToString()));
        }

        private void launchSrvEvent(object? sender, LaunchSRVEvent.LaunchSRVEventArgs e)
        {
            Invoke(new Action(() => curVesselTag.Text = "SRV"));
            Invoke(new Action(() => curVesselNameTag.Text = e.SRVType_Localised));
            Invoke(new Action(() => curVesselIDTag.Text = e.ID.ToString()));
        }

        private void dockSrvEvent(object? sender, DockSRVEvent.DockSRVEventArgs e)
        {
            Invoke(new Action(() => curVesselTag.Text = motherShip)); //update the displayed name, the rest will come from the Loadout event that fires next
        }

        private void shipyardSwapEvent(object? sender, ShipyardSwapEvent.ShipyardSwapEventArgs e) //gives the localised Ship Type data
        {
            if (e.ShipType_Localised != null) { Invoke(new Action(() => curVesselTag.Text = e.ShipType_Localised)); } //ship type
            else { Invoke(new Action(() => curVesselTag.Text = convertName(e.ShipType))); }
            motherShip = curVesselTag.Text;
        }

        private void loadoutEvent(object? sender, LoadoutEvent.LoadoutEventArgs e) //gives the Ship Name & Identifier / Callsign
        {
            Invoke(new Action(() => curVesselNameTag.Text = e.ShipName));
            Invoke(new Action(() => curVesselIDTag.Text = e.ShipIdent));

            string fuel = e.FuelCapacity.Main.ToString();
            Invoke(new Action(() => curShipFuelTag.Text = fuel + " / " + fuel));
        }

        private void backpackEvent(object? sender, BackpackEvent.BackpackEventArgs e) //establish the initial backpack loadout
        {
            foreach (Consumable c in e.Consumables)
            {
                if (c.Name == "healthpack")
                {
                    healthPackCount = c.Count;
                    Invoke(new Action(() => healthPackTag.Text = c.Count + " / 2"));
                }
                if (c.Name == "energycell")
                {
                    energyCellCount = c.Count;
                    Invoke(new Action(() => energyCellTag.Text = c.Count + " / 2"));
                }
                if (c.Name == "amm_grenade_frag")
                {
                    fragGrenadeCount = c.Count;
                    Invoke(new Action(() => fragGrenadeTag.Text = c.Count + " / 3"));
                }
                if (c.Name == "amm_grenade_emp")
                {
                    empCount = c.Count;
                    Invoke(new Action(() => empTag.Text = c.Count + " / 3"));
                }
                if (c.Name == "amm_grenade_shield")
                {
                    shieldProjectorCount = c.Count;
                    Invoke(new Action(() => shieldProjectorTag.Text = c.Count + " / 2"));
                }
            }
        }

        private void backpackChangeEvent(object? sender, BackpackChangeEvent.BackpackChangeEventArgs e) //only way to track *used* grenades, because of course it is
        {
            if (e.Removed is not null) //if the change is removing an item
            {
                //check for the grenades, healthpacks & energy cells have their own event. for some reason.
                if (e.Removed[0].Name == "amm_grenade_frag")
                {
                    fragGrenadeCount--;
                    Invoke(new Action(() => fragGrenadeTag.Text = fragGrenadeCount + " / 3"));
                }
                if (e.Removed[0].Name == "amm_grenade_emp")
                {
                    empCount--;
                    Invoke(new Action(() => empTag.Text = empCount + " / 3"));
                }
                if (e.Removed[0].Name == "amm_grenade_shield")
                {
                    shieldProjectorCount--;
                    Invoke(new Action(() => shieldProjectorTag.Text = shieldProjectorCount + " / 2"));
                }
            }
        }

        private void collectItemsEvent(object? sender, CollectItemsEvent.CollectItemsEventArgs e) //this covers any item the player collects, but for now it's just combat stuff
        {
            if (e.Timestamp > startUpTime)
            {
                if (e.Name == "healthpack")
                {
                    healthPackCount++;
                    Invoke(new Action(() => healthPackTag.Text = healthPackCount + " / 2"));
                }
                if (e.Name == "energycell")
                {
                    energyCellCount++;
                    Invoke(new Action(() => energyCellTag.Text = energyCellCount + " / 2"));
                }
                if (e.Name == "amm_grenade_frag")
                {
                    fragGrenadeCount++;
                    Invoke(new Action(() => fragGrenadeTag.Text = fragGrenadeCount + " / 3"));
                }
                if (e.Name == "amm_grenade_emp")
                {
                    empCount++;
                    Invoke(new Action(() => empTag.Text = empCount + " / 3"));
                }
                if (e.Name == "ammm_grenade_shield")
                {
                    shieldProjectorCount++;
                    Invoke(new Action(() => shieldProjectorTag.Text = shieldProjectorCount + " / 2"));
                }
            }
        }

        private void useConsumableEvent(object? sender, UseConsumableEvent.UseConsumableEventArgs e) //no grenades, for some reason. don't eat grenades kids
        {
            if (e.Name == "healthpack")
            {
                healthPackCount--;
                Invoke(new Action(() => healthPackTag.Text = healthPackCount + " / 2"));
            }
            if (e.Name == "energycell")
            {
                energyCellCount--;
                Invoke(new Action(() => energyCellTag.Text = energyCellCount + " / 2"));
            }
        }

        // --------------------- Home panel methods ---------------------
        //timer methods
        private void localCallbackMethod(object state)
        {
            Invoke(new Action(() => locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm")));
            Invoke(new Action(() => starDateTag.Text = DateTime.UtcNow.ToString("dddd, MMMM dd,") + " " + ((int)DateTime.UtcNow.Year + 1286).ToString()));
            Invoke(new Action(() => starTimeTag.Text = DateTime.UtcNow.ToString("HH:mm")));
        }

        public void readTimerCallback(object? sender) //update status information
        {
            try
            {
                readStatus(Path.Combine(journalPath, "Status.json"), sf, ff);
                statusReaderLive = true;

            }
            catch (IOException)
            {
                System.Windows.Forms.Timer waitTimer = new System.Windows.Forms.Timer();
                waitTimer.Interval = 25;
                waitTimer.Tick += (s, args) =>
                {
                    waitTimer.Stop();
                    readStatus(Path.Combine(journalPath, "Status.json"), sf, ff);
                };
                waitTimer.Start();
            }

            if (StatusTags.FsdCooldown) { Invoke(new Action(() => fsdTag.Text = "cooling down")); }
            else if (StatusTags.FsdCharging) { Invoke(new Action(() => fsdTag.Text = "charging")); }
            else if (StatusTags.FsdMassLocked) { Invoke(new Action(() => fsdTag.Text = "mass locked")); }
            else if (StatusTags.FsdJump) { Invoke(new Action(() => fsdTag.Text = "jumping")); }
            else { Invoke(new Action(() => fsdTag.Text = "ready")); }

            if (StatusTags.OnFoot) { Invoke(new Action(() => onFootPanel.Visible = true)); }
            if (!StatusTags.OnFoot) { Invoke(new Action(() => onFootPanel.Visible = false)); }

            if (StatusTags.OnFoot) //load up the on foot stuff
            {
                Invoke(new Action(() => healthBar.Value = pFootHealth));
                Invoke(new Action(() => oxygenBar.Value = pFootOxygen));

                Invoke(new Action(() => healthpackKeyTag.Text = "Keybind [" + healthPackKey + "]"));
                Invoke(new Action(() => energyCellKeyTag.Text = "Keybind [" + energyCellKey + "]"));
                Invoke(new Action(() => fragGrenadeKeyTag.Text = "Keybind [" + fragGrenadeKey + "]"));
                Invoke(new Action(() => empKeyTag.Text = "Keybind [" + empKey + "]"));
                Invoke(new Action(() => shieldProjectorKeyTag.Text = "Keybind [" + shieldProjectorKey + "]"));
            }
        }

        private bool clientAnimUp = false;

        //'animation' methods
        private void animCallbackMethod(object state) //first three messages, plus [establishing uplink...] method
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
                    Invoke(new Action(() => uplinkLabel.Visible = true));
                    steps++;
                    animDots = 1;
                    uplinkTimer.Change(500, 500);
                }
                else if (!clientAnimUp)// [...] animation loop that runs while waiting for the player to enter the game proper
                {
                    if (animDots < 3) //if that string has less than 3 periods
                    {
                        animUplinkText = animUplinkText + ".";
                        Invoke(new Action(() => uplinkLabel.Text = animUplinkText));
                        animDots++;
                    }
                    else//if that string has all 3 periods, reset it back to one.
                    {
                        animUplinkText = animUplinkTextBase;
                        Invoke(new Action(() => uplinkLabel.Text = animUplinkText));
                        animDots = 1;

                        if (gameRunning()) //while we're here, check to see if the game is running
                        {
                            initiateWatcher();
                            //loadCapiData();

                            Invoke(new Action(() => uplinkLabel.Text = "establishing uplink connection..."));
                            Invoke(new Action(() => uplinkDone.Visible = true));
                            Invoke(new Action(() => clientLabel.Visible = true));
                            animDots = 1;

                            clientAnimUp = true;

                            uplinkTimer.Change(50, Timeout.Infinite); //pause the timer immediately
                            clientTimer.Change(500, 500); //start the next timer

                            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "moving to trigger client timer")); }
                        }
                    }
                }
            }
        }

        private void clientCallbackMethod(object state) //[waiting for client response...] timer
        {
            if (mainFormLoaded) //sometimes the timers (this timer) load(s) before the form is properly displayed, so we gotta check
            {
                if (animDots < 3) //runs if there are less than three dots in the animation string and the client's not ready
                {
                    animClientText = animClientText + ".";
                    Invoke(new Action(() => clientLabel.Text = animClientText));
                    animDots++;

                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "client loaded, waiting for game start [anim 1]")); }
                }
                else if (animDots == 3 && inMainMenu()) //if we reach 3 dots we're still in the main menu
                {
                    if (gameRunning()) //if the game is still running just reset the loop
                    {
                        bool doubleCheck = inMainMenu();

                        if (doubleCheck == false) { Invoke(new Action(() => clearInitPanel())); }

                        animClientText = animClientTextBase;
                        Invoke(new Action(() => clientLabel.Text = animClientText));
                        animDots = 1;
                    }
                    else //the game shut down while waiting
                    {
                        clientTimer.Change(Timeout.Infinite, Timeout.Infinite); //pause this timer

                        Invoke(new Action(() => clientLabel.Visible = false)); //hide the other labels
                        Invoke(new Action(() => clientDone.Visible = false));
                        Invoke(new Action(() => uplinkDone.Visible = false));

                        //reset the anim components
                        animUplinkText = animUplinkTextBase;
                        Invoke(new Action(() => uplinkLabel.Text = animUplinkText));
                        animDots = 1;

                        clientAnimUp = false;

                        uplinkTimer.Change(500, 500); //restart the 'waiting for the game' timer
                    }

                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "client loaded, waiting for game start [anim 2]")); }
                }
                else if (!inMainMenu() && gameRunning()) //if we've reached 3 dots, the client is ready & we're not in the main menu
                {
                    Invoke(new Action(() => clientLabel.Text = "waiting for client response..."));
                    Invoke(new Action(() => clientDone.Visible = true));
                    if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "client established, loading landing page")); }
                    Invoke(new Action(() => clearInitPanel()));
                }
            }
        }

        public void loadCapiData()
        {
            if (capiEnabled == true && capiConnected == false && capiFailed == false)
            {
                try
                {
                    capiConnected = true;
                    var auth = new OAuth2(); //establish the CAPI connection
                    auth.Refresh(); //refresh the token data cos them shits are short lived

                }
                catch { capiConnected = false; capiFailed = true; } //if something breaks, mark this bool so we don't spam requests
            }
            else //either this was called despite being disabled, it's already connected, or it already failed
            {
                return;
            }
        }

        //TODO : fix this for a [scanning...] anim while scanning a target
        private void scanCallbackMethod(object sender)
        {
            if (scanDone) //if the scan is done fuck off
            {
                scanTimer.Dispose();
                return;
            }
            else
            {
                if (animDots < 3)
                {
                    scanText = scanText + ".";
                    Invoke(new Action(() => scanStageTag.Text = scanText));
                    animDots++;
                }
                else
                {
                    scanText = scanTextBase;
                    Invoke(new Action(() => scanStageTag.Text = scanText));
                    animDots = 1;
                }
            }
        }

        private void clearInitPanel()
        {
            animDots = 1;
            uplinkTimer.Dispose();
            workingAreaPanel.Visible = true;
            initPanel.Dispose();
            clientTimer.Dispose();
            homePanel.BringToFront();
            controlsPanel.BringToFront();
            dividerPanel.BringToFront();
            dividerPanel.Visible = true;
            constDisplayPanel.BringToFront();

            foreach (Control c in Controls)
            {
                if (c.Tag == "uiButtons")
                {
                    c.Enabled = true;
                    c.Visible = true;
                }
            }
            if (statusEnabled) { Invoke(new Action(() => statusLabel.Text = statBase + "session started, parsing journal")); }
        }

        // button methods

        private void restartSessionButton_Click(object sender, EventArgs e) //used to manually reset the player's session if it doesn't reset automatically
        {
            Invoke(new Action(() => MessageBox.Show(this, "EDHE will now restart.", "Restart Initiated", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            //Invoke(new Action(() => uplinkLowTag.Visible = true));
            //Invoke(new Action(() => uplinkHighTag.Visible = false));
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
                localTimer.Dispose(); //not strictly necessary but if you exit via button in the IDE build this will ocasionally throw an error
                Environment.Exit(0);
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            homePanel.BringToFront();
            dividerPanel.BringToFront();
        }

        private void combatButton_Click(object sender, EventArgs e)
        {
            arrangeCombatPanel(combatPanel, onFootPanel);
            scanStageLabel.Location = new Point(((workingAreaPanel.Width / 2) - scanStageLabel.Width) + 118, scanStageLabel.Location.Y);
            scanStageTag.Location = new Point((workingAreaPanel.Width / 2) + 108, scanStageTag.Location.Y);
            combatPanel.BringToFront();
            dividerPanel.BringToFront();
        }

        private void explorationButton_Click(object sender, EventArgs e)
        {
            arrangeExplorePanel(explorePanel); //196 apart
            fsdLabel.Location = new Point(((fsdLabel.Parent.Width / 2) - fsdLabel.Width) + 118, fsdLabel.Location.Y);
            fsdTag.Location = new Point((fsdTag.Parent.Width / 2) + 108, fsdTag.Location.Y);
            selectBodyLabel.Location = new Point((detailHiderPanel.Width / 2) - (selectBodyLabel.Width / 2) + 28, selectBodyLabel.Location.Y);
            beltDivPanel.Size = new Size(beltDivPanel.Parent.Width, beltDivPanel.Height);

            detailChangeButton.Location = new Point((workingAreaPanel.Width - (planetDetailView.Width + detailChangeButton.Width + 5)), workingAreaPanel.Height - detailChangeButton.Height);

            resetDetailView(planetDetailView, starDetailView);
            explorePanel.BringToFront();
            detailHiderPanel.BringToFront();
            detailChangeButton.Visible = false;
        }
        private void stationButton_Click(object sender, EventArgs e)
        {
            stationsPanel.BringToFront();
            dividerPanel.BringToFront();
        }

        private void missionsButton_Click(object sender, EventArgs e)
        {
            missionsPanel.BringToFront();
            dividerPanel.BringToFront();
        }

        //background functions
        private void waitForRestart(object? sender)
        {
            if (gameRunning())
            {
                Invoke(new Action(() => linkLabel.Text = "uplink established"));
                Invoke(new Action(() => linkLabel.ForeColor = Color.FromArgb(192, 64, 0)));
                restartTimer.Change(0, Timeout.Infinite);
            }
            else return;
        }

        public void loadDetails(string bodyName, Bodies bodyList)
        {
            clearDetails(starDetailView);
            clearDetails(planetDetailView);

            if (system.bodies is not null)
            {
                foreach (var body in system.bodies)
                {
                    if (body.name == bodyName)
                    {
                        if (body.belts == null) { beltCountTag.Text = "none"; }
                        else if (body.belts.Count == 1) { beltCountTag.Text = "1 belt"; }
                        else { beltCountTag.Text = body.belts.Count.ToString() + " belts"; }

                        if (body.rings == null) { ringCountTag.Text = "none"; }
                        else if (body.rings.Count == 1) { beltCountTag.Text = "1 ring"; }
                        else { ringCountTag.Text = body.rings.Count.ToString() + " rings"; }

                        if (body.type == "Planet")
                        {
                            detailChangeButton.Visible = true;

                            planetDetailView.BringToFront();
                            bodyNameTag.Text = body.name;
                            bodyTypeTag.Text = body.subType;
                            if (body.discovery != null) { bodyDiscoveryTag.Text = body.discovery.commander; } else { bodyDiscoveryTag.Text = "n/a"; }
                            bodyTempTag.Text = body.surfaceTemperature.ToString() + " K";
                            if (body.isLandable == true) { bodyLandableTag.Text = "Yes"; } else { bodyLandableTag.Text = "No"; }
                            bodyGravityTag.Text = body.gravity.ToString() + " G";
                            bodyMassTag.Text = body.earthMasses.ToString();
                            bodyRadiusTag.Text = body.radius.ToString();
                            if (body.surfacePressure != null) { bodyPressureTag.Text = body.surfacePressure.ToString(); } else { bodyPressureTag.Text = "None"; }
                            bodyVolcanismTag.Text = body.volcanismType;
                            bodyAtmosphereTag.Text = body.atmosphereType;

                            if (body.solidComposition != null)
                            {
                                rockTag.Text = string.Concat(body.solidComposition.rock.ToString(), " %");
                                metalTag.Text = string.Concat(body.solidComposition.metal.ToString(), " %");
                                iceTag.Text = string.Concat(body.solidComposition.ice.ToString(), " %");
                            }

                            if (body.atmosphereComposition != null)
                            {
                                atmosphereCompHider.Visible = false;

                                clearDetails(atmosphereCompPanel);
                                generateCompList(body.atmosphereComposition, atmosphereCompPanel);
                            }
                            else
                            {
                                atmosphereCompHider.Visible = true;

                                clearDetails(atmosphereCompPanel);
                                atmosphereCompPanel.Refresh();
                            }

                            bodyOrbitalTag.Text = Math.Round((decimal)body.orbitalPeriod, 2).ToString() + " Days";
                            bodyRotationalTag.Text = Math.Round((decimal)body.rotationalPeriod, 2).ToString() + " Days";
                        }
                        else if (body.type == "Star")
                        {
                            if (detailPanelNormal == false)
                            {
                                detailChangeButton.PerformClick();
                            }
                            detailChangeButton.Visible = false;

                            starDetailView.BringToFront();
                            starNameTag.Text = body.name;
                            if (body.discovery != null) { starDiscoverTag.Text = body.discovery.commander; } else { starDiscoverTag.Text = "n/a"; }
                            if (body.isMainStar == true) { mainStarTag.Text = "Yes"; } else { mainStarTag.Text = "No"; }
                            starClassTag.Text = body.subType;
                            starAgeTag.Text = body.age.ToString();
                            if (body.isScoopable == true) { starScoopableTag.Text = "Yes"; } else { starScoopableTag.Text = "No"; }
                            starSpectralClassTag.Text = body.spectralClass;
                            starLuminosityTag.Text = body.luminosity;
                            starAbsoluteMagnitutdeTag.Text = body.absoluteMagnitude.ToString();
                            starSolarMassTag.Text = body.solarMasses.ToString();
                            starSolarRadiusTag.Text = body.solarRadius.ToString();
                            starTempTag.Text = body.surfaceTemperature.ToString() + " K"; ;

                            if (body.orbitalPeriod != null) { starOrbitalTag.Text = Math.Round((decimal)body.rotationalPeriod, 2).ToString(); } else { starOrbitalTag.Text = "n/a"; }
                            starRotationalTag.Text = Math.Round((decimal)body.rotationalPeriod, 2).ToString() + " Days";
                        }

                        if (body.belts != null) { generateBeltList(body.belts, starDetailView); noBeltsLabel.Visible = false; }
                        else { noBeltsLabel.Visible = true; }

                        if (body.rings != null) { generateRingList(body.rings, planetDetailView); noRingsLabel.Visible = false; }
                        else { noRingsLabel.Visible = true; }

                        //if (body.atmosphere != null) { generateAtmosphere(body.atmosphere, planetDetailView); }
                    }
                }
            }
        }

        public static void clearAtmospherePanel(Panel panel)
        {
            foreach (Label lbl in panel.Controls.OfType<Label>())
            {
                if (lbl.Tag != "permanent")
                {
                    lbl.Dispose();
                }
                panel.Refresh();
            }
        }

        public static void resetDetailView(Panel panel, Panel baseline)
        {
            detailPanelNormal = true;
        }

        public static void generateCompList(Atmosphere atmosphere, Panel panel)
        {
            Point lblLoc = new Point(0, 45);
            Point tagLoc = new Point(260, 45);
            Size lblSize = new Size(255, 36);
            Size tagSize = new Size(135, 36);

            Font lblFont = new Font(oxaniumFont.Families[0], 22, FontStyle.Regular);
            Font tagFont = new Font(oxaniumFont.Families[0], 22, FontStyle.Italic);

            Color orange = ColorTranslator.FromHtml("#C04000");

            if (atmosphere.ammonia != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Ammonia : ";
                tag.Text = string.Concat(atmosphere.ammonia.ToString(), " %");

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.argon != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Argon : ";
                tag.Text = atmosphere.argon.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.carbonDioxide != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Carbon Dioxide : ";
                tag.Text = atmosphere.carbonDioxide.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.helium != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Helium : ";
                tag.Text = atmosphere.helium.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.hydrogen != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Hydrogen : ";
                tag.Text = atmosphere.hydrogen.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.iron != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Iron : ";
                tag.Text = atmosphere.iron.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.methane != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Methane : ";
                tag.Text = atmosphere.methane.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.neon != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Neon : ";
                tag.Text = atmosphere.neon.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.nitrogen != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Nitrogen : ";
                tag.Text = atmosphere.nitrogen.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.oxygen != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Oxygen : ";
                tag.Text = atmosphere.oxygen.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.silicates != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Silicates : ";
                tag.Text = atmosphere.silicates.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.sulphurDioxide != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Sulphur Dioxide : ";
                tag.Text = atmosphere.sulphurDioxide.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }
            if (atmosphere.water != 0)
            {
                Label lbl = new Label();
                Label tag = new Label();

                lbl.Text = "Water : ";
                tag.Text = atmosphere.water.ToString() + " %";

                tag.Anchor = AnchorStyles.Right;
                tag.TextAlign = ContentAlignment.TopRight;

                lbl.Tag = "label";
                tag.Tag = "tag";

                lbl.ForeColor = orange;
                tag.ForeColor = Color.White;

                lbl.Font = lblFont;
                tag.Font = tagFont;

                lbl.Location = lblLoc;
                tag.Location = tagLoc;

                lbl.Size = lblSize;
                tag.Size = tagSize;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tag);

                panel.Refresh();

                lblLoc.Y += 40;
                tagLoc.Y += 40;
            }

            panel.Refresh();
        }

        public static void generateBeltList(List<Belt> belts, Panel starPanel)
        {
            Point labelLoc = new Point(0, 610);
            Point tagLoc = new Point(303, 610);

            foreach (Belt belt in belts)
            {
                List<Label> lblList = new List<Label>();

                Label nameTag = new Label();
                lblList.Add(nameTag);

                Label typeTag = new Label();
                lblList.Add(typeTag);

                Label massTag = new Label();
                lblList.Add(massTag);

                Label radTag = new Label();
                lblList.Add(radTag);

                Label nameLabel = new Label();
                lblList.Add(nameLabel);

                Label typeLabel = new Label();
                lblList.Add(typeLabel);

                Label massLabel = new Label();
                lblList.Add(massLabel);

                Label radLabel = new Label();
                lblList.Add(radLabel);


                nameLabel.Text = "Name : ";
                nameLabel.Tag = "label";
                nameTag.Text = belt.name.ToString();
                nameTag.Tag = "tag";

                typeLabel.Text = "Type : ";
                typeLabel.Tag = "label";
                typeTag.Text = belt.type.ToString();
                typeTag.Tag = "tag";

                massLabel.Text = "Mass : ";
                massLabel.Tag = "label";
                massTag.Text = belt.mass.ToString("N0") + " tonnes";
                massTag.Tag = "tag";

                radLabel.Text = "Radius : ";
                radLabel.Tag = "label";
                radTag.Text = belt.innerRadius.ToString("N0") + " km";
                radTag.Tag = "tag";

                foreach (Label lbl in lblList)
                {
                    lbl.AutoSize = true;

                    if (lbl.Tag == "label")
                    {
                        lbl.Font = new System.Drawing.Font(oxaniumFont.Families[0], 22, FontStyle.Regular);
                        lbl.ForeColor = ColorTranslator.FromHtml("#C04000");
                        lbl.Location = labelLoc;
                        labelLoc.Y += 40;
                    }

                    if (lbl.Tag == "tag")
                    {
                        lbl.Font = new System.Drawing.Font(oxaniumFont.Families[0], 22, FontStyle.Italic);
                        lbl.ForeColor = Color.White;
                        lbl.Location = tagLoc;
                        tagLoc.Y += 40;
                    }

                    starPanel.Controls.Add(lbl);
                    starPanel.Refresh();
                }

                tagLoc.Y += 40;
                labelLoc.Y += 40;
            }
        }

        public static void generateRingList(List<Ring> rings, Panel bodyViewPanel)
        {
            Point labelLoc = new Point(0, 570);
            Point tagLoc = new Point(264, 570);

            foreach (Ring ring in rings)
            {
                List<Label> lblList = new List<Label>();

                Label nameTag = new Label();
                lblList.Add(nameTag);

                Label typeTag = new Label();
                lblList.Add(typeTag);

                Label massTag = new Label();
                lblList.Add(massTag);

                Label innerRadTag = new Label();
                lblList.Add(innerRadTag);

                Label outterRadTag = new Label();
                lblList.Add(outterRadTag);

                Label nameLabel = new Label();
                lblList.Add(nameLabel);

                Label typeLabel = new Label();
                lblList.Add(typeLabel);

                Label massLabel = new Label();
                lblList.Add(massLabel);

                Label innerRadLabel = new Label();
                lblList.Add(innerRadLabel);

                Label outterRadLabel = new Label();
                lblList.Add(outterRadLabel);


                nameLabel.Text = "Name : ";
                nameLabel.Tag = "label";
                nameTag.Text = ring.name.ToString();
                nameTag.Tag = "tag";

                typeLabel.Text = "Type : ";
                typeLabel.Tag = "label";
                typeTag.Text = ring.type.ToString();
                typeTag.Tag = "tag";

                massLabel.Text = "Mass : ";
                massLabel.Tag = "label";
                massTag.Text = ring.mass.ToString("N0") + " tonnes";
                massTag.Tag = "tag";

                innerRadLabel.Text = "Inner Radius : ";
                innerRadLabel.Tag = "label";
                innerRadTag.Text = ring.innerRadius.ToString("N0") + " km";
                innerRadTag.Tag = "tag";

                outterRadLabel.Text = "Outter Radius : ";
                outterRadLabel.Tag = "label";
                outterRadTag.Text = ring.outerRadius.ToString("N0") + " km";
                outterRadTag.Tag = "tag";

                foreach (Label lbl in lblList)
                {
                    lbl.AutoSize = true;
                    //tagAutoSize = false; tagSize = 460, 36; tagAnchor = topRight; tagTextAlign = topRight
                    if (lbl.Tag == "label")
                    {
                        lbl.Font = new System.Drawing.Font(oxaniumFont.Families[0], 22, FontStyle.Regular);
                        lbl.ForeColor = ColorTranslator.FromHtml("#C04000");
                        lbl.Location = labelLoc;
                        labelLoc.Y += 40;
                    }

                    if (lbl.Tag == "tag")
                    {
                        lbl.AutoSize = false;
                        lbl.Size = new Size(460, 36);
                        lbl.TextAlign = ContentAlignment.TopRight;
                        lbl.Font = new System.Drawing.Font(oxaniumFont.Families[0], 22, FontStyle.Italic);
                        lbl.ForeColor = Color.White;
                        lbl.Location = tagLoc;
                        tagLoc.Y += 40;
                    }

                    bodyViewPanel.Controls.Add(lbl);
                    bodyViewPanel.Refresh();
                }

                tagLoc.Y += 40;
                labelLoc.Y += 40;
            }
        }

        public static void clearDetails(Panel panel)
        {
            List<Label> lblList = new List<Label>();
            foreach (Label lbl in panel.Controls.OfType<Label>())
            {
                if (lbl.Tag == "tag")
                {
                    lblList.Add(lbl);
                }
                else if (lbl.Tag == "label")
                {
                    lblList.Add(lbl);
                }
            }

            int i = lblList.Count;
            while (i != 0)
            {
                foreach (Label lbl in lblList)
                {
                    lbl.Dispose();
                    i--;
                }
            }
            panel.Refresh();
        }

        public static async Task fetchStarData(string systemName, CancellationToken ct = default) //thank you EDSM
        {
            string url = "https://www.edsm.net/api-system-v1/bodies?systemName=" + systemName;
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.ConnectionClose = true;
            using var response = await _client.SendAsync(request, ct).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            try
            {
                string json = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
                await File.WriteAllTextAsync("C:\\EDHE\\res\\systemdata.json", json, ct).ConfigureAwait(false);
            }
            catch (IOException)
            {
                System.Windows.Forms.Timer waitTimer = new System.Windows.Forms.Timer();
                waitTimer.Interval = 50;
                waitTimer.Tick += (s, args) =>
                {
                    waitTimer.Stop();
                    fetchStarData(url, ct);
                };
                waitTimer.Start();
            }
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
            if (bodyListPanel.Controls.Count != 0)
            {
                foreach (Label lbl in bodyListPanel.Controls)
                {
                    Invoke(new Action(() => lbl.Dispose()));
                }
            }
        }
        private async void updateLocationData(string system)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => updateLocationData(system)));
                return;
            }

            Invoke(new Action(() => detailHiderPanel.BringToFront()));
            detailHiderPanel.BringToFront();
            expCurrentSystemTag.Text = system;
            await OnSystemChanged(system); //get the system data

            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => clearBodyList()));
                    BeginInvoke(new Action(() => systemData.loadSystemData(bodyListPanel, system)));
                }
                else
                {
                    clearBodyList();
                    systemData.loadSystemData(bodyListPanel, system);
                }
                Invoke(new Action(() => statusLabel.Text = statBase + "fetching location data"));
            }
            catch (IOException)
            {
                System.Windows.Forms.Timer waitRetryTimer = new System.Windows.Forms.Timer();
                waitRetryTimer.Interval = 50;
                waitRetryTimer.Tick += (s, args) =>
                {
                    waitRetryTimer.Stop();
                    updateLocationData(system);
                };
                waitRetryTimer.Start();

                Invoke(new Action(() => statusLabel.Text = statBase + "IOLock, waiting to retry"));
            }

        }

        //a good ol debounce setup so we don't accidentally flood EDSM with 700 GET requests in 0.3 seconds
        //i say again: thank you, EDSM
        private static CancellationTokenSource systemQueryCts;

        private async Task OnSystemChanged(string systemName)
        {
            systemQueryCts?.Cancel();
            systemQueryCts = new CancellationTokenSource();
            var token = systemQueryCts.Token;
            try
            {
                await Task.Delay(500, token); //this was 100, but SOMEONE went n got themselves a 429 response code on their stupid ass, fast ass internet

                await fetchStarData(systemName, token);
                Invoke(new Action(() => homeSysTag.Text = pCurrentSystem));
                if (!detailPanelNormal) { detailChangeButton.PerformClick(); }
            }
            catch (TaskCanceledException)
            {
                //dont do anything, cos that's the whole ass point
            }
        }

        private void detailChangeButton_Click(object sender, EventArgs e)
        {
            if (detailPanelNormal) //if the detail panel is in its normal, default position
            {
                //985 width
                planetDetailView.Location = new Point(workingAreaPanel.Width - 985, 0);
                planetDetailView.Size = new Size(workingAreaPanel.Width - planetDetailView.Location.X, workingAreaPanel.Height - 20);
                exploreDivider.Location = new Point(workingAreaPanel.Width - 988, 0); //-985 + a 3pt offset 

                detailChangeButton.Location = new Point(workingAreaPanel.Width - (995 + detailChangeButton.Width), detailChangeButton.Location.Y);
                detailChangeButton.Text = ">>>";
                detailPanelNormal = false;
            }
            else
            {
                planetDetailView.Location = starDetailView.Location;
                planetDetailView.Size = starDetailView.Size;
                exploreDivider.Location = new Point(starDetailView.Location.X - 3, 0);

                detailChangeButton.Location = new Point(workingAreaPanel.Width - (starDetailView.Width + detailChangeButton.Width + 10), detailChangeButton.Location.Y);
                detailChangeButton.Text = "<<<";
                detailPanelNormal = true;
            }
        }
    }
}