using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Data;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbRespawn : CbPacket
    {        
        private long MapSeed;
        private int ServerMode;
        private sbyte Dimension;
        private sbyte Difficulty;
        private byte WorldHeight;
        

        public CbRespawn(Player player, World world)
        {            
            MapSeed = world.MapSeed;
            ServerMode = world.ServerMode;
            Dimension = player.Dimension;
            Difficulty = world.Difficulty;
            WorldHeight = world.WorldHeight;            
        }
        protected override void Write(BinaryWriter writer)
        {
            writer.Write(Dimension);
            writer.Write(Difficulty);
            writer.Write(ServerMode);
            WriteInt16(writer, WorldHeight);
            WriteLong(writer, MapSeed);
        }
    }
}
