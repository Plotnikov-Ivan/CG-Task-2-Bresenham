using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Task_2_Bresenham
{
    public partial class Form1 : Form
    {
        int r;
        Point p1, p2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Line(int I1, int J1, int I2, int J2, int p)
        {
            Graphics g = CreateGraphics();
            if (I1 > I2)
            {
                int i = I1; I1 = I2; I2 = i;
                int j = J1; J1 = J2; J2 = j;
            }
            int dI = I2 - I1; int dJ = J2 - J1;
            int S = 0;
            if (dJ != 0)
                S = dJ / Math.Abs(dJ);
            int d = 2 * dJ - S * dI;
            if (S * dJ <= dI)
            {			// малый наклон к оси OX
                int j = J1;

                for (int i = I1; i <= I2; i++)
                {
                    if (p == 1)
                    {
                        g.FillRectangle(Brushes.Black, i, j, 2, 2);
                    } else
                    {
                        g.FillRectangle(Brushes.White, i, j, 2, 2);
                    }
                    d += 2 * dJ;
                    if (S * d >= 0)
                    {
                        j += S;
                        d -= 2 * S * dI;
                    }

                }
            }
            else
            {			// большой наклон к оси OX
                int i = I1;
                for (int j = J1; (J2 - j) * S >= 0; j += S)
                {
                    if (p == 1)
                    {
                        g.FillRectangle(Brushes.Black, i, j, 2, 2);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, i, j, 2, 2);
                    }
                    d += 2 * S * dI;
                    if (S * d >= 0)
                    {
                        d -= 2 * dJ;
                        i++;
                    }
                }
            }
            g.Dispose();
        }
        private void Circle(int X1, int Y1, int r, int p)
        {
            Graphics g = CreateGraphics();
            int x = 0;
            int y = r;
            int delta = 2 - 2 * r;
            int error = 0;
            while (y >= 0)
            {
                // дуга 1-й четверти
                if (p == 1)
                    g.FillRectangle(Brushes.Black, X1 + x, Y1 - y, 2, 2);
                else
                    g.FillRectangle(Brushes.White, X1 + x, Y1 - y, 2, 2);


                if (delta < 0)
                {
                    error = 2 * (delta + y) - 1;
                    if (error <= 0)
                        delta += 2 * ++x + 1;   // выбираем горизонтальный пиксель
                    else
                        delta += 2 * (++x - --y + 1);   // выбираем диагональный пиксель
                }
                else
                {
                    error = 2 * (delta - x) - 1;
                    if (error > 0)
                        delta -= 2 * --y + 1;   // выбираем вертикальный пиксель
                    else
                        delta += 2 * (++x - --y + 1);   // выбираем диагональный пиксель
                }
            }
            g.Dispose();
        }

        private void Ellipse(int X1, int Y1, int rx, int ry, int p)
        {
            Graphics g = CreateGraphics();
            int x = 0;
            int y = ry;
            int rx2 = rx * rx;
            int ry2 = ry * ry;
            int delta = rx2 + ry2 - 2 * rx2 * ry;
            int error = 0;
            while (y >= 0)
            {
                // дуга 1-й четверти
                if (p == 1)
                    g.FillRectangle(Brushes.Black, X1 + x, Y1 - y, 2, 2);
                else
                    g.FillRectangle(Brushes.White, X1 + x, Y1 - y, 2, 2);
                if (delta < 0)
                {
                    error = 2 * delta + rx2 * (2 * y - 1);
                    if (error <= 0)
                        delta += ry2 * (2 * ++x + 1);   // выбираем горизонтальный пиксель
                    else
                        delta += ry2 * (2 * ++x + 1) - rx2 * (2 * --y - 1);    // выбираем диагональный пиксель
                }
                else
                {
                    error = 2 * delta - ry2 * (2 * x + 1);
                    if (error > 0)
                        delta -= rx2 * (2 * --y + 1);   // выбираем вертикальный пиксель
                    else
                        delta += ry2 * (2 * ++x + 1) - rx2 * (2 * --y - 1);   // выбираем диагональный пиксель
                }
            }
            g.Dispose();
        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.FillRectangle(new SolidBrush(SystemColors.ControlLightLight), ClientRectangle);
            g.Dispose();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton1 = (RadioButton)sender;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton2 = (RadioButton)sender;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton3 = (RadioButton)sender;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked)
            {
 
                Line(p1.X, p1.Y, p2.X, p2.Y, 0);
                if (p1.X > p2.X && Math.Abs((p1.Y - p2.Y)) < (p1.X - p2.X))
                {
                    p1.X -= 5;
                    p2.X += 5;
                    p1.Y -= 5;
                    p2.Y += 5;
                }
                 if (p1.X < p2.X && Math.Abs((p1.Y - p2.Y)) < (p2.X - p1.X))
                {
                    p1.X += 5;
                    p2.X -= 5;
                }
                if (p1.Y < p2.Y && Math.Abs((p1.X - p2.X)) < (p2.Y - p1.Y))
                {
                    p1.Y += 5;
                    p2.Y -= 5;
                }

                Line(p1.X, p1.Y, p2.X, p2.Y, 1);
            }
            if (radioButton2.Checked)
            { 
                 Circle(p1.X, p1.Y, r, 0);
                r -= 5;

                Circle(p1.X, p1.Y, r, 1); }
            if (radioButton3.Checked)
            {
                Ellipse(p1.X, p1.Y, r, r * 2, 0);
                r -= 5;

                Ellipse(p1.X, p1.Y, r, r * 2, 1);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                Line(p1.X, p1.Y, p2.X, p2.Y, 0);
                if (p1.X > p2.X && Math.Abs((p1.Y - p2.Y)) < (p1.X - p2.X))
                {
                    p1.X += 5;
                    p2.X -= 5;
                    p1.Y += 5;
                    p2.Y -= 5;
                }
                if (p1.X < p2.X && Math.Abs((p1.Y - p2.Y)) < (p2.X - p1.X))
                {
                    p1.X -= 5;
                    p2.X += 5;
                }
                if (p1.Y < p2.Y && Math.Abs((p1.X - p2.X)) < (p2.Y - p1.Y))
                {
                    p1.Y -= 5;
                    p2.Y += 5;
                }

                Line(p1.X, p1.Y, p2.X, p2.Y, 1);
            }
            if (radioButton2.Checked)
            {
                Circle(p1.X, p1.Y, r, 0);
                r += 5;

                Circle(p1.X, p1.Y, r, 1);
            }
            if (radioButton3.Checked)
            {
                Ellipse(p1.X, p1.Y, r, r * 2, 0);
                r += 5;

                Ellipse(p1.X, p1.Y, r, r * 2, 1);
            }
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad8)
            {
                if (radioButton1.Checked)
                {
                    Line(p1.X, p1.Y, p2.X, p2.Y, 0);
                    p1.Y -= 10;
                    p2.Y -= 10;
                    Line(p1.X, p1.Y, p2.X, p2.Y, 1);
                }
                else if (radioButton2.Checked)
                {
                    Circle(p1.X, p1.Y, r, 0);
                    p1.Y -= 10;
                    p2.Y -= 10;
                    Circle(p1.X, p1.Y, r, 1);
                }
                else if (radioButton3.Checked)
                {
                    Ellipse(p1.X, p1.Y, r, 2 * r, 0);
                    p1.Y -= 10;
                    p2.Y -= 10;
                    Ellipse(p1.X, p1.Y, r, 2 * r, 1);
                }
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                if (radioButton1.Checked)
                {
                    Line(p1.X, p1.Y, p2.X, p2.Y, 0);
                    p1.Y += 10;
                    p2.Y += 10;
                    Line(p1.X, p1.Y, p2.X, p2.Y, 1);
                }
                else if (radioButton2.Checked)
                {
                    Circle(p1.X, p1.Y, r, 0);
                    p1.Y += 10;
                    p2.Y += 10;
                    Circle(p1.X, p1.Y, r, 1);
                }
                else if (radioButton3.Checked)
                {
                    Ellipse(p1.X, p1.Y, r, 2 * r, 0);
                    p1.Y += 10;
                    p2.Y += 10;
                    Ellipse(p1.X, p1.Y, r, 2 * r, 1);
                }
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                if (radioButton1.Checked)
                {
                    Line(p1.X, p1.Y, p2.X, p2.Y, 0);
                    p1.X += 10;
                    p2.X += 10;
                    Line(p1.X, p1.Y, p2.X, p2.Y, 1);
                }
                else if (radioButton2.Checked)
                {
                    Circle(p1.X, p1.Y, r, 0);
                    p1.X += 10;
                    p2.X += 10;
                    Circle(p1.X, p1.Y, r, 1);
                }
                else if (radioButton3.Checked)
                {
                    Ellipse(p1.X, p1.Y, r, 2 * r, 0);
                    p1.X += 10;
                    p2.X += 10;
                    Ellipse(p1.X, p1.Y, r, 2 * r, 1);
                }
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                if (radioButton1.Checked)
                {
                    Line(p1.X, p1.Y, p2.X, p2.Y, 0);
                    p1.X -= 10;
                    p2.X -= 10;
                    Line(p1.X, p1.Y, p2.X, p2.Y, 1);
                }
                else if (radioButton2.Checked)
                {
                    Circle(p1.X, p1.Y, r, 0);
                    p1.X -= 10;
                    p2.X -= 10;
                    Circle(p1.X, p1.Y, r, 1);
                }
                else if (radioButton3.Checked)
                {
                    Ellipse(p1.X, p1.Y, r, 2 * r, 0);
                    p1.X -= 10;
                    p2.X -= 10;
                    Ellipse(p1.X, p1.Y, r, 2 * r, 1);
                }
            }
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (p1 != null)
            {
                p2 = e.Location;
                r = (int)Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));

                if (radioButton1.Checked)
                {
                    Line(p1.X, p1.Y, p2.X, p2.Y,1);
                }
                if (radioButton2.Checked)
                {
                    Circle(p1.X, p1.Y, r, 1);
                }
                if (radioButton3.Checked)
                {
                    Ellipse(p1.X, p1.Y, r, r * 2, 1);
                }

                }
        }
    }
}
