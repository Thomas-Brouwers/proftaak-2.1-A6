using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dokter
{
    public partial class Form3 : Form
    {
        NetworkStream stream;
        List<string> textboxHistory = new List<string>();
        public Form3(NetworkStream stream)
        {
            this.stream = stream;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateText(textBox1.Text);
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
            stream.Write(data, 0, data.Length);
            textBox1.Text = "";
        }

        private void UpdateText(string text)
        {
            textboxHistory.Add(text);
            textBox2.Text = string.Join("\r\n", textboxHistory);
        }
        
    }
}
