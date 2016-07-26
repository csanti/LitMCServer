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
            while (true)
            {
                for (int i = 0; i < Connections.Count; i++)
                {
                    try
                    {
                        if (!Connections[i].Send())
                        {
                            Connections.RemoveAt(i--);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorException("Connection: SendAll:", ex);
                    }
                }

                Thread.Sleep(10);
            }
        }


        public Player Player { get; set; }

        private IScsServerClient Client;
        private string RemoteEndPoint;

        public byte[] Buffer;

        public short HandshakeState;  

        public byte[] VerificationToken;

        private List<byte[]> DataToSend = new List<byte[]>();
        private int DataToSendSize;

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
            //Log.Info("Mensaje recibido de: {0}", RemoteEndPoint);

            MinecraftProtocolMessage message = (MinecraftProtocolMessage)e.Message;
            Buffer = message.Data;
            //Log.Debug("ID: {0}  -  Data: {1}", message.PacketId.ToString(), BitConverter.ToString(message.Data));

            if (OpCodes.ServerBound.ContainsKey(message.PacketId))
            {
                ((SbPacket)Activator.CreateInstance(OpCodes.ServerBound[message.PacketId])).Process(this);
            }
            else
            {                
                //Log.Debug("Packete con ID desconocido - ID: {0}", message.PacketId);
            }

            
        }
        private void OnDisconnected(object sender, EventArgs e)
        {
            Player = null;
            Buffer = null;
            Client = null;
            Log.Info("Cliente desconectado en: {0}", RemoteEndPoint);
        }
        public void PushPacket(byte[] packet)
        {
            DataToSend.Add(packet);
            DataToSendSize += packet.Length;
        }

        private bool Send()
        {
            if (DataToSend.Count == 0)
                return true;           

            //Un mensaje por Send
            for (int i = 0; i < DataToSend.Count; i++)
            {
                MinecraftProtocolMessage message = new MinecraftProtocolMessage { Data = DataToSend[i] };                             
                try
                {
                    Client.SendMessage(message);
                    Log.Debug("[ENVIADO] ID: {0} Tamaño: {1} bytes", message.Data[0], message.Data.Length);
                }
                catch
                {
                    return false; //conexion cerrada
                }
            }

            DataToSend.Clear();
            DataToSendSize = 0;

            
            return true;
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

        public void SetPlayer(string username)
        {
            Player = new Player(username, this);

            Player.Join();
        }


    }
}
