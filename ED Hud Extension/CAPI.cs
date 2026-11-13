using System.Text.Json;
using System.Text.Json.Nodes;

namespace ED_Hud_Extension
{
    public class CAPI
    {
        private const string baseUrl = "https://companion.orerve.net/";

        public OAuth2 OAuth { get; private set; }

        public CAPI(OAuth2 auth)
        {
            OAuth = auth;
        }
        
        private JsonObject Get(string url)
        {
            var req = OAuth.CreateRequest(url);
            req.Method = "GET";
            try
            {
                using (var response = req.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    try
                    {
                        return JsonNode.Parse(stream)!.AsObject();
                    }
                    catch (JsonException)
                    {
                        //do nothing cos the file is either empty or fucked
                        var failString = new JsonObject()
                    {
                        { "that shit", "didn't work" }
                    };
                        return failString;
                    }
                }
            }
            catch
            {
                OAuth2.Load().Refresh();
                return Get(url); //refresh the auth token n try that shit again
            }
        }

        public JsonObject GetProfile() { return Get(baseUrl + "profile"); }
        public JsonObject GetMarket() { return Get(baseUrl + "market"); }
        public JsonObject GetShipyard() { return Get(baseUrl + "shipyard"); }
        public JsonObject GetJournal() { return Get(baseUrl + "journal"); }
    }
}

