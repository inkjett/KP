using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP
{
    public partial class Form2 : Form
    {

        // описание переменных
        Double Start, End, Step,a,x,Rezult=0;



        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Form2()
        {
            InitializeComponent();
        }

        Double xmin = -1, xmax = 2, ymin = -1, ymax = 1, hx, hy, mx, my;
        int ax1 = 50, ax2 = 50, ay1 = 0, ay2 = 0, d, c, sx = 3, sy = 3;
        Pen pn = new Pen(Color.Red, 3); // перо для графика
        Pen pn1 = new Pen(Color.Green, 3); // перо для сетки
        Pen pn2 = new Pen(Color.Black, 3); // перо для осей
        Font fn = new Font("Arial", 10);// шрифт для осей
        Font fn1 = new Font("Arial", 10);// шфрифт для засечек 


        private void Extrem() // расчет масштаба и смещения
        {
            mx = (d - ax1) / (ymax - xmin);//Масштаб по оси X
            my = (c - ay1) / (ymin - ymax);//Масштаю по оси Y
            sx = ax1 - Convert.ToInt32(mx * xmin);
            sy = ay1 - Convert.ToInt32(my * ymax);
        }



        private void grid_x(Graphics F)
        {
            double x;
            int i, n;
            x = xmin;
            n = Convert.ToInt32((xmax - xmin) / hx) + 1;
            for (i = 0; i <= n; i++)
            {
                F.DrawLine(pn2, Convert.ToInt32(x * mx) + sx,
                Convert.ToInt32(ymin * my) + sy,
                Convert.ToInt32(x * mx) + sx,
                Convert.ToInt32(ymax * my) + sy);
                x += hx;
            }
        }

        private void grid_y(Graphics F)
        {
            double y;
            int i, n;
            y = ymin;
            n = Convert.ToInt32((ymax - ymin) / hy) + 1;
            for (i = 1; i <= n; i++)
            {
                F.DrawLine(pn1, Convert.ToInt32(xmin * mx) + sx,
                Convert.ToInt32(y * my) + sy,
                Convert.ToInt32(xmax * mx) + sx,
                Convert.ToInt32(y * my) + sy);
                y += hy;
            }
        }

        private void axis_x(Graphics Graph)
        {
            Graph.DrawLine(pn2, Convert.ToInt32(xmin * mx) + sx, sy,
            Convert.ToInt32(xmax * mx) + sx, sy);
            Graph.DrawString("", fn, Brushes.Black,
            Convert.ToInt32(xmax * mx) + sx + 20, sy);
        }

        private void axis_y(Graphics Graph)
        {
            Graph.DrawLine(pn2, sx, Convert.ToInt32(ymin * my) + sy,
            sx, Convert.ToInt32(ymax * my) + sy);
            Graph.DrawString("Y", fn, Brushes.Black, sx - 20,
            Convert.ToInt32(ymax * my) + sy);
        }


        private void z_x(Graphics F)
        {
            for (double i = xmin; i <= xmax; i += hx)
            {
                F.DrawLine(pn2, Convert.ToInt32(i * mx) + sx,
                sy, Convert.ToInt32(i * mx) + sx, 5 + sy);
                F.DrawString(Convert.ToString(i), fn1,
                Brushes.Black, Convert.ToInt32(i * mx) + sx - 60, 2 + sy);
            }
        }

        private void z_y(Graphics F)
        {
            for (double i = ymin; i <= ymax; i += hy)
            {
                F.DrawLine(pn2, sx,
                Convert.ToInt32(i * my) + sy, 5 + sx,
                Convert.ToInt32(i * my) + sy);
                if (i != 0) F.DrawString(Convert.ToString(i),
                fn1, Brushes.Black, 3 + sx,
                Convert.ToInt32(i * my) + sy);
            }
        }
               


        private void Form2_Load(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Start = Double.Parse(textBox3.Text);
                End = Double.Parse(textBox4.Text);
                Step = Double.Parse(textBox5.Text);
                a = Double.Parse(textBox1.Text);
                textBox6.Text = "";
                for (x = Start; x <= End; x += Step)
                {
                    Rezult = 0;
                    if (x <= 1)
                    {
                        Rezult = 2 * a * Math.Cos(x) + 3 * x * x; ;
                    }
                    if ((1 < x) && (x <= 2))
                    {
                        Rezult = a * Math.Sin(x) + 3 * x * x; ;
                    }
                    if (x > 2)
                    {
                        Rezult = a * Math.Log(x) + Math.Pow(Math.Abs(x), 1 / 3);
                    }
                    textBox6.Text += String.Format("{0,10:F4}\r\n", Rezult);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте введенные данные","Сообщение",MessageBoxButtons.OK);                    
            }
        }


        public void method_tab_func(Double Start, Double End, Double Step, Double a, out Int32 x_out, out Int32 Rezult2)
        {
            x_out = 0;
            Rezult2 = 0;
            for (x = Start; x <= End; x += Step)
            {
                Rezult = 0;
                if (x <= 1)
                {
                    Rezult = 2 * a * Math.Cos(x) + 3 * x * x;
                    Rezult2 = Convert.ToInt32(Rezult);
                }
                if ((1 < x) && (x <= 2))
                {
                    Rezult = a * Math.Sin(x) + 3 * x * x;
                    Rezult2 = Convert.ToInt32(Rezult);
                }
                if (x > 2)
                {
                    Rezult = a * Math.Log(x) + Math.Pow(Math.Abs(x), 1 / 3);
                    Rezult2 = Convert.ToInt32(Rezult);
                }      
                x_out= Rezult2 = Convert.ToInt32(Start);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics F = pictureBox2.CreateGraphics();
            F.Clear(Color.White);
            double h;
            pictureBox1.Refresh();
            ax1 = 0; ay1 = 0; ax2 = 0; ay2 = 0;
            c = pictureBox1.Size.Height - ay1 - ay2;
            d = pictureBox1.Size.Width - ax1 - ax2;
            xmin = Convert.ToDouble(textBox11.Text);
            xmax = Convert.ToDouble(textBox10.Text);
            ymin = Convert.ToDouble(textBox9.Text);
            ymax = Convert.ToDouble(textBox8.Text);
            hx = Convert.ToDouble(textBox7.Text);
            hy = Convert.ToDouble(textBox2.Text);
            Extrem();
            grid_x(F);
            grid_y(F);
            axis_x(F);
            axis_y(F);
            z_x(F); z_y(F);
            h = 0.1;
            Start = Double.Parse(textBox3.Text);
            End = Double.Parse(textBox4.Text);
            Step = Double.Parse(textBox5.Text);
            a = Double.Parse(textBox1.Text);
            bool Graph_start = true;
            for (x = Start; x <= End; x += Step)
            {
                PointF Point_1;
                PointF Point_2;
                Point_1 = new PointF(0, 0);
                Point_2 = new PointF(0, 0);
                Rezult = 0;
                if (x <= 1)
                {
                    Rezult = 2 * a * Math.Cos(x) + 3 * x * x;
                    Point_1 = new PointF(Convert.ToInt32(x), Convert.ToInt32(Rezult));
                                   }
                if ((1 > x) && (x <= 2))
                {
                    Rezult = a * Math.Sin(x) + 3 * x * x;
                    Point_1 = new PointF(Convert.ToInt32(x), Convert.ToInt32(Rezult));
                }
                if (x > 2)
                {
                    Rezult = a * Math.Log10(x) + Math.Pow(Math.Abs(x), 1.0 / 3.0);
                    Point_1 = new PointF(Convert.ToInt32(x), Convert.ToInt32(Rezult));
                }
                if (Graph_start)
                {
                    Point_2 = Point_1;
                    Graph_start = false;
                }
                F.DrawLine(pn, Point_1, Point_2);
                Point_2 = Point_1;
            }

        }
    }
}
