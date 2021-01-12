using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OOP_RGR
{
    class GraviObj
    {
        public int Mass { get; private set; }
        public float[] Loc { get; private set; }
        public float[] Speed { get; private set; }
        public bool deleting;
        public int Rad { get; private set; }


        public void changeAll(float[] d)
        {
            Speed[0] += d[0];
            Speed[1] += d[1];
            Loc[0] += Speed[0];
            Loc[1] += Speed[1];
        }

        public void changeAll(float dx, float dy)
        {
            Speed[0] += dx;
            Speed[1] += dy;
            Loc[0] += Speed[0];
            Loc[1] += Speed[1];
        }
        public void changeSpeed(float[] d)
        {
            Speed[0] = d[0];
            Speed[1] = d[1];
        }
        public void changeLoc(float[] d)
        {
            Loc[0] += d[0];
            Loc[1] += d[1];
        }

        public void changeMass(int _mass)
        {
            Mass += _mass;
            Rad = (int)(Math.Sqrt(Mass)) * 3;
        }

        public void paint(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), Loc[0] - Rad, Loc[1] - Rad, Rad * 2, Rad * 2);
        }

        public GraviObj(int _mass, int x, int y, int dx, int dy)
        {
            Mass = _mass;
            Loc = new float[2] { x, y};
            Speed = new float[2] { dx, dy};
            deleting = false;
            Rad = (int)(Math.Sqrt(Mass)) * 3;
        }
    }

    /*class VMGraviObj : GraviObj
    {

        public VMGraviObj(int _mass, int x, int y, int dx, int dy):base(_mass,  x,  y,  dx, dy) { }
    }*/
}
