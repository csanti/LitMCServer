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
        protected MemoryStream Stream;

        public void Process(Connection connection)
        {
            Stream = new MemoryStream(connection.Buffer);
            Stream.Position = 0;
            Connection = connection;
            Read();

            try
            {
                Process();
            }
            catch(Exception ex)
            {
                Log.Warn("Error al procesar paquete ServerBound");
                Log.WarnException("SbPacket", ex);
            }

        }

        public abstract void Read();
        public abstract void Process();

        protected string ReadString()
        {
            string result = null;
            int stringLength = ReadVarInt();
            byte[] content = new byte[stringLength];
            try
            {
                Stream.Read(content, 0, stringLength);
                result = Encoding.UTF8.GetString(content, 0, content.Length);
            }
            catch (Exception ex)
            {
                Log.WarnException("SbPacket-ReadString ", ex);
            }
            
            return result;     
        }
        protected int ReadVarInt()
        {
            int result = 0;
            byte[] varIntRaw = new byte[Stream.Length - Stream.Position];
            try
            {
                Stream.Read(varIntRaw, 0, (int)Stream.Length - (int)Stream.Position);
                Stream.Position -= varIntRaw.Length;
                result = (int)VarintBitConverter.ToUInt16(varIntRaw);
                int offset = (int)(result / 256) + 1;
                Stream.Position += offset;
            }
            catch (Exception ex)
            {
                Log.WarnException("SbPacket-ReadVarInt ", ex);
            }            
            return result;
        }
    }
}
