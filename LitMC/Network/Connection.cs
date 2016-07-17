using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Data.Interfaces;
using LitMC.Data;
using System.Threading;
using System.Net.NetworkInformation;
using Hik.Communication.Scs.Communication;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Server;
using Hik.Communication.Scs.Communication.Protocols.BinarySerialization;
using Hik.Communication.Scs.Communication.Messages;
using LitMC.Utils;
using LitMC.Network.Protocols;
using LitMC.Network.Packets.ServerBound;
using LitMC.Network.Messages;

namespace LitMC.Network
{
    public class Connection : IConnection
    {
        public static List<Connection> Connections = new List<Connection>();
        public static Thread SendAllThread = new Thread(SendAll);

        private static void SendAll()
        {

        }


        public Player Player { get; set; }

        private IScsServerClient Client;
        private string RemoteEndPoint;

        public byte[] Buffer;

        public short HandshakeState;  

        public Connection(IScsServerClient client)
        {
            Client = client;
            Client.WireProtocol = new RawProtocol();
            RemoteEndPoint = Client.RemoteEndPoint.ToString().Substring(6);            

            Client.Disconnected += OnDisconnected;
            Client.MessageReceived += OnMessageReceived;

            HandshakeState = 0;

            Connections.Add(this);
            Log.Info("Creada conexión con: {0}", RemoteEndPoint);

        }

        private void OnMessageReceived(object sender, MessageEventArgs e)
        {
            Log.Info("Mensaje recibido de: {0}", RemoteEndPoint);

            MinecraftProtocolMessage message = (MinecraftProtocolMessage)e.Message;
            Buffer = message.Data;
            if(HandshakeState == 2 && OpCodes.ServerBound.ContainsKey(message.PacketId))
            {
                Log.Debug("ID: {0}  -  Data: {1}", message.PacketId.ToString(), BitConverter.ToString(message.Data));
                ((SbPacket)Activator.CreateInstance(OpCodes.ServerBound[message.PacketId])).Process(this);
            }
            else if(HandshakeState == 0 && message.PacketId == 0x00)
            {
                //Handshake packet
                new SbPacketHandshake().Process(this);
            }
            else if(HandshakeState == 1 && message.PacketId == 0x00)
            {
                //Login Start
                new SbPacketLoginStart().Process(this);
                
            }
            else
            {
                Log.Debug("Packete con ID desconocido");
            }

            
        }
        private void OnDisconnected(object sender, EventArgs e)
        {
            Player = null;
            Buffer = null;
            Client = null;
            Log.Info("Cliente desconectado en: {0}", RemoteEndPoint);
        }
        public void PushPacket(byte[] data)
        {

        }

        public long Ping()
        {
            Ping ping = new Ping();
            
            string ipAddress = RemoteEndPoint.Substring(0, RemoteEndPoint.IndexOf(':'));           

            PingReply pingReply = ping.Send(ipAddress);

            return (pingReply != null) ? pingReply.RoundtripTime : 0;
        }

        public void Close()
        {
            Log.Info("Cerrando conexión de: {0}", RemoteEndPoint);
            Client.Disconnect();
        }


    }
}
