using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitMC.Utils
{
    public class Position
    {
        public double X;
        public double Y;
        public double Z;
        public double Stance;
        public float Yaw;
        public float Pitch;
        public bool OnGround;

        public Position(double x, double y, double z, float yaw, float pitch, bool onGround)
        {
            X = x;
            Y = y;
            Z = z;
            Stance = y;
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
        }

        public Position GetCopy()
        {
            return new Position(X, Y, Z, Yaw, Pitch, OnGround);
        }
    }
}
