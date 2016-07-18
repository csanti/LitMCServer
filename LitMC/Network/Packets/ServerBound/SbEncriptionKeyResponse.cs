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
            Log.Debug("[PACKET] Encription Response - SharedSecret: {0} Token: {1}", BitConverter.ToString(SharedSecret), BitConverter.ToString(Token));
        }

        public override void Read()
        {
            SharedSecret = ReadBytes();
            Token = ReadBytes();
        }
    }
}
