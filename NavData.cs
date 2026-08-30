using 
using System;

namespace ED_Hud_Extension
{
    public class NavData
    {
        public string StarSystem { get; set; }
        public int SystemAddress { get; set; }
    }

    public class NavRoute
    {
        public List<NavData> NavRoute { get; set; }
    }

    public void fetchNavRoute()
    {
        if (File.Exists(Globals.journalPath + "\\navroute.json"))
        {

        }
    }
}
