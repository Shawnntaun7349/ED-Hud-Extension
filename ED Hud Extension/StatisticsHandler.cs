using static Globals;
using static Functions;
using System.Text.Json;

namespace ED_Hud_Extension
{
    internal class StatisticsHandler
    {

        public static Dictionary<string, long> careerStatisticsDisplay = new Dictionary<string, long>();
        public static Dictionary<string, long> currentStatisticsDisplay = new Dictionary<string, long>();

        public static int sessionNumber;

        public static Dictionary<string, long> currentStatistics = new Dictionary<string, long>
        {
            { "floatingBounties", 0 },   //bounties the player has gained but not yet claimed
            { "floatingBountiesProfits", 0 }, //profit to be gained from the floating bounties
            { "bountiesClaimed", 0 },
            { "bountyProfits", 0 },

            { "floatingCombatBonds", 0 }, //bonds the player has gained but not yet claimed
            { "floatingCombatBondProfits", 0 }, //profit to be gained from the floating bonds
            { "combatBonds", 0 },
            { "combatBondProfits", 0 },

            { "assassinations", 0 },
            { "assassinationProfits", 0 },
            { "highestSingleReward", 0 },

            { "onFootKills", 0 },
            { "shipKills", 0 },
            { "totalKills", 0 },

            { "skimmersKilled", 0 },

            { "onFootCombatBonds", 0 },
            { "onFootCombatBondProfits", 0 },
            { "floatingOnFootCombatBonds", 0 }, //bonds the player has gained but not yet claimed
            { "floatingOnFootCombatBondProfits", 0 }, //profit to be gained from the floating bonds
            { "onFootScavsKilled", 0 },

            { "onFootSkimmersKilled", 0 },
            { "onFootVehiclesDestroyed", 0 },
            { "onFootShipsDestroyed", 0 },

            { "dropshipsBooked", 0 },
            { "dropshipsTaken", 0 },
            { "dropshipsCancelled", 0 },

            { "conflictZonesLow", 0 },
            { "conflictZonesMedium", 0 },
            { "conflictZonesHigh", 0 },
            { "conflictZonesTotal", 0 },

            { "conflictZonesLowWins", 0 },
            { "conflictZonesMediumWins", 0 },
            { "conflictZonesHighWins", 0 },
            { "conflictZonesWinsTotal", 0 },

            { "settlementsDefended", 0 },
            { "settlementsConquered", 0 },
        };

        //where the career statistics information from the Journal is stored
        public static Dictionary<string, long> careerStatistics = new Dictionary<string, long>
        {
            { "careerBounties", 0 },
            { "careerBountyProfits", 0 },

            { "careerCombatBonds", 0 },
            { "careerCombatBondProfits", 0 },

            { "careerAssassinations", 0 },
            { "careerAssassinationProfits", 0 },

            { "careerHighestReward", 0 },

            { "careerOnFootCombatBonds", 0 },
            { "careerOnFootCombatBondProfits", 0 },
            { "careerOnFootScavengers", 0 },

            { "careerOnFootSkimmers", 0 },
            { "careerOnFootVehiclesDestroyed", 0 },
            { "careerOnFootShipsDestroyed", 0 },

            { "careerSkimmersKilled", 0 },

            { "careerDropshipsBooked", 0 },
            { "careerDropshipsTaken", 0 },
            { "careerDropshipsCancelled", 0 },

            { "careerSettlementsConquered", 0 },
            { "careerSettlementsDefended", 0 },

            { "careerCZLow", 0 },
            { "careerCZMedium", 0 },
            { "careerCZHigh", 0 },
            { "careerCZTotal", 0 },

            { "careerCZWinsMedium", 0 },
            { "careerCZWinsLow", 0 },
            { "careerCZWinsHigh", 0 },
            { "careerCZWinsTotal", 0 }, 
        };

        public static Dictionary<string, bool> currentSessionEnabled = new Dictionary<string, bool>
        {
            { "floatingBounties", true },
            { "floatingBountiesProfits", true },
            { "bountiesClaimed", true },
            { "bountyProfits", true },
            { "floatingCombatBonds", true },
            { "floatingCombatBondProfits", true },
            { "combatBonds", true },
            { "combatBondProfits", true },

            { "assassinations", true },
            { "assassinationProfits", true },
            { "highestSingleReward", true },

            { "onFootKills", true },
            { "shipKills", true },
            { "totalKills", true },

            { "skimmersKilled", true },

            { "floatingOnFootCombatBonds", true },
            { "floatingOnFootCombatBondProfits", true },
            { "onFootCombatBonds", true },
            { "onFootCombatBondProfits", true },
            { "onFootVehiclesDestroyed", true },
            { "onFootShipsDestroyed", true },
            { "onFootScavsKilled", true },
            { "onFootSkimmersKilled", true },

            { "dropshipsTaken", true },
            { "dropshipsBooked", true },
            { "dropshipsCancelled", true },

            { "conflictZonesLow", true },
            { "conflictZonesMedium", true },
            { "conflictZonesHigh", true },
            { "conflictZonesLowWins", true },
            { "conflictZonesMediumWins", true },
            { "conflictZonesHighWins", true },
            { "conflictZonesTotal", true },
            { "conflictZonesWinsTotal", true },

            { "settlementsDefended", true },
            { "settlementsConquered", true },
        };

        //where the user's stat display settings are stored
        public static Dictionary<string, bool> careerEnabled = new Dictionary<string, bool>
        {
            { "careerBounties", true },
            { "careerBountyProfits", true },

            { "careerCombatBonds", true },
            { "careerCombatBondProfits", true },

            { "careerAssassinations", true },
            { "careerAssassinationProfits", true },

            { "careerHighestReward", true },

            { "careerOnFootCombatBonds", true },
            { "careerOnFootCombatBondProfits", true }, 
            { "careerOnFootScavengers", true },

            { "careerSkimmersKilled", true },
            { "careerOnFootSkimmers", true },
            { "careerOnFootVehiclesDestroyed", true },
            { "careerOnFootShipsDestroyed", true },

            { "careerDropshipsBooked", true },
            { "careerDropshipsTaken", true },
            { "careerDropshipsCancelled", true },

            { "careerSettlementsConquered", true },
            { "careerSettlementsDefended", true },

            { "careerCZLow", true },
            { "careerCZMedium", true },
            { "careerCZHigh", true },
            { "careerCZTotal", true },
            { "careerCZWinsLow", true },
            { "careerCZWinsMedium", true },
            { "careerCZWinsHigh", true },
            { "careerCZWinsTotal", true }, 
        };

        public static List<string> currencyValues = new List<string>()
        {
            "careerBountyProfits",
            "careerCombatBondProfits",
            "careerAssassinationProfits",
            "careerHighestReward",
            "careerOnFootCombatBondProfits",
            "bountyProfits",
            "combatBondProfits",
            "onFootCombatBondProfits",
            "floatingBountiesProfits",
            "floatingCombatBondProfits",
            "floatingOnFootCombatBondProfits",
        };

        public static void generateStatisticsList()
        {
            //get current session data
            currentStatisticsDisplay.Clear();

            foreach (string key in currentSessionEnabled.Keys)
            {
                if (currentSessionEnabled[key] == true)
                {
                    currentStatisticsDisplay.Add(convertName(key), currentStatistics[key]);
                }
            }

            careerStatisticsDisplay.Clear();

            //get career data
            foreach (string key in careerEnabled.Keys)
            {
                //make sure there aren't duplicate entries
                if (careerEnabled[key] == true && !careerStatisticsDisplay.ContainsKey(key))
                {
                    careerStatisticsDisplay.Add(key, careerStatistics[key]);
                }
            } 
        }

        public static void saveSession()
        {
            string sessionJson = JsonSerializer.Serialize(currentStatistics, new JsonSerializerOptions { WriteIndented = true });
            string sessionPath = ($"C:\\EDHE\\res\\sessions\\{sessionNumber}.json");
            File.WriteAllText(sessionPath, sessionJson);

            Dictionary<string, string> sessionSettings = new Dictionary<string, string>()
            {
                {"Session Number", sessionNumber.ToString() },
                {"Save Previous Session", savePreviousSession.ToString() }
            };
            string settingsJson = JsonSerializer.Serialize(sessionSettings, new JsonSerializerOptions {WriteIndented  = true});
            string settingsPath = ($"C:\\EDHE\\res\\sessions\\settings.json");
            File.WriteAllText(settingsPath, settingsJson);
        }

        public static void loadSession()
        {
            string settingsFile = File.ReadAllText($"C:\\EDHE\\res\\sessions\\settings.json");
            using JsonDocument settingsDoc = JsonDocument.Parse(settingsFile);
            savePreviousSession = Boolean.Parse(settingsDoc.RootElement.GetProperty("Save Previous Session").GetString());
            sessionNumber = Int32.Parse(settingsDoc.RootElement.GetProperty("Session Number").GetString());

            if (savePreviousSession) //if we needed to save the prior session, such as for a settings-mod-incurred restart
            {
                savePreviousSession = false;
                try
                {
                    string savedSessionFile = File.ReadAllText($"C:\\EDHE\\res\\sessions\\{sessionNumber}.json");
                    using JsonDocument doc = JsonDocument.Parse(savedSessionFile);
                    foreach (var key in currentStatistics.Keys)
                    {
                        currentStatistics[key] = doc.RootElement.GetProperty(key).GetInt64();
                    }
                }
                catch
                {
                    MessageBox.Show("There was an error retrieving your previous session data", "Data Retrieval Error", MessageBoxButtons.OK);
                    sessionNumber++;
                    saveSession();
                }
            }
            else //for any other reason
            {
                sessionNumber++;
                saveSession();
            }
        }
    }


    /* iterate through each dictionary and set them up as StatItems
       generate a list of each enabled Item for display
       generate a list of each enabled Item's Value.
       alternate the display of "Item :" \n "Value" [CR]
     
     
     */
}
