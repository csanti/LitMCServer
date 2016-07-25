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
        protected BinaryReader Reader;

        public void Process(Connection connection)
        {
            Connection = connection;                                    

            try
            {
                using (MemoryStream Stream = new MemoryStream(connection.Buffer))
                {
                    Stream.Position = 0;
                    using (Reader = new BinaryReader(Stream, new UnicodeEncoding(true, false)))
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

        protected string ReadString()
        {
            byte[] stringLengthB = Reader.ReadBytes(2);
            Array.Reverse(stringLengthB);
            var count = BitConverter.ToInt16(stringLengthB, 0);  
            char[] chars = Reader.ReadChars(count);
            return new string(chars);
        }



        public abstract void Read(BinaryReader reader);
        public abstract void Process();

    }
}
