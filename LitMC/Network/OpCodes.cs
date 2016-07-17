using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network.Packets.ServerBound;

namespace LitMC.Network
{
    public class OpCodes
    {
        public static Dictionary<byte, Type> ServerBound = new Dictionary<byte, Type>();
        public static Dictionary<Type, byte> ClientBound = new Dictionary<Type, byte>();

        public static void Init()
        {
            ServerBound.Add(0x00, typeof(SbPacketHandshake));
        }
    }
}
