using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_of_method;

namespace KP
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        Int32[] arr_main;
        Int32[] arr_del_max_values;
        Int32[] arr_insert_one;
        string arr_str;
        Int32 max_value;
        
        MethodDll meth = new MethodDll();
        private void button1_Click(object sender, EventArgs e)
        {
            
            Int32 c = Int32.Parse(textBox2.Text); //диапазон значений начало
            Int32 d = Int32.Parse(textBox3.Text); // диапазон значений конец
            Byte n = Byte.Parse(textBox1.Text); // количество чисел в массиве
            
            arr_main = new Int32[n]; // инициализация массива, заполнен 0
            meth.gen_arr(c, d, arr_main);
            arr_str = meth.method_arr_out(arr_main);
            textBox4.Text = arr_str;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                arr_del_max_values = new Int32[arr_main.Length];
                meth.method_max_value(arr_main, out max_value);
                meth.method_del_max_values(arr_main, max_value, out arr_del_max_values);
                string no_max_arr_str = meth.method_arr_out(arr_del_max_values);
                textBox5.Text = no_max_arr_str;
            }
            catch
            {
                MessageBox.Show("Сгенерируйте маcсив", "Сообщение", MessageBoxButtons.OK);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                meth.method_max_value(arr_main, out max_value);
                meth.method_incsert_one(arr_main, max_value, out arr_insert_one);
                string insert_one_arr_str =  meth.method_arr_out(arr_insert_one);
                textBox6.Text = insert_one_arr_str;
            }
            catch
            {
                MessageBox.Show("Сгенерируйте маcсив", "Сообщение", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
