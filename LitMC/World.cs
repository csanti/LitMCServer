using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC
{
    public class World
    {
        public byte DefaultGameMode;
        public byte Difficulty;
        public string LevelType;

        public World()
        {
            DefaultGameMode = 0;
            Difficulty = 0;
            LevelType = "flat";
        }
    }
}
