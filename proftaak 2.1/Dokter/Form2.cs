using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dokter
{
    public partial class Form2 : Form
    {
        string username;
        string password;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            if (username == "doctor" && password == "password")
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Close();
                }
                else
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Close();
                }
            } else
            {
                MessageBox.Show("verkeerde username of wachtwoord ingevoerd");
            }
        }
    }
}
