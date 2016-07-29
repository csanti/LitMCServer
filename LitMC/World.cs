using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network;
using LitMC.Data;

namespace LitMC
{
    public class World
    {
        public byte DefaultGameMode;
        public sbyte Difficulty;
        public string LevelType;
        public long MapSeed;
        public int ServerMode;
        public byte WorldHeight;
        public byte WorldMaxPlayers;             

        public List<Connection> Connections = new List<Connection>();

        public World()
        {
            DefaultGameMode = 0;
            Difficulty = 0;
            LevelType = "flat";
            MapSeed = 10;
            ServerMode = 1;
            WorldHeight = 128;
            WorldMaxPlayers = 20;
        }

        public bool JoinWorld(Connection connection)
        {
            Connections.Add(connection);
            return true;
        }
    }
}
