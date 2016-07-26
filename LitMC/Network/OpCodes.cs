using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network.Packets.ServerBound;
using LitMC.Network.Packets.ClientBound;

namespace LitMC.Network
{
    public class OpCodes
    {
        public static Dictionary<byte, Type> ServerBound = new Dictionary<byte, Type>();
        public static Dictionary<Type, byte> ClientBound = new Dictionary<Type, byte>();

        public static void Init()
        {
            
            ServerBound.Add(0x02, typeof(SbHandshake));
            ServerBound.Add(0x01, typeof(SbLoginRequest));
            ServerBound.Add(0x0D, typeof(SbPlayerPositionAndLook));

            ClientBound.Add(typeof(CbHandshake), 0x02);
            ClientBound.Add(typeof(CbDisconnect), 0xFF);
            ClientBound.Add(typeof(CbLoginRequest), 0x01);
            ClientBound.Add(typeof(CbMapChunk), 0x33);
            ClientBound.Add(typeof(CbSpawnPosition), 0x06);
            ClientBound.Add(typeof(CbPlayerPositionAndLook), 0x0D);
            ClientBound.Add(typeof(CbRespawn), 0x09);
            ClientBound.Add(typeof(CbPreChunk), 0x32);

            //ClientBound.Add(typeof(CbEncryptionKeyRequest), 0x01);
            //ClientBound.Add(typeof(CbLoginSuccess), 0x02);
            //ClientBound.Add(typeof(CbSpawnLocation), 0x43);
            //ClientBound.Add(typeof(CbJoinGame), 0x23);
            //ClientBound.Add(typeof(CbPlayerPosition), 0x2E);
        }
    }
}
