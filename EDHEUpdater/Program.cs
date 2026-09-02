using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EDHEUpdater
{
    internal static class Program
    {
        static async Task<int> Main(string[] args)
        {
            int pid = int.Parse(GetArg(args, "--wait-pid"));
            string installerPath = GetArg(args, "--installer");
            string relaunchPath = GetArg(args, "--relaunch");

            try
            {
                var process = Process.GetProcessById(pid);
                process.WaitForExit(15000); //timeout safety net
            }
            catch (ArgumentException)
            {
                //already exited
            }

            await Task.Delay(1000);

            var installProcess = Process.Start(new ProcessStartInfo
            {
                FileName = installerPath,
                Arguments = "", 
                UseShellExecute = true,
                Verb = "runas" 
            });
            installProcess.WaitForExit();

            try { File.Delete(installerPath); } catch { }

            Process.Start(new ProcessStartInfo
            {
                FileName = relaunchPath,
                UseShellExecute= true
            });

            return 0;
        }

        static string GetArg(string[] args, string name)
        {
            var idx = Array.IndexOf(args, name);
            return idx >= 0 && idx + 1 < args.Length ? args[idx + 1] : null;
        }
    }
}
