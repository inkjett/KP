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
            Form2 Zadanie2 = new Form2();
            Zadanie2.Show();
        }
    }
}
