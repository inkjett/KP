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
        Int32 max_value;
        //ArrayList c, d, arr_of_one = new ArrayList();

        //Int32 Count = 0;
        public void gen_arr(Int32 a, Int32 b, ref Int32[] A) // метод заполнения массивва Нужно
        {
            Random D = new Random();
            for (Byte i = 0; i < A.Length; i++)
                A[i] = D.Next(a, b);
        }

        public void method_arr_out(Int32[] A, TextBox b) // метод вывода данных массива Нужно
        {
            b.Text = "";
            foreach (Int32 a in A)
                b.Text += String.Format("{0}", a) + " ";
        }


        public void one_in_value(ArrayList F, Int32 max_val, ref ArrayList result_arr) //Вчисление наличия еденицы в элемента массива возвращает массив
        {
            Int32 firstNumber, secondNumber, temp_value;
            firstNumber = 0;
            secondNumber = 0;
            Boolean need_to_find_number = true;
            ArrayList one_arr = new ArrayList();

            for (byte i = 0; i < F.Count; i++)
            {

                temp_value = Convert.ToInt32(F[i]);
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
                    Int32 temp_int = Convert.ToInt32(i);
                    one_arr.Add(max_val);
                    result_arr = one_arr;
                }

                one_arr.Add(F[i]);


                temp_value = 0;
                need_to_find_number = true;
                firstNumber = 0;
                secondNumber = 0;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void method_max_value(int [] arr_in, out Int32 max_val) //вычисление максимального числа Нужно
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

        public void method_del_max_values(int[] arr_in, int max_value,out int[] arr_out)
        {
            Int32 count_for_Length=0;
            for (int i = 0; i < arr_in.Length; i++)
            {
                if (max_value != arr_in[i])
                {
                    count_for_Length++;
                }
            }
            arr_out = new int [count_for_Length];
            for (int i=0; i<arr_in.Length;i++)
            {
                if (max_value!=arr_in[i])
                {
                    arr_out[i] = arr_in[i];
                }
            }
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arr_del_max_values = new Int32[arr_main.Length];
            method_max_value(arr_main, out max_value);
            method_del_max_values(arr_main, max_value, out arr_del_max_values);
            method_arr_out(arr_del_max_values,textBox5);
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
    }
}
