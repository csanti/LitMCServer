using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitMC.Network.Packets.ClientBound;
using LitMC.Utils;

namespace LitMC.Network.Packets.ServerBound
{
    public class SbPlayerPositionAndLook : SbPacket
    {
        private double X, Y, Stance, Z;
        private float Yaw, Pitch;
        private bool OnGround;

        public override void Process()
        {
            //Log.Debug("[PlayerPosition&Look] X: {0} Y: {1} Z: {2} Stance: {3} Yaw: {4} Pitch: {5} OnGround: {6}", X, Y, Z, Stance, Yaw, Pitch, OnGround.ToString());
        }

        public override void Read(BinaryReader reader)
        {
            X = ReadDouble(reader);
            Y = ReadDouble(reader);
            Stance = ReadDouble(reader);
            Z = ReadDouble(reader);
            Yaw = ReadFloat(reader);
            Pitch = ReadFloat(reader);
            OnGround = reader.ReadBoolean();
        }
    }
}
