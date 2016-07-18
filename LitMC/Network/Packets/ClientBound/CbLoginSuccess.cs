using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbLoginSuccess : CbPacket
    {
        protected override void Write(BinaryWriter writer)
        {
            Guid playerUUID = Guid.NewGuid();
            WriteString(writer, playerUUID.ToString());
            WriteString(writer, "Username");
        }
    }
}
