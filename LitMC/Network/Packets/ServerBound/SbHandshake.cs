using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;
using System.IO;

namespace LitMC.Network.Packets.ServerBound
{
    public class SbHandshake : SbPacket
    {
        private string username;

        public override void Process()
        {
            Log.Debug("[PACKET] LoginStart - Username: {0}", username);
            
        }

        public override void Read(BinaryReader reader)
        {
            username = ReadString();
        }
    }
}
