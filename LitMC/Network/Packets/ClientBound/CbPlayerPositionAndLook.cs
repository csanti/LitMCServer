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
            writer.Write((double)200);
            writer.Write((double)200);
            writer.Write((double)200);
            writer.Write((double)200);
            writer.Write((float)0);
            writer.Write((float)0);
            writer.Write((byte)0x00);
        }
    }
}
