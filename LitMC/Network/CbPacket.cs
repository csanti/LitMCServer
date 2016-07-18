using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Data.Interfaces;
using System.IO;
using LitMC.Utils;


namespace LitMC.Network
{
    public abstract class CbPacket : ICbPacket
    {
        

        public void Send(IConnection connection)
        {
            byte[] body;
            byte[] header;
            byte[] packet;

            using (MemoryStream bodyStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(bodyStream, new UTF8Encoding()))
                {                    
                    Write(writer);                    
                }
                

                body = bodyStream.ToArray();
            }

            using (MemoryStream headerStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(headerStream, new UTF8Encoding()))
                {
                    WriteVarInt(writer, (uint)(body.Length + 1));
                    writer.Write(OpCodes.ClientBound[GetType()]);
                }
                

                header = headerStream.ToArray();
            }

            int totalLenght = header.Length + body.Length;
            packet = new byte[totalLenght];
            header.CopyTo(packet, 0);
            body.CopyTo(packet, header.Length);

            Log.Debug("Enviando: {0}", BitConverter.ToString(packet.ToArray()));

            connection.PushPacket(packet);

            //pushpacket
        }

        protected abstract void Write(BinaryWriter writer);

        protected void WriteVarInt(BinaryWriter writer, uint data)
        {
            byte[] bytes = VarintBitConverter.GetVarintBytes(data);
            writer.Write(bytes);
        }

        protected void WriteString(BinaryWriter writer, string data)
        {
            writer.Write(data);
        }

        protected void WriteBytes(BinaryWriter writer, byte[] data)
        {
            WriteVarInt(writer, (uint)data.Length);
            writer.Write(data);
        }
    }
}
