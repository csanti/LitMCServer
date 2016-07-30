using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Utils;

namespace LitMC.Network.Packets.ClientBound
{
    public class CbPlayerPositionAndLook : CbPacket
    {
        private double X, Stance, Y, Z;
        private float Yaw, Pitch;
        private bool OnGround; 
        
        public CbPlayerPositionAndLook(Position position)
        {
            X = position.X;
            Y = position.Y;
            Z = position.Z;
            Stance = position.Stance;
            Yaw = position.Yaw;
            Pitch = position.Pitch;
            OnGround = position.OnGround;
        }  

        protected override void Write(BinaryWriter writer)
        {
            WriteDouble(writer, X);
            WriteDouble(writer, Stance);
            WriteDouble(writer, Y);
            WriteDouble(writer, Z);
            WriteFloat(writer, Yaw);
            WriteFloat(writer, Pitch);
            writer.Write(OnGround);
        }
    }
}
