using System.Text.Json;
using static Globals;

namespace ED_Hud_Extension
{
    internal class NavData
    {
        public class Root
        {
            public DateTime timestamp {  get; set; }
            public string @event { get; set; }
            public List<Route> Route { get; set; }
        }

        public class Route
        {
            public string StarSystem { get; set; }
            public object SystemAddress { get; set; }
            public List<double> StarPos {  get; set; }
            public string StarClass { get; set; }
        }

        public static Root navData;
        public static Route navRoute;
        public static int routeLength = 0;

        public static void fetchNavRoute(Label nextSysTag, Label destSysTag, Form parent)
        {
            if (File.Exists(journalPath + "\\NavRoute.json"))
            {
                routeActive = true;
                //read the route data
                string json = File.ReadAllText(journalPath + "\\NavRoute.json");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                navData = JsonSerializer.Deserialize<Root>(json, options);
                navRoute = JsonSerializer.Deserialize<Route>(json, options);
                routeLength = navData.Route.Count;

                //if the route file says this, then the route is a one-jump deal and doesn't need this. clear out the memory so we don't hold onto empty data
                if (navData.@event == "NavRouteClear") { clearRoute(); return; }
                updateRoute(nextSysTag, destSysTag);
            }
        }

        public static void updateRoute(Label nextSysTag, Label destSysTag)
        {
            if (navData.Route.Count != 0)
            {
                //if the first system in the list is the system we're in, get rid of it
                if (navData.Route.First().StarSystem == pCurrentSystem)
                {
                    navData.Route.RemoveAt(0);
                }

                //get the length of the route, how many systems are we jumping through?
                routeLength = navData.Route.Count;

                //update the ui to reflect the route for the user
                nextSysTag.Text = navData.Route.First().StarSystem; //next system in the list
                destSysTag.Text = navData.Route.Last().StarSystem; //final system in the list
            }
            else return;
        }

        public static void clearRoute()
        {
            if (routeActive && navData.Route.Count != 0) //if the route isn't already empty
            {
                navData.Route.Clear();
                routeLength = 0;
                routeActive = false;
            }
            else //if the route is already empty
            {
                return;
            }
        }
    }
}