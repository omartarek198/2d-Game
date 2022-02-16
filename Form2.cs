using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp11
{
    public partial class Form2 : Form
    {
        Form3 obj3 = new Form3();
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            obj3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            obj1.SetControls(obj3.GetKeys());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you really need instructions?");
        }
    }
}
