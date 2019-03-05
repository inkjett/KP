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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
    }
}
