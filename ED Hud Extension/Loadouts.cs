using static Globals;

namespace ED_Hud_Extension
{
    public class Loadouts
    {
        public class Loadout
        {
            public string SuitName { get; set; }
            public string LoadoutName { get; set; }
            public List<string>? SuitMods { get; set; } 
            public List<Weapon>? Modules { get; set; } //weapons
        }
        public class Weapon 
        {
            public string SlotName { get; set; } //slot 1, 2, 3
            public string ModuleName_Localised { get; set; } //legible weapon name
            public int Class { get; set; } 
            public List<string>? WeaponMods { get; set; } 
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
        };

        public static Loadout playerLoadout;
        public static Weapon loadoutWeapon;

        public static string convertName(string inputName)
        {
            if (conversionTable.TryGetValue(inputName, out string? convertedName)) { return convertedName; }
            else return inputName;
        }

        public  void getLoadoutData()
        {
            if (File.Exists(journalPath))
            {
                string json = File.ReadAllText(journalPath);
            }
            else { /* fucken panic */ }
        }
    }
}
