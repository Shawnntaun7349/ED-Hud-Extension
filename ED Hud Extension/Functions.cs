using System.Text.RegularExpressions;
using System.Text.Json;
using static Globals;
using ED_Hud_Extension;


internal class Functions
{
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
        if (File.Exists(loadedGamePath))
        {
            gamePath = loadedGamePath;
        }
        else if (File.Exists(defaultGamePath))//if it aint there, try the default path (in case the user has set some custom path that has been reset)
        {
            gamePath = defaultGamePath;
        }
        else //if *that* doesn't work, tell the user to manually locate the game file (or google it)
        {
            MessageBox.Show("No exe detected, please select the 'EliteDangerous64.exe' location in the settings menu.", "Game not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //load the user's settings
        try
        {
            savedPrefDisplayIndex = Int32.Parse(doc.RootElement.GetProperty("Preferred Display").GetString());
            statusEnabled = Boolean.Parse(doc.RootElement.GetProperty("Status Readout Enabled").GetString());
            autoShutDownEnabled = Boolean.Parse(doc.RootElement.GetProperty("Auto Shut Down").GetString());
            autoPanelSwitch = Boolean.Parse(doc.RootElement.GetProperty("Auto Switch Always").GetString());
            autoCombatSwitch = Boolean.Parse(doc.RootElement.GetProperty("Auto Switch Combat Only").GetString());
            capiEnabled = Boolean.Parse(doc.RootElement.GetProperty("cAPI Enabled").GetString());

            int sizeX = Int32.Parse(doc.RootElement.GetProperty("Size_X").GetString());
            int sizeY = Int32.Parse(doc.RootElement.GetProperty("Size_Y").GetString());
            formSize = new Size(sizeX, sizeY);
        }
        catch
        {
            generateSettings();
            loadSettings();
        }

        //make sure the form loads on the correct display
        Screen displayScreen = Screen.AllScreens[savedPrefDisplayIndex];
		location = displayScreen.WorkingArea.Location;

        //grab the user's key binds
        KeybindsHandler.retrieveKeyBinds();
	}

    public static bool saveSettings()
    {
        if (Directory.Exists(journalPath)) //make sure that the folder is the correct one by checking for guaranteed files like the ModulesInfo file
        {
            Directory.CreateDirectory("C:\\EDHE"); //create the EDHE directory if it doesn't exist

            var path = new Dictionary<object, object>
                {
                    { "Journal Path", journalPath.ToString() },
                    { "Game Path", gamePath.ToString() },
                    { "Preferred Display", chosenDisplay.ToString() },
                    { "Size_X", formSize.Width.ToString() },
                    { "Size_Y", formSize.Height.ToString() },
                    { "cAPI Enabled", capiEnabled.ToString() },
                    { "Status Readout Enabled", statusEnabled.ToString() },
                    { "Auto Shut Down", autoShutDownEnabled.ToString() },
                    { "Auto Switch Always", autoPanelSwitch.ToString() },
                    { "Auto Switch Combat Only", autoCombatSwitch.ToString() },

                };

            string json = JsonSerializer.Serialize(path, new JsonSerializerOptions { WriteIndented = true }); //json-ify that shit
            File.WriteAllText("C:\\EDHE\\settings.json", json); //create settings.json and write the data to it
            return true;
        }
        else {  return false; } //something broke
    }

	public static void generateSettings() //if the settings file doesn't exist, needs refreshed or is otherwise fuckered up
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
        if (File.Exists(defaultGamePath))
        {
            gamePath = defaultGamePath;
        }
        else //if *that* doesn't work, tell the user something to either manually locate the journal folder, or generate it by launching the game
        {
            MessageBox.Show("No exe detected, please select the 'EliteDangerous64.exe' location in the settings menu.", "Game not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //finally, create a settings file to save settings to
        Directory.CreateDirectory("C:\\EDHE"); 
        var settings = new Dictionary<object, object>
                {
                    { "Journal Path", defaultJournalPath },
                    { "Game Path", defaultGamePath },
                    { "Preferred Display", "0" },
                    { "Size_X", "1920"},
                    { "Size_Y", "1080"},
                    { "cAPI Enabled", "False" },
                    { "Status Readout Enabled", "False" },
                    { "Auto Shut Down", "False" },
                    { "Auto Switch Always", "False" },
                    { "Auto Switch Combat Only", "False" }
				};

        string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }); //json-ify that shit
        File.WriteAllText("C:\\EDHE\\settings.json", json); //create settings.json and write the data to it
    }

    public static void RestartApplication() //when a good ol 'Application.Restart();' call shits the bed, you pull out the Environment namespace big guns
    {
        //start a new instance with the same arguments
        /* string args = string.Join(" ", Environment.GetCommandLineArgs().Skip(1));
        
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = Application.ExecutablePath,
            Arguments = args,
            UseShellExecute = true
        });*/

        //forcefully exit the current instance
        Application.Restart(); //except for when Application.Restart() actually works?
    }

    public static string eliteTier(object rank)
    {
        //grab the players rank, see if it's above 8. if it is, subtract 8 from that value to determine how many iterations of Elite the player is
        int total = 0;
        string tier = "";
        if ((int)rank > 8){ total = (int)rank - 8; }
        else { return rank.ToString(); } //if it doesn't need converted to Elite, just pass the rank right on back to the caller

        if (total == 1) { tier = "Elite I"; }
        else if (total == 2) { tier = "Elite II"; }
        else if (total == 3) { tier = "Elite III"; }
        else if (total == 4) { tier = "Elite IV";  }
        else if (total == 5) { tier = "Elite V"; }

        return tier;
    }

    public static string correctedRank(string enumRank)
    {
        if (string.IsNullOrEmpty(enumRank)) return enumRank;

        return Regex.Replace(enumRank, @"([a-z])([A-Z])|([A-Z]+)([A-Z][a-z])", "$1$4 $2$3");
    }
    public static Dictionary<string, string> conversionTable = new Dictionary<string, string>()
        {   //suit names
            { "flightsuit", "Remlok Flight Suit" },
            { "tacticalsuit_class1", "Manticore Dominator, Grade 1" },
            { "tacticalsuit_class2", "Manticore Dominator, Grade 2" },
            { "tacticalsuit_class3", "Manticore Dominator, Grade 3" },
            { "tacticalsuit_class4", "Manticore Dominator, Grade 4" },
            { "tacticalsuit_class5", "Manticore Dominator, Grade 5" },
            { "utilitysuit_class1", "Remlok Maverick, Grade 1" },
            { "utilitysuit_class2", "Remlok Maverick, Grade 2" },
            { "utilitysuit_class3", "Remlok Maverick, Grade 3" },
            { "utilitysuit_class4", "Remlok Maverick, Grade 4" },
            { "utilitysuit_class5", "Remlok Maverick, Grade 5" },
            { "explorationsuit_class1", "Supratech Artemis, Grade 1" },
            { "explorationsuit_class2", "Supratech Artemis, Grade 2" },
            { "explorationsuit_class3", "Supratech Artemis, Grade 3" },
            { "explorationsuit_class4", "Supratech Artemis, Grade 4" },
            { "explorationsuit_class5", "Supratech Artemis, Grade 5" },
            //suit mods
            { "suit_increasedmeleedamage", "Added Melee Damage" },
            { "suit_adsmovementspeed", "Combat Movement Speed" },
            { "suit_improvedarmourrating", "Damage Resistance" },
            { "suit_improvedradar", "Enhanced Tracking" },
            { "suit_increasedammoreserves", "Extra Ammo Capacity" },
            { "suit_backpackcapacity", "Extra Backpack Capacity" },
            { "suit_increasedshieldregen", "Faster Shield Regen" },
            { "suit_increasedbatterycapacity", "Increased Battery Capacity" },
            { "suit_improvedjumpassist", "Improved Jump Assist" },
            { "suit_increasedo2capacity", "Increased Air Reserved" },
            { "suit_increasedsprintduration", "Increased Sprint Duration" },
            { "suit_nightvision", "Night Vision" },
            { "suit_suitquieterfootsteps", "Quieter Footsteps" },
            { "suit_reducedtoolbatteryconsumption", "Reduced Tool Battery Consumption" },
            //weapon mods
            { "weapon_headshotdamage", "Headshot Damage" },
            { "weapon_suppression_unpressurised", "Audio Masking" },
            { "weapon_suppression_pressurised", "Noise Suppressor" },
            { "weapon_handling", "Faster Handling" },
            { "weapon_range", "Greater Range" },
            { "weapon_accuracy", "Improved Hip Fire Accuracy" },
            { "weapon_clipsize", "Magazine Size" },
            { "weapon_reloadspeed", "Reload Speed" },
            { "weapon_stability", "Stability" },
            { "weapon_scope", "Scope" },
            { "weapon_backpackreloading", "Stowed Reloading" },
            //ships
            {"adder", "Adder" },
            {"anaconda", "Anaconda"},
            {"corsair", "Corsair" },
            {"dolphin", "Dolphin" },
            {"eagle", "Eagle" },
            {"hauler", "Hauler" },
            {"sidewinder", "Sidewinder"},
            {"mamba", "Mamba"},
            {"mandalay", "Mandalay" },
            {"orca", "Orca" },
            {"python", "Python" },
            {"vulture", "Vulture" },
        };

    public static string convertName(string inputName)
    {
        if (conversionTable.TryGetValue(inputName, out string? convertedName)) { return convertedName; }
        else return inputName;
    }
}