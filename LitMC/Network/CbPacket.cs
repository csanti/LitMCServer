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

            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream, new UTF8Encoding()))
                {
                    //escribir length y opcode

                    //escribir datos del paquete
                    Write(writer);                    
                }
                Log.Debug("Enviando: {0}", BitConverter.ToString(stream.ToArray()));
            }
            
            
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
