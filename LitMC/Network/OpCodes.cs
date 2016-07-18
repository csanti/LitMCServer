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
            ServerBound.Add(0x00, typeof(SbPacketHandshake));
            ServerBound.Add(0x01, typeof(SbEncriptionKeyResponse));

            ClientBound.Add(typeof(CbEncryptionKeyRequest), 0x01);
            ClientBound.Add(typeof(CbLoginSuccess), 0x02);
            ClientBound.Add(typeof(CbSpawnLocation), 0x43);
            ClientBound.Add(typeof(CbJoinGame), 0x23);
        }
    }
}
