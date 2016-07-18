using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;

namespace LitMC.Network.Packets.ServerBound
{
    public class SbEncriptionKeyResponse : SbPacket
    {
        byte[] SharedSecret;
        byte[] Token;

        public override void Process()
        {
            Log.Info("[PACKET] Encription Response - No implementado!");
        }

        public override void Read()
        {
            SharedSecret = ReadBytes();
            Token = ReadBytes();
        }
    }
}
