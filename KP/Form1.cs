﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void задане1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Zadanie1 = new Form2();
            Zadanie1.Show();
        }

        private void задание2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Zadanie2 = new Form3();
            Zadanie2.Show();
        }

        private void задание3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 Zadanie3 = new Form4();
            Zadanie3.Show();
        }

        private void задание4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 Zadanie4 = new Form5();
            Zadanie4.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 Zadanie6 = new Form6();
            Zadanie6.Show();
        }
    }
}
