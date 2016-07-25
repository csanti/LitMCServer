using System.Collections.Generic;
using System.IO;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Communication.Protocols;
using LitMC.Network.Messages;



using System.Text;
using System;

namespace LitMC.Network.Protocols
{
    class RawProtocol : IScsWireProtocol
    {
        protected MemoryStream Stream = new MemoryStream();
        

        public byte[] GetBytes(IScsMessage message)
        {
            return ((MinecraftProtocolMessage)message).Data;
        }

        public IEnumerable<IScsMessage> CreateMessages(byte[] receivedBytes)
        {
            if(receivedBytes.Length < 1)
            {
                return null;
            }

            List<IScsMessage> messages = new List<IScsMessage>();
            MinecraftProtocolMessage message = new MinecraftProtocolMessage();            
            message.PacketId = receivedBytes[0];

            if (receivedBytes.Length > 1)
            {
                byte[] data = new byte[receivedBytes.Length - 1];
                Buffer.BlockCopy(receivedBytes, 1, data, 0, data.Length);
                message.Data = data;
            }  
            else
            {
                message.Data = new byte[1]; //Relleno data para que no de error en paquete de Ping (que no contiene datos)
            }
            
            messages.Add(message);

            return messages;
        }

        public void Reset()
        {

        }

        // Solo se transporta un mensaje por paquete, esto es innecesario en esta versión del protocolo
        //private bool ReadMessage(List<IScsMessage> messages)
        //{
        //    Stream.Position = 0;

        //    if(Stream.Length < 1)
        //    {
        //        return false;
        //    }
            

            
        //    byte packetId;
        //    Stream.Read(packetId, 0, 0);

        //    MinecraftProtocolMessage message = new MinecraftProtocolMessage { Data = new byte[Stream.Length - 1] };
        //    message.PacketId = packetId[0];

        //    Stream.Position = offset + 1;
        //    Stream.Read(message.Data, 0, packetLenght - 1);

        //    messages.Add(message);
        //    TrimStream();

        //    return true;
        //}

        //private void TrimStream()
        //{
        //    if (Stream.Position == Stream.Length)
        //    {
        //        Stream = new MemoryStream();
        //        return;
        //    }

        //    byte[] remaining = new byte[Stream.Length - Stream.Position];
        //    Stream.Read(remaining, 0, remaining.Length);
        //    Stream = new MemoryStream();
        //    Stream.Write(remaining, 0, remaining.Length);
        //}


    }
}

