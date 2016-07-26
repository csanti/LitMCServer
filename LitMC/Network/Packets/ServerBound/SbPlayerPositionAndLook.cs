using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network.Packets.ClientBound;

namespace LitMC.Network.Packets.ServerBound
{
    public class SbPlayerPositionAndLook : SbPacket
    {
        public override void Process()
        {
            //new CbPreChunk().Send(Connection);
            //new CbMapChunk().Send(Connection);
            //new CbSpawnPosition(0, 0, 0).Send(Connection);
            new CbPlayerPositionAndLook().Send(Connection);
            //new CbRespawn(Connection.Player, Global.World).Send(Connection);
        }

        public override void Read(BinaryReader reader)
        {
            
        }
    }
}
