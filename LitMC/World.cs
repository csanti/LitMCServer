using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network;
using LitMC.Data;
using LitMC.Utils;

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

        private Position SpawnPosition;

        public World()
        {
            DefaultGameMode = 0;
            Difficulty = 0;
            LevelType = "flat";
            MapSeed = 10;
            ServerMode = 1;
            WorldHeight = 128;
            WorldMaxPlayers = 20;
            SpawnPosition = new Position(5, 20, 5, 0, 0, false);
        }

        public bool JoinWorld(Connection connection)
        {
            Connections.Add(connection);
            return true;
        }

        public Position GetSpawnPosition()
        {
            return SpawnPosition;
        }
        public void ChangeSpawnPosition(Position newSpawnPosition)
        {
            //notify players?
            SpawnPosition = newSpawnPosition; //cuidado al pasar referencia
        }
    }
}
