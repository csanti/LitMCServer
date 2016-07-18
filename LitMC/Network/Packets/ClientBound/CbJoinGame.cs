using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Data;
using LitMC.Utils;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbJoinGame : CbPacket
    {
        private Player Player;
        public CbJoinGame(Player player)
        {
            Player = player;
        }

        protected override void Write(BinaryWriter writer)
        {           
            WriteInt(writer, Player.EID);
            WriteUByte(writer, Player.GameMode);
            WriteInt(writer, Player.Dimension);
            WriteUByte(writer, Global.World.Difficulty);
            WriteUByte(writer, (byte)Configuration.MaxConnections);
            WriteString(writer, Global.World.LevelType);
            WriteBoolean(writer, false);
        }
    }
}
