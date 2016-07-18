using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network;
using LitMC.Data;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbLoginSuccess : CbPacket
    {
        private Player Player;
        
        public CbLoginSuccess(Player player)
        {
            Player = player;
        }

        protected override void Write(BinaryWriter writer)
        {            
            WriteString(writer, Player.UUID);
            WriteString(writer, Player.Username);
        }
    }
}
