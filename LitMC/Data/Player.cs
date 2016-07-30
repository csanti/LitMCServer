using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network.Packets.ClientBound;
using LitMC.Network;
using LitMC.Utils;

namespace LitMC.Data
{
    public class Player
    {
        public string UUID;
        public int EID;       

        private Connection Connection;

        public string Username;

        public byte GameMode;
        public sbyte Dimension;

        public Position Position;
          
        
        public Player(string username, Connection connection)
        {
            Username = username;
            Connection = connection;
            Guid playerGUID = Guid.NewGuid();
            UUID = playerGUID.ToString();
            EID = BitConverter.ToInt32(playerGUID.ToByteArray(), 0);

            Position = new Position(0, 0, 0, 0f, 0f, false);
            Dimension = 0;            
        }

        public void Join()
        {
            Global.World.JoinWorld(Connection);
            new CbLoginRequest(this, Global.World).Send(Connection);
            Log.Debug("{0} Joined World", Username);

            Position = Global.World.GetSpawnPosition().GetCopy();

            new CbPreChunk().Send(Connection);
            new CbMapChunk().Send(Connection);
            //new CbSpawnPosition(0, 200, 0).Send(Connection);
            new CbTimeUpdate(6000).Send(Connection);
            new CbPlayerPositionAndLook(Position).Send(Connection);
            
            //new CbRespawn(Connection.Player, Global.World).Send(Connection);

            //new CbPlayerPosition(Position).Send(Connection);
        }

        public void StreamChunks()
        {
            //detectar los chunks que se tienen que enviar

            //generar chunks

            //enviar
        }
    }
}
