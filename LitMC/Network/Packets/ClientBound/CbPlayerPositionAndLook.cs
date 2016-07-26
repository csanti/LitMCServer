using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbPlayerPositionAndLook : CbPacket
    {
        private double X, Stance, Y, Z;
        private float Yaw, Pitch;
        private bool OnGround;        

        protected override void Write(BinaryWriter writer)
        {
            writer.Write((double)0);
            writer.Write((double)0);
            writer.Write((double)0);
            writer.Write((double)0);
            writer.Write(0f);
            writer.Write(0f);
            writer.Write(true);
        }
    }
}
