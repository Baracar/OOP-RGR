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
        }

        float G = 1000;
        private void timer1_Tick(object sender, EventArgs e)
        {
            To:
            foreach (GraviObj i in GraviSys)
            {
                if (i.Loc[0] > 10000 || i.Loc[0] < -10000 || i.Loc[1] > 10000 || i.Loc[1] < -10000 || i.Loc[2] > 10000 || i.Loc[2] < -10000)
                {
                    GraviSys.Remove(i);
                    goto To;
                }
            }
            foreach (GraviObj i in GraviSys)
            {
                int[] vec = new int[3] { 0, 0, 0 };
                foreach (GraviObj j in GraviSys)
                {
                    if (i != j)
                    {
                        /*
                        if(i.Loc[0] != j.Loc[0])
                            vec[0] += j.Mass / (i.Loc[0] - j.Loc[0]) / ((i.Loc[0] < j.Loc[0]) ? (i.Loc[0] - j.Loc[0]) : (-i.Loc[0] + j.Loc[0]));
                        if (i.Loc[1] != j.Loc[1])
                            vec[1] += j.Mass / (i.Loc[1] - j.Loc[1]) / ((i.Loc[1] < j.Loc[1]) ? (i.Loc[1] - j.Loc[1]) : (-i.Loc[1] + j.Loc[1]));
                        if (i.Loc[2] != j.Loc[2])
                            vec[2] += j.Mass / (i.Loc[2] - j.Loc[2]) / ((i.Loc[2] < j.Loc[2]) ? (i.Loc[2] - j.Loc[2]) : (-i.Loc[2] + j.Loc[2]));
                    */
                        float r = (i.Loc[2] - j.Loc[2]) * (i.Loc[2] - j.Loc[2]) + (i.Loc[1] - j.Loc[1]) * (i.Loc[1] - j.Loc[1]) + (i.Loc[0] - j.Loc[0]) * (i.Loc[0] - j.Loc[0]);
                        float a = j.Mass / r;
                        label1.Text = a.ToString();
                        label2.Text = (i.Loc[0] - j.Loc[0]).ToString();
                        label3.Text = Math.Sqrt(r).ToString();
                        vec[0] = (int)(G * a * (j.Loc[0] - i.Loc[0]) / Math.Sqrt(r));
                        vec[1] = (int)(G * a * (j.Loc[1] - i.Loc[1]) / Math.Sqrt(r));
                        vec[2] = (int)(G * a * (j.Loc[2] - i.Loc[2]) / Math.Sqrt(r));
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

                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), i.Loc[0] - i.Mass / 2, i.Loc[1] - i.Mass / 2, i.Mass, i.Mass);
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
            GraviSys.Add(new GraviObj(10 * (int)massCounter.Value, e.X, e.Y, 0, (e.X - x0) / 10, (e.Y - y0) / 10, 0));
        }
    }
}
