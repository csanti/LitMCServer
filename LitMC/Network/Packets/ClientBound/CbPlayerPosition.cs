using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbPlayerPosition : CbPacket
    {
        private Position Position;
        public CbPlayerPosition(Position position)
        {
            Position = position;
        }

        protected override void Write(BinaryWriter writer)
        {
            WriteDouble(writer, Position.X);
            WriteDouble(writer, Position.Y);
            WriteDouble(writer, Position.Z);
            WriteFloat(writer, Position.Yaw);
            WriteFloat(writer, Position.Pitch);
            WriteUByte(writer, 0x00);
            WriteVarInt(writer, 5);//TeleportId, deberia ser un id aleatorio 
            
        }
    }
}
