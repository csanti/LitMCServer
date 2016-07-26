using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{   
    public class CbSpawnPosition : CbPacket
    {
        private int X, Y, Z;

        public CbSpawnPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        protected override void Write(BinaryWriter writer)
        {
            WriteInt(writer, X);
            WriteInt(writer, Y);
            WriteInt(writer, Z);
        }
    }
}
