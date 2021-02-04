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
            massCounter2.Value = 10;
        }

        float G = 20;
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (GraviObj i in GraviSys)
            {
                if (i.Loc[0] > 1000000 || i.Loc[0] < -1000000 || i.Loc[1] > 1000000 || i.Loc[1] < -1000000)
                {
                    i.deleting = true;
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
                        double r = (i.Loc[1] - j.Loc[1]) * (i.Loc[1] - j.Loc[1]) + (i.Loc[0] - j.Loc[0]) * (i.Loc[0] - j.Loc[0]);
                        if (r < (i.Rad + j.Rad) * (i.Rad + j.Rad))
                        {
                            j.deleting = true;
                            if (j.Star)
                                i.Star = true;
                            double[] vec = new double[2] { 0, 0 };
                            vec[0] = (i.Mass * i.Speed[0] + j.Mass * j.Speed[0]) / (i.Mass + j.Mass);
                            vec[1] = (i.Mass * i.Speed[1] + j.Mass * j.Speed[1]) / (i.Mass + j.Mass);
                            i.changeAbsSpeed(vec);
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
                double[] vec = new double[2] { 0, 0 };
                foreach (GraviObj j in GraviSys)
                {
                    if (i != j)
                    {
                        double r = (i.Loc[1] - j.Loc[1]) * (i.Loc[1] - j.Loc[1]) + (i.Loc[0] - j.Loc[0]) * (i.Loc[0] - j.Loc[0]);
                        double a = j.Mass / r;
                        vec[0] += (float)(G * a * (j.Loc[0] - i.Loc[0]) / Math.Sqrt(r));
                        vec[1] += (float)(G * a * (j.Loc[1] - i.Loc[1]) / Math.Sqrt(r));
                    }

                }
                i.changeSpeed(vec);
            }
            foreach (GraviObj i in GraviSys)
            {
                i.move();
            }
            Refresh();
        }

        //f = G*m*M/r^2
        //f = ma

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), this.Width / 2, 0, this.Width / 2, this.Height);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 0, this.Height / 2, this.Width, this.Height / 2);
            foreach (GraviObj i in GraviSys)
            {
                i.paint(e.Graphics, camShiftX, camShiftY, camSkale);
            }
        }

        double x0 = 0, y0 = 0;
        bool camShifting;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;
            if (e.Button == MouseButtons.Right)
                camShifting = true;
        }

        double camShiftX = 0, camShiftY = 0, camSkale = 1;

        private void doubleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            massCounter2.Visible = !massCounter2.Visible;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (camShifting)
            {
                camShiftX -= (x0 - e.X) / camSkale;
                camShiftY -= (y0 - e.Y) / camSkale;
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 0)
            {
                camShiftX -= this.Width / 2 / 11 / camSkale;
                camShiftY -= this.Height / 2 / 11 / camSkale;
                camSkale *= 1.1;
            }
            else
            {
                camShiftX += this.Width / 2 / 10 / camSkale;
                camShiftY += this.Height / 2 / 10 / camSkale;
                camSkale /= 1.1;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (orbitCheckBox.Checked)
                {
                    if (doubleCheckBox.Checked)
                    {
                        double x, y;
                        GraviObj first = new GraviObj(10 * (int)massCounter.Value, 0, 0, 0, 0, starCheckBox.Checked);
                        GraviObj second = new GraviObj(10 * (int)massCounter2.Value, 0, 0, 0, 0, starCheckBox.Checked);
                        x = x0 / camSkale - camShiftX;
                        y = y0 / camSkale - camShiftY;
                        double r;
                        if (starCheckBox.Checked)
                        {
                            r = 8 * (first.Rad + second.Rad);
                        }
                        else
                        {
                            r = 2 * (first.Rad + second.Rad);
                        }
                        double r1 = r * second.Mass / (first.Mass + second.Mass);
                        double r2 = r * first.Mass / (first.Mass + second.Mass);
                        first.changeLoc(new double[2] { x - r1, y });
                        second.changeLoc(new double[2] { x + r2, y });
                        double V1 = G * second.Mass / r1 / ((r / r1) * (r / r1));
                        double V2 = G * first.Mass / r2 / ((r / r2) * (r / r2));

                        y = Math.Sqrt(V1);
                        first.changeAbsSpeed(new double[2] { 0, y });

                        y = -Math.Sqrt(V2);
                        second.changeAbsSpeed(new double[2] { 0, y });

                        double vx = 0, vy = 0;
                        foreach (GraviObj i in GraviSys)
                        {
                            x = e.X / camSkale - camShiftX - i.Loc[0];
                            y = e.Y / camSkale - camShiftY - i.Loc[1];
                            double V = G * i.Mass / Math.Sqrt(x * x + y * y);

                            double t = x; x = -y; y = t;

                            t = Math.Sqrt(V / (x * x + y * y));
                            x *= t;
                            y *= t;
                            vx += x;
                            vy += y;
                        }
                        first.changeSpeed(new double[2] { vx, vy });
                        second.changeSpeed(new double[2] { vx, vy });

                        GraviSys.Add(first);
                        GraviSys.Add(second);
                    }
                    else
                    {
                        if (GraviSys.Count == 0)
                        {
                            double x = x0 / camSkale - camShiftX;
                            double y = y0 / camSkale - camShiftY;
                            GraviSys.Add(new GraviObj(10 * (int)massCounter.Value, x, y, (e.X - x0) / 10, (e.Y - y0) / 10, starCheckBox.Checked));
                            return;
                        }
                        double vx = 0, vy = 0;
                        foreach (GraviObj i in GraviSys)
                        {
                            double x, y;
                            x = e.X / camSkale - camShiftX - i.Loc[0];
                            y = e.Y / camSkale - camShiftY - i.Loc[1];
                            double V = G * i.Mass / Math.Sqrt(x * x + y * y);

                            double t = x; x = -y; y = t;

                            t = V / (x * x + y * y);

                            if (x >= 0)
                                x *= x * t;
                            else
                                x *= -x * t;
                            if (y >= 0)
                                y *= y * t;
                            else
                                y *= -y * t;
                            vx += x;
                            vy += y;
                        }
                        if (vx >= 0)
                            vx = Math.Sqrt(vx);
                        else
                            vx = -Math.Sqrt(-vx);
                        if (vy >= 0)
                            vy = Math.Sqrt(vy);
                        else
                            vy = -Math.Sqrt(-vy);
                        GraviSys.Add(new GraviObj(10 * (int)massCounter.Value, e.X / camSkale - camShiftX, e.Y / camSkale - camShiftY, vx, vy, starCheckBox.Checked));
                    }
                }
                else
                {
                    if (doubleCheckBox.Checked)
                    {
                        double x, y;
                        GraviObj first = new GraviObj(10 * (int)massCounter.Value, 0, 0, 0, 0, starCheckBox.Checked);
                        GraviObj second = new GraviObj(10 * (int)massCounter2.Value, 0, 0, 0, 0, starCheckBox.Checked);
                        x = x0 / camSkale - camShiftX;
                        y = y0 / camSkale - camShiftY;
                        double r;
                        if (starCheckBox.Checked)
                        {
                            r = 8 * (first.Rad + second.Rad);
                        }
                        else
                        {
                            r = 2 * (first.Rad + second.Rad);
                        }
                        double r1 = r * second.Mass / (first.Mass + second.Mass);
                        double r2 = r * first.Mass / (first.Mass + second.Mass);
                        first.changeLoc(new double[2] { x - r1, y });
                        second.changeLoc(new double[2] { x + r2, y });
                        double V1 = G * second.Mass / r1 / ((r / r1) * (r / r1));
                        double V2 = G * first.Mass / r2 / ((r / r2) * (r / r2));

                        y = Math.Sqrt(V1);
                        first.changeAbsSpeed(new double[2] { 0, y });

                        y = -Math.Sqrt(V2);
                        second.changeAbsSpeed(new double[2] { 0, y });

                        first.changeSpeed(new double[2] { (e.X - x0) / 10, (e.Y - y0) / 10 });
                        second.changeSpeed(new double[2] { (e.X - x0) / 10, (e.Y - y0) / 10 });

                        GraviSys.Add(first);
                        GraviSys.Add(second);
                        return;
                    }
                    else
                    {
                        double x = x0 / camSkale - camShiftX;
                        double y = y0 / camSkale - camShiftY;
                        GraviSys.Add(new GraviObj(10 * (int)massCounter.Value, x, y, (e.X - x0) / 10, (e.Y - y0) / 10, starCheckBox.Checked));
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                camShifting = false;
            }
        }
    }
}
