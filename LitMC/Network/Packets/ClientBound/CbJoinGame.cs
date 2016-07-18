using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbJoinGame : CbPacket
    {
        protected override void Write(BinaryWriter writer)
        {
           
            WriteInt(writer, BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            WriteUByte(writer, 0x00);
            WriteInt(writer, 0);
            WriteUByte(writer, 0x00);
            WriteUByte(writer, 0x09);
            WriteString(writer, "default");
            WriteBoolean(writer, false);
        }
    }
}
