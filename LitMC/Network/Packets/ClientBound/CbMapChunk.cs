using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Generator;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbMapChunk : CbPacket
    {
        protected override void Write(BinaryWriter writer)
        {
            WriteInt(writer, 0);
            WriteInt16(writer, 0);
            WriteInt(writer, 0);
            writer.Write((byte)0x0F);
            writer.Write((byte)0x0F);
            writer.Write((byte)0x0F);
            byte[] data = Chunk.generateSimpleChunk(0x10, 0x10, 0x10);
            WriteInt(writer, data.Length);
            writer.Write(data);
        }
    }
}
