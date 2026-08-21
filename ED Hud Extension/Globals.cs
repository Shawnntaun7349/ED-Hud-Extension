using System;
using System.Diagnostics;

public class Globals
{
    //target variables
    public static string targetName;
    public static string targetShip;
    public static float targetShield;
    public static float targetHull;
    public static bool inCombat;

    //background variables
    public static bool connected = false; //for online connection
    public static bool waitingForJournal = true; //for local connection
    public static int starYear = DateTime.UtcNow.Year + 1286;
    public static Point location; // for display methods

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
    
    //user settings - display
    public static int savedPrefDisplayIndex;
    public static int chosenDisplay;
    public static int selectedIndex;

    //user settings - audio
    public static bool mindYourOwnDamnBusiness;

    // --------------------- player variables ---------------------
    //journal data
    public Dictionary<string, string> playerInfo;

    public static double currentFuelLevel;
    public static double maxFuelLevel;
}   
