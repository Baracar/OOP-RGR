using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_RGR
{
    class GraviObj
    {
        //private int mass;
        //private int[] loc;
        private int[] speed;
        //private int[] accel;


        public void changeAll(int[] d)
        {
            speed[0] += d[0];
            speed[1] += d[1];
            speed[2] += d[2];
            Loc[0] += speed[0];
            Loc[1] += speed[1];
            Loc[2] += speed[2];
        }
        public void changeAll(int dx, int dy, int dz)
        {
            speed[0] += dx;
            speed[1] += dy;
            speed[2] += dz;
            Loc[0] += speed[0];
            Loc[1] += speed[1];
            Loc[2] += speed[2];
        }

        public int Mass { get; private set; }
        public int[] Loc { get; private set; }

        public GraviObj(int _mass, int x, int y, int z, int dx, int dy, int dz)
        {
            Mass = _mass;
            Loc = new int[3] { x, y, z };
            speed = new int[3] { dx, dy, dz };
            //accel = new int[3] { 0, 0, 0 };
        }
    }
}
