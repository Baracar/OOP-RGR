using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OOP_RGR
{
    class GraviObj
    {
        public int Mass { get; private set; }
        public double[] Loc { get; private set; }
        public double[] Speed { get; private set; }
        public bool deleting;
        public int Rad { get; private set; }
        public bool Star;


        public void changeAll(double[] d)
        {
            Speed[0] += d[0];
            Speed[1] += d[1];
            Loc[0] += Speed[0];
            Loc[1] += Speed[1];
        }

        public void changeAll(double dx, double dy)
        {
            Speed[0] += dx;
            Speed[1] += dy;
            Loc[0] += Speed[0];
            Loc[1] += Speed[1];
        }
        public void changeSpeed(double[] d)
        {
            Speed[0] += d[0];
            Speed[1] += d[1];
        }
        public void changeAbsSpeed(double[] d)
        {
            Speed[0] = d[0];
            Speed[1] = d[1];
        }
        public void changeLoc(double[] d)
        {
            Loc[0] += d[0];
            Loc[1] += d[1];
        }

        public void move()
        {
            Loc[0] += Speed[0];
            Loc[1] += Speed[1];
        }

        public void changeMass(int _mass)
        {
            Mass += _mass;
            if (Star)
                Rad = (int)(Math.Sqrt(Mass / 100)) * 3;
            else
                Rad = (int)(Math.Sqrt(Mass)) * 3;
        }

        public void paint(Graphics g, double camShiftX = 0, double camShiftY = 0, double camSkale = 0)
        {
            Color c;
            if (Star)
                c = Color.Yellow;
            else
                c = Color.Brown;
            float x = (float)((Loc[0] + camShiftX - Rad) * camSkale);
            float y = (float)((Loc[1] + camShiftY - Rad) * camSkale);
            float r = (float)(Rad * 2 * camSkale);
            g.FillEllipse(new SolidBrush(c), x, y, r, r);
        }

        public GraviObj(int _mass, double x, double y, double dx, double dy, bool _star)
        {
            Mass = _mass;
            Loc = new double[2] { x, y};
            Speed = new double[2] { dx, dy};
            deleting = false;
            Rad = (int)(Math.Sqrt(Mass)) * 3;
            Star = _star;
            if(Star)
                Mass *= 100;
        }
    }

    /*class VMGraviObj : GraviObj
    {

        public VMGraviObj(int _mass, int x, int y, int dx, int dy):base(_mass,  x,  y,  dx, dy) { }
    }*/
}
