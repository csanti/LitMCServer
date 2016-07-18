using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Utils
{
    public class Configuration
    {
        public static string ServerIP = "127.0.0.1";
        public static int ServerPort = 25565;
        public static int MaxConnections = 20;
        public static bool EncryptionEnabled = false;
        public static bool OnlineMode = false;
        public static bool CompressionEnabled = false;

        public static void LoadConfiguration()
        {
            Log.Info("LoadConfiguration no implementada todavia!");
        }
    }
}
