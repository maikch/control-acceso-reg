using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 aform = new Form2();
            aform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 aform = new Form3();
            aform.ShowDialog();
        }
    }
}
