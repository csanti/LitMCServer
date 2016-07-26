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

            Position = new Position(0, 0, 0, 0f, 0f);
            Dimension = 0;            
        }

        public void Join()
        {
            Global.World.JoinWorld(Connection);
            new CbLoginRequest(this, Global.World).Send(Connection);
            Log.Debug("{0} Joined World", Username);
            
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
