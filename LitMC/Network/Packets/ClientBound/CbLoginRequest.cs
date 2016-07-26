using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Data;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbLoginRequest : CbPacket
    {
        private int EID;
        private long MapSeed;
        private int ServerMode;
        private sbyte Dimension;
        private sbyte Difficulty;
        private byte WorldHeight;
        private byte MaxPlayers;

        public CbLoginRequest(Player player, World world)
        {
            EID = player.EID;
            MapSeed = world.MapSeed;
            ServerMode = world.ServerMode;
            Dimension = player.Dimension;
            Difficulty = world.Difficulty;
            WorldHeight = world.WorldHeight;
            MaxPlayers = world.WorldMaxPlayers;
        }
        protected override void Write(BinaryWriter writer)
        {
            WriteInt(writer, EID);
            WriteString(writer,""); //not used
            WriteLong(writer, MapSeed);
            WriteInt(writer, ServerMode);
            writer.Write(Dimension);
            writer.Write(Difficulty);
            writer.Write(WorldHeight);
            writer.Write(MaxPlayers);

        }
    }
}
