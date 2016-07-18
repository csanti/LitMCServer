using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Server;
using LitMC.Utils;
using System.Security.Cryptography;

namespace LitMC.Network
{
    public class TcpServer
    {
        private string BindAddress;
        private int BindPort;
        private int MaxConnections;

        public IScsServer Server;

        protected RSACryptoServiceProvider CryptoServiceProvider;
        public static RSAParameters ServerKey;

        public TcpServer(string bindAddress, int bindPort, int maxConnections)
        {
            BindAddress = bindAddress;
            BindPort = bindPort;
            MaxConnections = maxConnections;

            CryptoServiceProvider = new RSACryptoServiceProvider(1024);
            ServerKey = CryptoServiceProvider.ExportParameters(true);
        }

        public void BeginListening()
        {
            Log.Info("Servidor escuchando en: {0}:{1}", BindAddress, BindPort);
            Server = ScsServerFactory.CreateServer(new ScsTcpEndPoint(BindAddress, BindPort));
            Server.Start();

            Server.ClientConnected += OnConnected;
            Server.ClientDisconnected += OnDisconnected;
        }

        public void OnConnected(object sender, ServerClientEventArgs e)
        {
            Log.Info("Cliente conectado");
            new Connection(e.Client);
        }

        public void OnDisconnected(object sender, ServerClientEventArgs e)
        {
            Log.Info("Cliente desconectado (TcpServer)");
        }

        public void ShutDownTcpServer()
        {
            Log.Info("Parando el servidor...");
            Server.Stop();
        }
    }
}
