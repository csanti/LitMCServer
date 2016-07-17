using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Data.Interfaces;
using System.IO;

namespace LitMC.Network
{
    public abstract class CbPacket : ICbPacket
    {
        byte[] Data;

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
            }
            
            
            //pushpacket
        }

        protected abstract void Write(BinaryWriter writer);

        protected void WriteVarInt(int data)
        {
            
        }

        protected void WriteString(BinaryWriter writer, string data)
        {
            writer.Write(data);
        }
    }
}
