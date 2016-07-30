using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Data.Interfaces;
using LitMC.Utils;
using System.IO;
using System.Text;

namespace LitMC.Network
{
    public abstract class SbPacket : ISbPacket
    {
        protected Connection Connection;
        

        public void Process(Connection connection)
        {
            Connection = connection;                                    

            try
            {
                using (MemoryStream Stream = new MemoryStream(connection.Buffer))
                {
                    Stream.Position = 0;
                    using (BinaryReader Reader = new BinaryReader(Stream, new UnicodeEncoding(true, false)))
                    {
                        Read(Reader);
                    }
                }
                Process();
            }
            catch(Exception ex)
            {
                Log.Warn("Error al procesar/leer paquete");
                Log.WarnException("SbPacket", ex);
            }

        }

        protected string ReadString(BinaryReader reader)
        {            
            var count = ReadInt16(reader);
            char[] chars = reader.ReadChars(count);
            return new string(chars);
        }

        protected int ReadInt(BinaryReader reader)
        {
            byte[] intB = reader.ReadBytes(4);
            Array.Reverse(intB);
            return BitConverter.ToInt32(intB, 0);
        }

        protected int ReadInt16(BinaryReader reader)
        {
            byte[] intB = reader.ReadBytes(2);
            Array.Reverse(intB);
            return BitConverter.ToInt16(intB, 0);
        }

        protected double ReadDouble(BinaryReader reader)
        {
            byte[] doubleB = reader.ReadBytes(8);
            Array.Reverse(doubleB);
            return BitConverter.ToDouble(doubleB, 0);
        }
        protected float ReadFloat(BinaryReader reader)
        {
            byte[] singleB = reader.ReadBytes(4);
            Array.Reverse(singleB);
            return BitConverter.ToSingle(singleB, 0);
        }


        public abstract void Read(BinaryReader reader);
        public abstract void Process();

    }
}
