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
            Stream.Write(receivedBytes, 0, receivedBytes.Length);

            List<IScsMessage> messages = new List<IScsMessage>();
            
            //int packetLenghtBytes = VarintBitConverter.
            
            while (ReadMessage(messages));
            

            return messages;
        }

        public void Reset()
        {
        }

        private bool ReadMessage(List<IScsMessage> messages)
        {
            Stream.Position = 0;

            if(Stream.Length < 2)
            {
                return false;
            }

            byte[] lenghtVarInt = new byte[Stream.Length];
            Stream.Read(lenghtVarInt, 0, (int)Stream.Length);
            Stream.Position = 0;

            int packetLenght = (int)VarintBitConverter.ToUInt16(lenghtVarInt);
            int offset = (int)(packetLenght / 256) + 1;
            Stream.Position = offset;
            byte[] packetIdByte = new byte[1];            
            Stream.Read(packetIdByte, 0, 1);            

            MinecraftProtocolMessage message = new MinecraftProtocolMessage { Data = new byte[packetLenght - 1] };
            message.PacketId = packetIdByte[0];

            Stream.Position = offset + 1;
            Stream.Read(message.Data, 0, packetLenght - 1);

            messages.Add(message);
            TrimStream();

            return true;
        }

        private void TrimStream()
        {
            if (Stream.Position == Stream.Length)
            {
                Stream = new MemoryStream();
                return;
            }

            byte[] remaining = new byte[Stream.Length - Stream.Position];
            Stream.Read(remaining, 0, remaining.Length);
            Stream = new MemoryStream();
            Stream.Write(remaining, 0, remaining.Length);
        }


    }
}

