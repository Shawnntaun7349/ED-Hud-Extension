using System.Text.Json;
using System.Reflection;
using System.Diagnostics;

namespace ED_Hud_Extension
{
    internal class UpdateService
    {
        private readonly GitHubUpdateChecker _checker;
        private bool isChecking;

        public UpdateService(GitHubUpdateChecker checker)
        {
            _checker = checker;
        }

        public async Task CheckForUpdatesAsync(bool silent)
        {
            if (isChecking) { return; } //prevent multiple checks in short succession
            isChecking = true;

            UpdateInfo update = new UpdateInfo();
            try
            {
                var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                try
                {
                    update = await _checker.CheckForUpdatesAsync(currentVersion);
                }
                catch (HttpRequestException)
                {
                    if (!silent) { MessageBox.Show("Could not complete request, try again at another time.", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    else return; //fail silently as to not bother the user
                }

                if (update != null)
                {
                    ShowUpdateAvailablePrompt(update);
                }
                else if (!silent)
                {
                    MessageBox.Show("Latest Version already installed.", "Update Check Complete", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                //if silent and there's no update to show, just do nothing
            }
            finally
            {
                isChecking = false;
            }
        }

        private async Task ShowUpdateAvailablePrompt(UpdateInfo update)
        {
            var result = MessageBox.Show($"Version {update.Version} is available. Update now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
            if (result == DialogResult.Yes)
            {
                await OnUpdateConfirmed(update);
            }
        }

        private async Task OnUpdateConfirmed(UpdateInfo info)
        {
            var installerPath = await _checker.DownloadUpdateAsync(info);

            var updaterExe = Path.Combine("C:\\EDHE\\bin\\", "EDHEUpdater.exe");
            var mainExePath = Environment.ProcessPath;

            Process.Start(new ProcessStartInfo
            {
                FileName = updaterExe,
                Arguments = $"--wait-pid {Environment.ProcessId} --installer \"{installerPath}\" --relaunch \"{mainExePath}\"",
                UseShellExecute = true
            });

            Environment.Exit(0);
        }

        public class UpdateInfo
        {
            public string Version { get; set; }
            public string DownloadUrl { get; set; }
        }

        public class GitHubUpdateChecker
        {
            private readonly HttpClient client;
            private const string Owner = "shawnntaun7349";
            private const string Repo = "ED-Hud-Extension";

            public GitHubUpdateChecker()
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("EDHE-UpdateChecker");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            }

            public async Task<UpdateInfo> CheckForUpdatesAsync(Version currentVersion)
            {
                var url = $"https://api.github.com/repos/{Owner}/{Repo}/releases/latest";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                using var doc = await JsonDocument.ParseAsync(stream);
                var root = doc.RootElement;

                var tagName = root.GetProperty("tag_name").GetString();
                var latestVersion = new Version(tagName.TrimStart('v'));

                if (latestVersion <= currentVersion) return null;

                var asset = root.GetProperty("assets").EnumerateArray().FirstOrDefault(a => a.GetProperty("name").GetString().EndsWith(".exe"));

                if (asset.ValueKind == JsonValueKind.Undefined) return null;

                return new UpdateInfo
                {
                    Version = tagName,
                    DownloadUrl = asset.GetProperty("browser_download_url").GetString()
                };
            }

            public async Task<string> DownloadUpdateAsync(UpdateInfo info, IProgress<double> progress = null)
            {
                var tempPath = Path.Combine(Path.GetTempPath(), $"EDHE.{info.Version}.exe");

                using var response = await client.GetAsync(info.DownloadUrl, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                await using var contentStream = await response.Content.ReadAsStreamAsync();
                await using var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None);

                var buffer = new byte[81920];
                long totalRead = 0;
                int read;
                while ((read = await contentStream.ReadAsync(buffer)) > 0)
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, read));
                    totalRead += read;
                    if (totalBytes > 0)
                    {
                        progress?.Report((double)totalRead / totalBytes);
                    }
                }
                return tempPath;
            }
        }
    }
}
