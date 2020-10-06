using System;
using System.Diagnostics;
using System.IO;

namespace Asbru_CM_Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmingPath = "C:\\Progra~2\\Xming\\Xming.exe";
            string bashPath = "C:\\Windows\\System32\\bash.exe";

            if (args.Length > 0) {
                for (int i = 0; i < args.Length; i++) {
                    if (args[i].ToString().StartsWith("--xmingPath") && args[i].ToString().EndsWith("xming.exe")) {
                        xmingPath = args[0].ToString().Split("=")[1];
                    } else if (args[i].ToString().StartsWith("--bashPath") && args[i].ToString().EndsWith("bash.exe")) {
                        bashPath = args[0].ToString().Split("=")[1];
                    }
                }
            }

            if (!File.Exists(xmingPath)) {
                Console.WriteLine("Unable to locate Xming. Please set the path to Xming with --xmingpath=C:\\Progra~2\\Xming\\Xming.exe");
                System.Environment.Exit(1);
            }

            if (!File.Exists(bashPath)) {
                Console.WriteLine("Unable to locate bash.exe. Please set the path to Xming with --bashpath=C:\\Windows\\System32\\bash.exe");
                System.Environment.Exit(1);
            }


            Process process = new Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Start Xming so we can use Linux GUI apps with WSL
            process.StartInfo.FileName = xmingPath;
            process.StartInfo.Arguments = ":0 -clipboard -multiwindow";

            process.Start();

            process.StartInfo.FileName = bashPath;
            process.StartInfo.Arguments = "-c \"export DISPLAY=:0; asbru-cm\"";

            process.Start();            
        }
    }
}
