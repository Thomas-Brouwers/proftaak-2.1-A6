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
    public partial class ChatForm : Form
    {
        NetworkStream stream;
        List<string> textboxHistory = new List<string>();
        public ChatForm(NetworkStream stream)
        {
            this.stream = stream;
            InitializeComponent();
        }

        private void SendBt_Click(object sender, EventArgs e)
        {
            UpdateText(ChatInputTB.Text);
            dynamic toJson = new
            {
                id = "doctor/chat",
                data = new
                {
                    text = ChatInputTB.Text
                }
            };
            string message = JsonConvert.SerializeObject(toJson);

            byte[] prefix = BitConverter.GetBytes(message.Length);
            byte[] request = Encoding.Default.GetBytes(message);

            byte[] buffer = new Byte[prefix.Length + message.Length];
            prefix.CopyTo(buffer, 0);
            request.CopyTo(buffer, prefix.Length);

            stream.Write(buffer, 0, buffer.Length);
            ChatInputTB.Text = "";
        }

        private void UpdateText(string text)
        {
            textboxHistory.Add(text);
            ChatHistoryTB.Text = string.Join("\r\n", textboxHistory);
        }
        
    }
}
