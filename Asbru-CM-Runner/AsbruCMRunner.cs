using System;
using System.Diagnostics;
using System.IO;

namespace Asbru_CM_Runner
{
    class AsbruCMRunner {
        public AsbruCMRunner(string[] args)
        {
            const string asbruCMBinary = "asbru-cm";
            string wslGPath = $"{Environment.GetEnvironmentVariable("windir")}\\system32\\wslg.exe";
            string bashPath = "C:\\Windows\\System32\\bash.exe";
            string xmingPath = "C:\\Progra~2\\Xming\\Xming.exe";
            bool skipXMing = false; // XMing is not needed when using WSLg

            // Check if command line arguments were passed to override xming and Bash path
            if (args.Length > 0)
            {
                if (args[0].ToString().StartsWith("--xmingPath") && args[0].ToString().EndsWith("xming.exe"))
                {
                    xmingPath = args[0].ToString().Split("=")[1];
                }

                if (args[0].ToString().StartsWith("--bashPath") && args[0].ToString().EndsWith("bash.exe"))
                {
                    bashPath = args[0].ToString().Split("=")[1];
                }

                if (args[0].ToString().StartsWith("--skip-xming") && (args[0].ToString().EndsWith("true") || args[0].ToString().EndsWith("false")))
                {
                    skipXMing = args[0].ToString().Split("=")[1] == "true";
                }
            }

            if (File.Exists(wslGPath))
            {
                skipXMing = true;
            }

            // Make sure XMing exists
            if (!File.Exists(xmingPath) && !skipXMing)
            {
                Console.WriteLine("Unable to locate Xming. Please set the path to Xming with --xmingpath=C:\\Progra~2\\Xming\\Xming.exe");
                System.Environment.Exit(1);
            }

            // Make sure bash exists
            if (!File.Exists(bashPath))
            {
                Console.WriteLine("Unable to locate bash.exe. Please set the path to bash.exe with --bashpath=C:\\Windows\\System32\\bash.exe");
                System.Environment.Exit(1);
            }

            // Make sure asbru-cm is installed
            string result = ExecuteProcess(bashPath, $"-c \"whereis -b {asbruCMBinary}\"", true);
            result = result.Replace(asbruCMBinary + ":\n", "");

            if (result.Length == 0)
            {
                Console.WriteLine($"Unable to locate {asbruCMBinary} binary. Is Asbru-CM installed in WSL?");
                System.Environment.Exit(1);
            }

            if (!skipXMing)
            {
                ExecuteProcess(xmingPath, ":0 -clipboard -multiwindow");
            }

            string bashArg = (!skipXMing ? $"-c \"export DISPLAY=:0; {asbruCMBinary}\"" : $"-c \"{asbruCMBinary}\"");

            ExecuteProcess(bashPath, bashArg);
        }

        static string ExecuteProcess(string fileName, string arguments, bool waitForResults = false)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = waitForResults,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            if (waitForResults)
            {
                string output = proc.StandardOutput.ReadToEnd();
                return output;
            }
            else
            {
                return "";
            }
        }
    }
}
