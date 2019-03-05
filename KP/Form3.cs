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
    public partial class Form3 : Form
    {
        Double c, k, a, p, sum, eps, f=0;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((radioButton1.Checked == true))
                {
                    if (double.TryParse(textBox1.Text, out f))
                    {
                        a = Double.Parse(textBox1.Text);
                        p = 0.5;
                        k = 0;
                        sum = p;
                        do
                        {
                            sum = sum + p;
                            c = (1 + k + Math.Pow(2, k + 2)) / ((k + Math.Pow(2, k + 1)) * ((2 * k + 2) * (2 * k + 3)));
                            p = p * c;
                            k++;
                        }
                        while (k < a);
                        textBox6.Text = "Сумма=" + sum.ToString() + Environment.NewLine + "Количество элементов=" + (k - 1);
                    }
                }
                if (radioButton2.Checked == true)
                {
                    if (double.TryParse(textBox2.Text, out f))
                    {
                        eps = Double.Parse(textBox2.Text);
                        p = 0.5;
                        k = 0;
                        sum = p;
                        do
                        {
                            sum = sum + p;
                            c = (1 + k + Math.Pow(2, k + 2)) / ((k + Math.Pow(2, k + 1)) * ((2 * k + 2) * (2 * k + 3)));
                            p = p * c;
                            k++;
                        }
                        while (Math.Abs(p) > eps);
                        textBox6.Text = "Сумма=" + sum.ToString() + Environment.NewLine + "Количество элементов=" + (k - 1);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Проверьте переменные","Сообщение",MessageBoxButtons.OK);
            }
        }
    }
}
