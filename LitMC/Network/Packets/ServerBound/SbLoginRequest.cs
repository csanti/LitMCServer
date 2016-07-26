using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;
using LitMC.Network.Packets.ClientBound;

namespace LitMC.Network.Packets.ServerBound
{
    public class SbLoginRequest : SbPacket
    {
        private int ProtocolVersion;
        private string Username;

        public override void Process()
        {
            Log.Debug("[PACKET] LoginRequest - ProtocolVersion: {0} Username: {1}", ProtocolVersion, Username);
            
            if(ProtocolVersion != Configuration.ProtocolVersion)
            {
                new CbDisconnect("Versión del protocolo no soportada!").Send(Connection);
                //Connection.Close();
                return;               
            }

            Connection.SetPlayer(Username);



        }

        public override void Read(BinaryReader reader)
        {            
            ProtocolVersion = ReadInt(reader);
            Username = ReadString(reader);
        }
    }
}
