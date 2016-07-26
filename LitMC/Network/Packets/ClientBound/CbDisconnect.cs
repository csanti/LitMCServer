using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbDisconnect : CbPacket
    {
        private string Reason;
        public CbDisconnect(string reason)
        {
            Reason = reason;
        }
        protected override void Write(BinaryWriter writer)
        {
            WriteString(writer, Reason);
        }
    }
}
