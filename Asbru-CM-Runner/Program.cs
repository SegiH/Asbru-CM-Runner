using System;
using System.Diagnostics;
using System.IO;

namespace Asbru_CM_Runner {
    class Program
    {
        static void Main(string[] args)
        {
            _ = new AsbruCMRunner(args);

            System.Environment.Exit(0);
        }
     }
}
