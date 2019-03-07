using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_of_method
{
    public class MethodDll
    {

        public Int32 [] gen_arr(Int32 a, Int32 b, Int32[] A) // метод заполнения массивва 
        {
            Random D = new Random();
            for (Byte i = 0; i < A.Length; i++)
            { A[i] = D.Next(a, b); }
            return A;
        }

        public string method_arr_out(Int32[] A) // метод вывода данных массива в строку
        {
            string str_out;
            str_out = "";
            foreach (Int32 a in A)
                str_out += String.Format("{0}", a) + " ";
            return str_out;
        }

        public void method_max_value(int[] arr_in, out Int32 max_val) //вычисление максимального числа 
        {
            Int32 i = 0;
            max_val = 0;
            while (i < arr_in.Length)
            {
                Int32 temp = Convert.ToInt32(arr_in[i]);
                if (max_val < Convert.ToInt32(arr_in[i]))
                {
                    max_val = Convert.ToInt32(arr_in[i]);
                }
                i++;
            }
        }

        public void method_del_max_values(int[] arr_in, int max_value, out int[] arr_out) // метод удаления максимального числа из массива
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
            arr_out = new int[count_for_Length];
            Int32 temp_for_minus = 0;// счетчик если был максимально число равно.
            for (int i = 0; i < arr_in.Length; i++)
            {
                if (max_value != arr_in[i])
                {
                    arr_out[i - temp_for_minus] = arr_in[i];
                }
                else
                {
                    temp_for_minus++;
                }
            }
        }

        public void method_incsert_one(int[] arr_in, int max_value, out int[] arr_out)//Добавление максимального числа перед всеми числами в которых есть 1
        {
            Int32 count_for_Length = 0;
            Int32 firstNumber = 0, secondNumber = 0, temp_count = 0, temp_value;
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

    }



}
