using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KP
{
    public partial class Form5 : Form
    {
        string text_from_file = "";
        Int32 count_of_word;
        public Form5()
        {
            InitializeComponent();
        }

        public void method_read_from_file(ref string text_out) // метод считывания текста из файла и запись в текст
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Name_file_to_read = openFileDialog1.FileName;
                using (var R = new StreamReader(Name_file_to_read, Encoding.GetEncoding(1251)))
                {
                    text_out = R.ReadLine();
                }
            }
        }

        public void method_save_to_file(string text_in)// запись текста в файл
        {

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Name_file_to_write = saveFileDialog1.FileName;
                using (StreamWriter W = new StreamWriter(Name_file_to_write, true, Encoding.GetEncoding(1251)))
                {
                    W.WriteLine(text_in);
                }
            }
        }

        public void method_count_of_words(string text_in, string word_to_find, ref Int32 count)// подсчет слов в тексте
        {
            count = 0;
            text_in.Trim();
            Int32 lengh_word = word_to_find.Length;
            for (int i = 0; i <= text_in.Length - lengh_word; i++)
            {
                string temp_string = text_in.Substring(i, lengh_word);
                if (temp_string == word_to_find)
                {
                    count++;
                }
                temp_string = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            method_read_from_file(ref text_from_file);
            textBox1.Text = text_from_file;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            method_count_of_words(text_from_file, textBox2.Text, ref count_of_word);
            label4.Text = Convert.ToString(count_of_word);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            method_save_to_file(label4.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
