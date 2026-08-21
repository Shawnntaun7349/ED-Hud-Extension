using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using EliteJournalReader;
using EliteJournalReader.Events;

using static Globals;
using System.Text.Json;
using ED_Hud_Extension;

internal class Functions
{
    //create an instance of the MainForm so that we can make calls on it
    public Functions()
	{
		//i dunno why but it gets real mad if i put anything here so fuck it
	}

	public static void loadSettings()
    {
        //check for the settings file, generate a new settings file w/ default values if it can't be located
        if (!File.Exists(settingsPath)){ generateSettings(); }

		//read the settings file
		string sFile = File.ReadAllText(settingsPath);
		using JsonDocument doc = JsonDocument.Parse(sFile);

        //verify the saved journal folder path
        string loadedPath = doc.RootElement.GetProperty("Journal Path").GetString();
        if (Directory.Exists(loadedPath))
		{
			journalPath = loadedPath;
		}
		else if (Directory.Exists(defaultJournalPath))//if it aint there, try the default path (in case the user has set some custom path that has been reset)
		{
			journalPath = defaultJournalPath;
        }
		else //if *that* doesn't work, tell the user something to either manually locate the journal folder, or generate it by launching the game
		{
			MessageBox.Show("No journal folder detected, please select the journal folder location in the settings menu.", "Journals not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //verify the saved game folder path
        string loadedGamePath = doc.RootElement.GetProperty("Game Path").GetString();
        if (Directory.Exists(loadedGamePath))
        {
            gamePath = loadedGamePath;
        }
        else if (Directory.Exists(defaultJournalPath))//if it aint there, try the default path (in case the user has set some custom path that has been reset)
        {
            gamePath = defaultGamePath;
        }
        else //if *that* doesn't work, tell the user something to either manually locate the journal folder, or generate it by launching the game
        {
            MessageBox.Show("No exe detected, please select the EDLauncher.exe location in the settings menu.", "Game not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //load the display settings
        savedPrefDisplayIndex = Int32.Parse(doc.RootElement.GetProperty("Preferred Display").GetString()); //1, 2, 3, etc.
		statusEnabled = Boolean.Parse(doc.RootElement.GetProperty("Status Readout Enabled").GetString()); // True or False

		//make sure the form loads on the correct display
		Screen displayScreen = Screen.AllScreens[savedPrefDisplayIndex];
		location = displayScreen.WorkingArea.Location;
	}

    public static void saveSettings()
    {
        if (Directory.Exists(journalPath)) //make sure that the folder is the correct one by checking for guaranteed files like the ModulesInfo file
        {
            Directory.CreateDirectory("C:\\EDHE"); //Create the EDHE directory if it doesn't exist

            var path = new Dictionary<string, string>
                {
                    { "Journal Path", journalPath },
                    { "Game Path", gamePath },
                    { "Preferred Display", chosenDisplay.ToString() },
                    { "Status Readout Enabled", statusEnabled.ToString() }

                };

            string json = JsonSerializer.Serialize(path, new JsonSerializerOptions { WriteIndented = true }); //json-ify that shit
            File.WriteAllText("C:\\EDHE\\settings.json", json); //create settings.json and write the data to it
            MessageBox.Show("Settings saved successfully! Application will now restart.", "Selection complete", MessageBoxButtons.OK);
            RestartApplication();
        }
    }

	public static void generateSettings()
    {

        //check for the journal folder in the default directory
        if (Directory.Exists(defaultJournalPath)) //if it's there, save the location for assignment to the settings file
        {
            journalPath = defaultJournalPath;
        }
        else //tell the player that they need to locate the journal folder
        {
            MessageBox.Show("No journal folder detected, please select the journal folder location in the settings menu.", "Journals not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //verify the saved game folder path
        if (Directory.Exists(defaultGamePath))
        {
            gamePath = defaultGamePath;
        }
        else //if *that* doesn't work, tell the user something to either manually locate the journal folder, or generate it by launching the game
        {
            MessageBox.Show("No exe detected, please select the EDLauncher.exe location in the settings menu.", "Game not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //finally, create a settings file to save settings to

        Directory.CreateDirectory("C:\\EDHE"); //Create the EDHE directory if it doesn't exist...somehow...
        var settings = new Dictionary<string, string>
                {
                    { "Journal Path", defaultJournalPath },
                    { "Game Path", defaultGamePath },
                    { "Preferred Display", "0" },
					{ "Status Readout Enabled", "true" }
				};

        string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }); //json-ify that shit
        File.WriteAllText("C:\\EDHE\\settings.json", json); //create settings.json and write the data to it
    }















	public static void simulateCombat(bool inCombat, string tName, string tShip, float tShield, float tHull) //to be removed at some point, this is just for debugging
	{
		//a function to retrieve scan data from the player journal and store them for display. setup is mildly redundant at the moment but will make more sense once journal integration is done.

		Globals.inCombat = inCombat;
		Globals.targetName = tName;
		Globals.targetShip = tShip;
		Globals.targetShield = tShield;
		Globals.targetHull = tHull;
	}
    public static void RestartApplication()
    {
        // 1. Start a new instance with the same arguments
        string args = string.Join(" ", Environment.GetCommandLineArgs().Skip(1));
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = Application.ExecutablePath,
            Arguments = args,
            UseShellExecute = true
        });

        // 2. Forcefully exit the current instance
        Environment.Exit(0);
    }
}
    












//bool journalsFound = false;
////check for a settings file
//if (File.Exists(settingsPath))
//{
//    //read the settings file
//    string sFile = File.ReadAllText(settingsPath);
//    using JsonDocument doc = JsonDocument.Parse(sFile);

//    //read the journal folder path, assign it to the global 
//    journalPath = doc.RootElement.GetProperty("Path").GetString();

//    //then check for the journal folder
//    if (Directory.Exists(journalPath)) //if it's there, save the location for assignment to the settings file, then
//    {
//        defaultJournalPath = journalPath;
//        initiateWatcher();
//    }
//    else if (Directory.Exists(defaultJournalPath)) //if it's not there, try the default path
//    {
//        journalPath = defaultJournalPath; //then correct the global to save a headache later on
//        initiateWatcher();
//    }
//    else //if neither of those work, tell the player they gotta find/make the journals directory
//    {
//        MessageBox.Show("No journal folder detected, please select the journal folder location in the settings menu.", "Journals not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//    }


//    //read the saved preferred display index value

//    //all of these [dataType].Parse(blah blah blah); methods basically retrieve the value of the settings Dict at the given Key,
//    //convert it to a String & then convert *that* string to whatever Data Type is needed. So Int32 for the display index, Boolean for binary settings, etc.

//    savedPrefDisplayIndex = Int32.Parse(doc.RootElement.GetProperty("Preferred Display").GetString());

//    //make sure the form loads on the preferred display
//    Screen displayScreen = Screen.AllScreens[savedPrefDisplayIndex];
//    location = displayScreen.WorkingArea.Location;
//    StartPosition = FormStartPosition.Manual;
//    Location = location;

//    statusEnabled = Boolean.Parse(doc.RootElement.GetProperty("Status Readout Enabled").GetString());

//    //once that's all done, initialize the component
//    InitializeComponent();
//    if (!waitingForJournal)
//    {
//        animTimer.Dispose();
//        initPanel.Visible = false;
//    }
//    else
//    {
//        initPanel.Visible = true;
//    }
//    locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm");

//    animTimer = new System.Threading.Timer(animCallbackMethod, "Timer State", 500, 1000);
//    localTimer = new System.Threading.Timer(localCallbackMethod, "Timer State", 100, 500);

//}
//else //attempt to create a settings file & write the default values
//{
//    //check for the journal folder in the default directory
//    string folderToCheck = defaultJournalPath;
//    if (Directory.Exists(folderToCheck)) //if it's there, save the location for assignment to the settings file
//    {
//        journalPath = defaultJournalPath;
//        initiateWatcher();
//    }
//    else //tell the player that they need to locate the journal folder
//    {
//        MessageBox.Show("No journal folder detected, please select the journal folder location in the settings menu.", "Journals not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//    }

//    //finally, create a settings file to save settings to

//    Directory.CreateDirectory("C:\\EDHE"); //Create the EDHE directory if it doesn't exist...somehow...
//    var settings = new Dictionary<string, string>
//                {
//                    { "Path", defaultJournalPath },
//                    { "Preferred Display", "0" }

//                };

//    string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }); //json-ify that shit
//    File.WriteAllText("C:\\EDHE\\settings.json", json); //create settings.json and write the data to it

//    //don't forget to initialize the component like some kind of fucken dunce
//    InitializeComponent();
//    locDTTag.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy \nHH:mm");
//    if (journalsFound)
//    {
//        animTimer.Dispose();
//        initPanel.Visible = false;
//    }
//    else
//    {
//        initPanel.Visible = true;
//    }
//}

