using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_RGR
{
    public partial class Form1 : Form
    {
        List<GraviObj> GraviSys;
        
        public Form1()
        {
            InitializeComponent();
            GraviSys = new List<GraviObj>();
            massCounter.Value = 10;
        }

        float G = 1000;
        private void timer1_Tick(object sender, EventArgs e)
        {
        //To:
            foreach (GraviObj i in GraviSys)
            {
                if (i.Loc[0] > 10000 || i.Loc[0] < -10000 || i.Loc[1] > 10000 || i.Loc[1] < -10000)
                {
                    i.deleting = true;
                    //GraviSys.Remove(i);
                    //goto To;
                }
            }
            GraviSys.RemoveAll(j => j.deleting);
            foreach (GraviObj i in GraviSys)
            {
                if (!i.deleting)
                    foreach (GraviObj j in GraviSys)
                    {
                        if (i == j)
                            continue;
                        float r = (i.Loc[1] - j.Loc[1]) * (i.Loc[1] - j.Loc[1]) + (i.Loc[0] - j.Loc[0]) * (i.Loc[0] - j.Loc[0]);
                        if(r < (i.Rad + j.Rad)* (i.Rad + j.Rad))
                        {
                            j.deleting = true;
                            float[] vec = new float[2] { 0, 0 };
                            vec[0] = (i.Mass * i.Speed[0] + j.Mass * j.Speed[0]) / (i.Mass + j.Mass);
                            vec[1] = (i.Mass * i.Speed[1] + j.Mass * j.Speed[1]) / (i.Mass + j.Mass);
                            i.changeSpeed(vec);
                            vec[0] = Math.Abs(i.Loc[0] - j.Loc[0]) * j.Mass / (i.Mass + j.Mass);
                            vec[1] = Math.Abs(i.Loc[1] - j.Loc[1]) * j.Mass / (i.Mass + j.Mass);
                            i.changeLoc(vec);
                            i.changeMass(j.Mass);
                        }
                    }
            }
            GraviSys.RemoveAll(j => j.deleting);
            foreach (GraviObj i in GraviSys)
            {
                float[] vec = new float[2] { 0, 0};
                foreach (GraviObj j in GraviSys)
                {
                    if (i != j)
                    {
                        double r = (i.Loc[1] - j.Loc[1]) * (i.Loc[1] - j.Loc[1]) + (i.Loc[0] - j.Loc[0]) * (i.Loc[0] - j.Loc[0]);
                        double a = j.Mass / r;
                        label1.Text = a.ToString();
                        label2.Text = (i.Loc[0] - j.Loc[0]).ToString();
                        label3.Text = Math.Sqrt(r).ToString();
                        vec[0] = (int)(G * a * (j.Loc[0] - i.Loc[0]) / Math.Sqrt(r));
                        vec[1] = (int)(G * a * (j.Loc[1] - i.Loc[1]) / Math.Sqrt(r));
                    }

                }
                i.changeAll(vec);
            }
            Refresh();
        }

        //f = G*m*M/r^2
        //f = ma

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //if (GraviSys.Count != 0)
            foreach (GraviObj i in GraviSys)
            {
                i.paint(e.Graphics);
            }
        }

        int x0 = 0, y0 = 0;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            GraviSys.Add(new GraviObj(10 * (int)massCounter.Value, x0, y0, (e.X - x0) / 10, (e.Y - y0) / 10));
        }
    }
}
