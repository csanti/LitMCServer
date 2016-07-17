using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;
using LitMC.Network;
using System.Diagnostics;

namespace LitMC
{
    class LitServer
    {
        private static TcpServer TcpServer;

        static void Main(string[] args)
        {
            Console.Title = "LitMC Server";

            try
            {
                RunServer();
            }
            catch(Exception ex)
            {
                Log.FatalException("No se puede arrancar el servidor", ex);
            }

            Console.ReadLine();
            ShutDownServer();            
        }

        private static void RunServer()
        {
            Stopwatch serverStartStopwatch = Stopwatch.StartNew();
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            OpCodes.Init();

            TcpServer = new TcpServer("127.0.0.1", 25565, 20); //TODO: cargar desde configuración
            
            TcpServer.BeginListening();
            serverStartStopwatch.Stop();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("---===== GameServer iniciado en {0}", (serverStartStopwatch.ElapsedMilliseconds / 1000.0).ToString("0.00s"));
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        private static void ShutDownServer()
        {
            TcpServer.ShutDownTcpServer();
        }

        private static void UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            Log.FatalException("UnhandledException", (Exception)e.ExceptionObject);
            ShutDownServer();
        }
    }
}
