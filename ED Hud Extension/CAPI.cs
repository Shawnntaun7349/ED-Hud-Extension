using System.Text.Json.Nodes;

namespace ED_Hud_Extension
{
    public class CAPI
    {
        private const string ProfileURL = "https://companion.orerve.net/profile";
        private const string MarketURL = "https://companion.orerve.net/market";
        private const string ShipyardURL = "https://companion.orerve.net/shipyard";
        private const string JournalURL = "https://companion.orerve.net/journal";


        public OAuth2 OAuth { get; private set; }

        public CAPI(OAuth2 auth)
        {
            OAuth = auth;
        }
        
        private JsonObject Get(string url)
        {
            var req = OAuth.CreateRequest(url);
            req.Method = "GET";
            using (var response = req.GetResponse())
            using (var stream = response.GetResponseStream()) 
            {
                return JsonNode.Parse(stream)!.AsObject();
            }
        }

        public JsonObject GetProfile() { return Get(ProfileURL); }
        public JsonObject GetMarket() { return Get(MarketURL); }
        public JsonObject GetShipyard() { return Get(ShipyardURL); }
        public JsonObject GetJournal() { return Get(JournalURL); }
    }
}

