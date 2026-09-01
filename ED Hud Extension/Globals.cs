using System.Drawing.Text;

public class Globals
{
    //font bullshit
    public static PrivateFontCollection oxaniumFont = new PrivateFontCollection();

    //background variables
    public static bool mainFormLoaded = false;
    public static bool connected = false; //for online connection
    public static bool waitingForJournal = true; //for local connection
    public static int starYear = DateTime.UtcNow.Year + 1286;
    public static Point location; //for display methods
    public static DateTime startUpTime; //set at JournalWatcher startup, used to filter all but a few 'old' events in a given journal
    public static DateTime shutdownTime;
    public static string gameMode;

    // --------------------- settings variables ---------------------
    //files & paths
    public static string settingsPath = "C:\\EDHE\\Settings.json";
    public static string defaultJournalPath = "C:\\Users\\" + Environment.GetEnvironmentVariable("USERNAME") + "\\Saved Games\\Frontier Developments\\Elite Dangerous";
    public static string defaultGamePath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Elite Dangerous\\Products\\elite-dangerous-odyssey-64\\EliteDangerous64.exe";
    public static string logPath = "C:\\EDHE\\log.txt";
    public static string journalPath;
    public static string gamePath;

    //user settings - interface
    public static bool statusEnabled;
    public static bool autoPanelSwitch;
    public static bool autoCombatSwitch;
    public static bool autoShutDownEnabled;
    
    //user settings - display
    public static int savedPrefDisplayIndex;
    public static int chosenDisplay;
    public static int selectedIndex;

    //user settings - audio
    public static bool mindYourOwnDamnBusiness;

    public static bool statusReaderLive;

    //journal files, status files, etc.
    public class StatusTags
    {
        //Flag 1
        public static bool Docked;
        public static bool Landed;
        public static bool GearDown;
        public static bool ShieldsUp;
        public static bool Supercruise;
        public static bool FAOff;
        public static bool HardpointsDeployed;
        public static bool InWing;
        public static bool LightsOn;
        public static bool CargoScoopDeployed;
        public static bool SilentRunning;
        public static bool ScoopingFuel;
        public static bool SrvHandBrake;
        public static bool SrvTurretView;
        public static bool SrvTurretRetracted; //comes active when the srv gets close enough to the player's ship to retract the turret entirely
        public static bool SrvDriveAssist;
        public static bool FsdMassLocked;
        public static bool FsdCharging;
        public static bool FsdCooldown;
        public static bool LowFuel; //<25%
        public static bool OverHeating; //>100%
        public static bool HasLatLong;
        public static bool IsInDanger;
        public static bool InMainShip;
        public static bool InFighter;
        public static bool InSrv;
        public static bool HudInAnalysisMode;
        public static bool NightVision;
        public static bool AltitudeFromAverageRadius;
        public static bool FsdJump;
        public static bool SrvHighBeam;

        //Flag 2
        public static bool OnFoot;
        public static bool InTaxi;
        public static bool InMulticrew;
        public static bool OnFootInStation;
        public static bool OnFootOnPlanet;
        public static bool AimDownSight;
        public static bool LowOxygen;
        public static bool LowHealth;
        public static bool Hot;
        public static bool Cold;
        public static bool VeryHot;
        public static bool VeryCold;
        public static bool GlideMode;
        public static bool OnFootInHangar;
        public static bool OnFootSocialSpace;
        public static bool OnFootExterior;
        public static bool BreathableAtmosphere;
    }

    public static int pFootHealth;
    public static int pFootOxygen;

    // --------------------- player variables ---------------------
    //player stuff
    public static string pCombatRank;
    public static string pMercRank;
    public static string pExploreRank;
    public static string pExoBioRank;
    public static string pTradeRank;
    public static string pArenaRank;
    public static string pFedRank;
    public static string pEmpRank;
    public static string pAllyRank;

    public static int pCombatProgress;
    public static int pMercProgress;
    public static int pExploreProgress;
    public static int pExoBioProgress;
    public static int pTradeProgress;
    public static int pArenaProgress;
    public static int pFedProgress;
    public static int pEmpProgress;
    public static int pAllyProgress;

    public static double pEmpRep;
    public static double pFedRep;
    public static double pAllyRep;
    public static double pIndieRep;
    public static string pEmpRepType;
    public static string pFedRepType;
    public static string pAllyRepType;
    public static string pIndieRepType;

    //combat stuff
    public static bool pUnderAttack;
    public static string attackerTarget;

    //target variables
    public static bool targetLocked;
    public static bool pTargeting;
    public static int scanLevel;
    public static bool scanDone;
    public static string targetName;
    public static string targetShip;
    public static object targetRank;
    public static double targetShield;
    public static double targetHull;
    public static string targetFaction;
    public static string targetPower;
    public static string targetLegal;
    public static double targetBounty;
    public static double targetExtendedBounty;
    public static string targetSubSystem;
    public static double targetSSHealth;
    public static bool hasLocalBounty;
    public static bool hasExtendedBounty;
    public static bool hasBothBounty;

    //financial stuff
    public static long pCreditBalance;
    public static long pLoan;

    //ship stuff
    //from journal
    public static string pShipType;
    public static string pShipName;
    public static string pShipID;
    public static double currentFuelLevel; //from the journal files
    public static double maxFuelLevel;

    //from status file
    public static int systemPips;
    public static int enginePips;
    public static int weaponPips;
    public static int fireGroup;
    public static int guiFocus;
    public static double fuelMain;
    public static double fuelRes;

    //location stuff
    public static string pCurrentSystem;
    public static string starBody;
    public static string starBodyType;
    public static string DistFromStarLS;
    public static bool pDocked; 
    public static string stationName; //if docked
    public static string stationType; //if docked
    public static long marketID;
    public static string starFaction;
    public static string starFactionState;
    public static string systemAllegiance;
    public static string systemPrimEconomy;
    public static string systemSecEconomy;
    public static string systemGovernment;
    public static string systemSecurity;
    public static bool pWanted;
    public static string pFactionRep;
    public static bool routeActive;
    public static DateTime fsdJumpTS;
    public static DateTime locationTS;
}
