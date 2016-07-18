using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbSpawnLocation : CbPacket
    {
        protected override void Write(BinaryWriter writer)
        {
            WritePosition(writer, 0, 0, 0);
        }
    }
}
