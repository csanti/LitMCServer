using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbPreChunk : CbPacket
    {
        protected override void Write(BinaryWriter writer)
        {
            WriteInt(writer, 0);
            WriteInt(writer, 0);
            writer.Write(true);
        }
    }
}
