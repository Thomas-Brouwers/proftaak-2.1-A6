using Newtonsoft.Json;
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
            dynamic toJson = new
            {
                id = "doctor/chat",
                data = new
                {
                    data = textBox1.Text
                }
            };
            string message = JsonConvert.SerializeObject(toJson);

            byte[] prefix = BitConverter.GetBytes(message.Length);
            byte[] request = Encoding.Default.GetBytes(message);

            byte[] buffer = new Byte[prefix.Length + message.Length];
            prefix.CopyTo(buffer, 0);
            request.CopyTo(buffer, prefix.Length);

            stream.Write(buffer, 0, buffer.Length);
            textBox1.Text = "";
        }

        private void UpdateText(string text)
        {
            textboxHistory.Add(text);
            textBox2.Text = string.Join("\r\n", textboxHistory);
        }
        
    }
}
