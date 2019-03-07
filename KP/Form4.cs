using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace KP
{
    public partial class Form4 : Form
    {
        //описание переменных
        Int32[] arr_main;
        Int32[] arr_del_max_values;
        Int32[] arr_insert_one;
        Int32 max_value;

        public void gen_arr(Int32 a, Int32 b, ref Int32[] A) // метод заполнения массивва 
        {
            Random D = new Random();
            for (Byte i = 0; i < A.Length; i++)
                A[i] = D.Next(a, b);
        }

        public void method_arr_out(Int32[] A, TextBox b) // метод вывода данных массива 
        {
            b.Text = "";
            foreach (Int32 a in A)
                b.Text += String.Format("{0}", a) + " ";
        }


         private void button3_Click(object sender, EventArgs e)
        {

        }

        public void method_max_value(int [] arr_in, out Int32 max_val) //вычисление максимального числа 
        {
            Int32 i = 0;
            max_val = 0;
            while ( i< arr_in.Length)
            {
                Int32 temp = Convert.ToInt32(arr_in[i]);
                if (max_val < Convert.ToInt32(arr_in[i]))
                {
                    max_val = Convert.ToInt32(arr_in[i]);
                }
                i++;
            }

        }

        public void method_del_max_values(int[] arr_in, int max_value,out int[] arr_out) // метод удаления максимального числа из массива
        {
            Int32 count_for_Length = 0;
            Int32 count_for_arr = 0;
            for (int i = 0; i < arr_in.Length; i++)
            {
                if (max_value != arr_in[i])
                {
                    count_for_Length++;//переменная для длинны массива
                }
                else
                {
                    count_for_arr++;
                }
            }
            arr_out = new int [count_for_Length];
            Int32 temp_for_minus = 0;// счетчик если был максимально число равно.
            for (int i=0; i<arr_in.Length;i++)
            {
                if (max_value != arr_in[i])
                {
                    arr_out[i- temp_for_minus] = arr_in[i];
                }
                else
                {
                    temp_for_minus++;
                }
            }
        }

        public void method_incsert_one(int [] arr_in, int max_value, out int[] arr_out)//Добавление максимального числа перед всеми числами в которых есть 1
        {
            Int32 count_for_Length = 0;
            Int32 firstNumber=0, secondNumber=0, temp_count=0,temp_value;
            Boolean need_to_find_number;

            for (int i = 0; i < arr_in.Length; i++) // определение длины нового массива
            {
                temp_value = Convert.ToInt32(arr_in[i]);
                need_to_find_number = true;
                while ((temp_value != 0) && (need_to_find_number == true))
                {
                    secondNumber = temp_value % 10;
                    firstNumber = temp_value / 10;
                    temp_value = firstNumber;
                    if ((firstNumber == 1) || (secondNumber == 1))
                    { need_to_find_number = false; }

                }
                if ((firstNumber == 1) || (secondNumber == 1))
                {
                    count_for_Length++;
                }
            }
            arr_out = new int[arr_in.Length + count_for_Length];// создание нового массива нобходимого размера
            for (int i = 0; i < arr_in.Length; i++) // заполнение нового массива
            {                
                temp_value = Convert.ToInt32(arr_in[i]);
                need_to_find_number = true;
                while ((temp_value != 0) && (need_to_find_number == true))
                {
                    secondNumber = temp_value % 10;
                    firstNumber = temp_value / 10;
                    temp_value = firstNumber;
                    if ((firstNumber == 1) || (secondNumber == 1))
                    { need_to_find_number = false; }

                }
                if ((firstNumber == 1) || (secondNumber == 1))
                {
                    arr_out[i + temp_count] = max_value;
                    arr_out[i + 1 + temp_count] = arr_in[i];
                    temp_count++;
                }
                else
                {
                    arr_out[i + temp_count] = arr_in[i];
                }
            }
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                arr_del_max_values = new Int32[arr_main.Length];
                method_max_value(arr_main, out max_value);
                method_del_max_values(arr_main, max_value, out arr_del_max_values);
                method_arr_out(arr_del_max_values, textBox5);
            }
            catch
            {
                MessageBox.Show("Сгенерируйте маcсив", "Сообщение", MessageBoxButtons.OK);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 c = Int32.Parse(textBox2.Text); //диапазон значений начало
            Int32 d = Int32.Parse(textBox3.Text); // диапазон значений конец
            Byte n = Byte.Parse(textBox1.Text); // количество чисел в массиве
            arr_main = new Int32[n]; // инициализация массива, заполнен 0
            gen_arr(c, d, ref arr_main); // передача в метод данных о массиве
            method_arr_out(arr_main, textBox4); // вывод данных из масиива в текст
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                method_max_value(arr_main, out max_value);
                method_incsert_one(arr_main, max_value, out arr_insert_one);
                method_arr_out(arr_insert_one, textBox6);
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
