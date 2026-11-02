using Microsoft.AspNetCore.Identity.Data;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.AxHost;


namespace ED_Hud_Extension
{
    public class OAuth2
    {
        private static readonly string ClientID = ConfigurationManager.AppSettings["ClientID"];
        private static readonly string AppName = ConfigurationManager.AppSettings["AppName"];
        private const string Scope = "capi auth";
        private const string AuthServerAuthURL = "https://auth.frontierstore.net/auth";
        private const string AuthServerTokenURL = "https://auth.frontierstore.net/token";
        private const string AuthServerDecodeURL = "https://auth.frontierstore.net/decode";

        private string AccessToken;
        private string RefreshToken;
        private string TokenType;

        public interface IOAuth2Request : IDisposable
        {
            string AuthURL { get; }
            OAuth2 GetAuth();
        }

        public class OAuth2Request 
        {
            private static readonly HttpClient Http = new();
            public OAuth2? OAuth { get; private set; }

            public async Task<OAuth2> AuthorizeAsync(CancellationToken ct = default)
            {
                var codeVerifier = GetBase64Random(32);
                var state = GetBase64Random(8);
                var challenge = Base64URLEncode(SHA256(Encoding.ASCII.GetBytes(codeVerifier)));

                var cert = LoadOrCreateCert(Globals.pfxPath);
                await using var server = new OAuthCallbackServer();
                await server.StartAsync(cert, Enumerable.Range(49152, 9));

                var redirectUri = $"https://localhost:{server.Port}/";

                var authUrl = AuthServerAuthURL +
                    "?scope=" + Uri.EscapeDataString(Scope) +
                    "&audience=frontier" +
                    "&response_type=code" +
                    "&client_id=" + Uri.EscapeDataString(ClientID) +
                    "&code_challenge=" + Uri.EscapeDataString(challenge) +
                    "&code_challenge_method=S256" +
                    "&state=" + Uri.EscapeDataString(state) +
                    "&redirect_uri=" + Uri.EscapeDataString(redirectUri);

                Process.Start(new ProcessStartInfo { FileName = authUrl, UseShellExecute = true });

                var result = await server.Callback.WaitAsync(TimeSpan.FromMinutes(3), ct);

                if (!string.IsNullOrEmpty(result.Error)) { throw new InvalidOperationException($"Authorization failed: {result.Error}"); }
                if (result.State != state) { throw new InvalidOperationException("State mismatch"); }
                if (string.IsNullOrEmpty(result.Code)) { throw new InvalidOperationException("No authorization code recieved"); }

                var form = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "authorization_code",
                    ["client_id"] = ClientID,
                    ["code_verifier"] = codeVerifier,
                    ["code"] = result.Code,
                    ["redirect_uri"] = redirectUri
                });

                using var req = new HttpRequestMessage(HttpMethod.Post, AuthServerTokenURL) { Content = form };
                req.Headers.TryAddWithoutValidation("User-Agent", AppName);
                req.Headers.Accept.ParseAdd("application/json");

                using var resp = await Http.SendAsync(req, ct);
                var body = await resp.Content.ReadAsStringAsync(ct);
                if (!resp.IsSuccessStatusCode)
                {
                    //check the auth token validity before failing out
                    try
                    {
                        OAuth2 r = new OAuth2();
                        r.Refresh();
                    }
                    catch
                    {
                        throw new HttpRequestException($"Token request failed: {(int)resp.StatusCode} {body}"); //shit broke
                    }
                }

                var doc = JsonNode.Parse(body);
                OAuth = new OAuth2()
                {
                    AccessToken = (string?)doc?["access_token"],
                    RefreshToken = (string?)doc?["refresh_token"],
                    TokenType = (string?)doc?["token_type"]
                };
                return OAuth;
            }
        }

        private static string Base64URLEncode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').TrimEnd('=');
        }

        private static string GetBase64Random(int len)
        {
            var rng = RandomNumberGenerator.Create();
            var bytes = new byte[len];
            rng.GetBytes(bytes);
            return Base64URLEncode(bytes);
        }

        private static byte[] SHA256(byte[] data)
        {
            var sha = System.Security.Cryptography.SHA256.Create();
            return sha.ComputeHash(data);
        }

        public static OAuth2 Load()
        {
            try
            {
                var doc = JsonNode.Parse(System.IO.File.ReadAllText(Globals.tokenPath));

                return new OAuth2
                {
                    AccessToken = (string?)doc?["access_token"],
                    RefreshToken = (string?)doc?["refresh_token"],
                    TokenType = (string?)doc?["token_type"]
                };
            }
            catch
            {
                return null;
            }
        }

        public async void Refresh()
        {
            try
            {
                var cert = LoadOrCreateCert(Globals.pfxPath);
                await using var server = new OAuthCallbackServer();
                await server.StartAsync(cert, Enumerable.Range(49152, 9));

                var redirectUri = $"https://localhost:{server.Port}/";

                var form = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "refresh_token",
                    ["client_id"] = ClientID,
                    ["refresh_token"] = RefreshToken,
                    ["redirect_uri"] = redirectUri
                });

                using var req = new HttpRequestMessage(HttpMethod.Post, "https://auth.frontierstore.net/token") { Content = form };
                using var resp = await new HttpClient().SendAsync(req);
                var body = await resp.Content.ReadAsStringAsync();

                var doc = JsonNode.Parse(body);

                var tokensToSave = new JsonObject 
                {
                    ["access_token"] = (string?)doc?["access_token"],
                    ["refresh_token"] = (string?)doc?["refresh_token"],
                    ["token_type"] = (string?)doc?["token_type"]
                };

                System.IO.File.WriteAllText(Globals.tokenPath, tokensToSave.ToString());
            }
            catch
            {
                return;
            }
        }

        public void Save()
        {
            var tokensToSave = new JsonObject
            {
                ["access_token"] = AccessToken,
                ["refresh_token"] = RefreshToken,
                ["token_type"] = TokenType
            };

            System.IO.File.WriteAllText(Globals.tokenPath, tokensToSave.ToString());
        }

        public HttpWebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers[HttpRequestHeader.Authorization] = "Bearer " + AccessToken;
            request.Headers[HttpRequestHeader.UserAgent] = AppName;
            return request;
        }

        static X509Certificate2 LoadOrCreateCert(string pfxPath)
        {
            const string pfxPassword = "localhost-cert";
            const X509KeyStorageFlags flags =
                X509KeyStorageFlags.UserKeySet |
                X509KeyStorageFlags.PersistKeySet |
                X509KeyStorageFlags.Exportable;

            if (System.IO.File.Exists(pfxPath))
            {
                try
                {
                    var existing = new X509Certificate2(pfxPath, pfxPassword, flags);
                    if (existing.NotAfter > DateTime.Now.AddDays(7)) return existing;
                }
                catch (CryptographicException)
                {
                    // corrupt or written with different settings: fall through and regenerate
                }
            }

            using var rsa = RSA.Create(2048);
            var req = new CertificateRequest("CN=localhost", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            var san = new SubjectAlternativeNameBuilder();
            san.AddDnsName("localhost");
            san.AddIpAddress(IPAddress.Loopback);
            req.CertificateExtensions.Add(san.Build());
            req.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
            req.CertificateExtensions.Add(new X509KeyUsageExtension(
                X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, false));
            req.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(
                new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, false));

            using var created = req.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));

            var pfx = created.Export(X509ContentType.Pfx, pfxPassword);
            System.IO.File.WriteAllBytes(pfxPath, pfx);
            return new X509Certificate2(pfx, pfxPassword, flags);
        }
    }
}