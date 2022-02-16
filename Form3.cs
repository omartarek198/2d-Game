using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp11
{
    public partial class Form3 : Form
    {
        int flag = -1;
        List<Keys> L = new List<Keys>();
        public Form3()
        {
            this.Focus();
            for (int i=0;i<8;i++)
            {
                Keys pnn = new Keys();
                L.Add(pnn);
            }
            L[0] = Keys.W;
            L[1] = Keys.A;
            L[2] = Keys.D;
            L[3] = Keys.S;
            L[4] = Keys.Space;
            L[5] = Keys.ControlKey;
            L[6] = Keys.G;
            L[7] = Keys.Z;

            this.KeyDown += Form3_KeyDown;
            InitializeComponent();
        }

        public void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("pressed");
            bool Repeated = false;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i] == e.KeyCode)
                {
                    MessageBox.Show("Key Already in use");
                    Repeated = true;
                    break;
                }

            }
            if (!Repeated)
            {
                flag--;
                L[flag] = e.KeyCode;
                SetLabels();
            }

          
        }

        public List<Keys> GetKeys()
        {
            return L;
        }
     
        void SetLabels()
        {
            char a;
            string b;


            b = L[0].ToString();
            label9.Text = b;

            b = L[1].ToString();
            label10.Text = b;

            b = L[2].ToString();
            label11.Text = b;

            b = L[3].ToString();
            label12.Text = b;

            b = L[4].ToString();
            label13.Text = b;

            b = L[5].ToString();
            label14.Text = b;
            
            b = L[6].ToString();
            label15.Text = b;
          
            b = L[7].ToString();
            label16.Text = b;
        }
        private void Form3_Load(object sender, EventArgs e)
        {

            SetLabels();

        }
        private void label8_Click(object sender, EventArgs e)
        {
            SetLabels();
            label16.Text = " ";
            flag = 8;
        }
        private void label7_Click(object sender, EventArgs e)
        {
            SetLabels();
            label15.Text = " ";
            flag = 7;
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SetLabels();
            label14.Text = " ";
            flag = 6;
        
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SetLabels();
            label13.Text = " ";
            flag = 5;
       
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SetLabels();
            label12.Text = " ";
            flag = 4;
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SetLabels();
            label11.Text = " ";
            flag = 3;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SetLabels();
            label10.Text = " ";
            flag = 2;
         
        }

    

        private void label1_Click(object sender, EventArgs e)
        {
            SetLabels();
            label9.Text = " ";
            flag = 1;
           
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //}
    }
}
