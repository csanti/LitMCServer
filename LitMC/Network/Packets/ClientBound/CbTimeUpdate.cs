using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbTimeUpdate : CbPacket
    {
        private long Time;
        public CbTimeUpdate(long time)
        {
            Time = time;
        }
        protected override void Write(BinaryWriter writer)
        {
            WriteLong(writer, Time);
        }
    }
}
