using System.Xml.Linq;

namespace ED_Hud_Extension
{
    public class KeybindsHandler
    {
        public class KeyBinding
        {
            public string Device { get; set; }
            public string Key { get; set; }
        }
        public static class KeyBindingParser
        {
            public static Dictionary<string, KeyBinding> ParseSelected(IEnumerable<string> wantedNames)
            {
                var wanted = new HashSet<string>(wantedNames, StringComparer.OrdinalIgnoreCase);
                var doc = XDocument.Load(Globals.defaultKeybindsPath);

                var result = new Dictionary<string, KeyBinding>();
                
                foreach (var element in doc.Root.Elements())
                {
                    if (!wanted.Contains(element.Name.LocalName)) continue;

                    var primary = element.Element("Primary");
                    if (primary == null) continue;

                    result[element.Name.LocalName] = new KeyBinding
                    {
                        Device = (string)primary.Attribute("Device"),
                        Key = CleanKeyName((string)primary.Attribute("Key"))
                    };
                }

                return result;
            }
        }

        public static void retrieveKeyBinds()
        {
            //load the user's keybinds
            var keysToGrab = new[] { "HumanoidHealthPack", "HumanoidBattery", "HumanoidSelectFragGrenade", "HumanoidSelectEMPGrenade", "HumanoidSelectShieldGrenade" };
            var binds = KeyBindingParser.ParseSelected(keysToGrab);

            Globals.healthPackKey = binds["HumanoidHealthPack"].Key;
            Globals.energyCellKey = binds["HumanoidBattery"].Key;
            Globals.fragGrenadeKey = binds["HumanoidSelectFragGrenade"].Key;
            Globals.empKey = binds["HumanoidSelectEMPGrenade"].Key;
            Globals.shieldProjectorKey = binds["HumanoidSelectShieldGrenade"].Key;
        }

        public static string CleanKeyName(string rawKey)
        {
            if (string.IsNullOrEmpty(rawKey)) return rawKey;

            const string prefix = "Key_";
            return rawKey.StartsWith(prefix, StringComparison.Ordinal)
                ? rawKey.Substring(prefix.Length) : rawKey;
        }
    }
}
