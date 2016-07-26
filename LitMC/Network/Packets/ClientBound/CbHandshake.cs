using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbHandshake : CbPacket
    {
        private bool Auth;
        public CbHandshake(bool auth)
        {
            Auth = auth;           
        }
        protected override void Write(BinaryWriter writer)
        {
            if(Auth)
            {
                //TODO: hash
            }
            else
            {
                WriteString(writer, "-");
            }
        }
    }
}
