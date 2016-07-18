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
        public float Yaw;
        public float Pitch;

        public Position(double x, double y, double z, float yaw, float pitch)
        {
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
        }
    }
}
