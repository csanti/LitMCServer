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
            byte[] packet;           

            //TODO: Optimizar

            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter Writer = new BinaryWriter(stream, new UnicodeEncoding(true, false)))
                {
                    Writer.Write(OpCodes.ClientBound[GetType()]);           
                    Write(Writer);                    
                }
                packet = stream.ToArray();
            }  

            //Log.Debug("Enviando - ID: {0} Paquete: {1}", OpCodes.ClientBound[GetType()], BitConverter.ToString(packet));

            connection.PushPacket(packet);           
        }

        protected abstract void Write(BinaryWriter writer);

        protected void WriteInt(BinaryWriter writer, int data)
        {
            byte[] intB = BitConverter.GetBytes(data);
            Array.Reverse(intB);
            writer.Write(intB);
        }
        protected void WriteInt16(BinaryWriter writer, int data)
        {
            Int16 int16 = Convert.ToInt16(data);
            byte[] intB = BitConverter.GetBytes(int16);
            Array.Reverse(intB);
            writer.Write(intB);
        }

        protected void WriteString(BinaryWriter writer, string data)
        {
            //Write int16 bendian
            WriteInt16(writer, data.Length);
            writer.Write(data.ToCharArray());
        }
        protected void WriteLong(BinaryWriter writer, long data)
        {
            byte[] longB = BitConverter.GetBytes(data);
            Array.Reverse(longB);
            writer.Write(longB);
        }
    }
}
