using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;

namespace LitMC.Network.Packets.ServerBound
{
    public class SbPacketHandshake : SbPacket
    {
        private int ProtocolVersion;
        private string Address;

        public override void Process()
        {
            Log.Debug("[PACKET] Handshake - ProtocolVersion: {0} Address: {1}", ProtocolVersion, Address);            
            Connection.HandshakeState = 1;
        }

        public override void Read()
        {
            ProtocolVersion = ReadVarInt();
            Address = ReadString();            
        }
    }
}
