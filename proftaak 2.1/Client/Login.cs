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

namespace Clientside
{
    public partial class Login : Form
    {
        private NetworkStream stream;

        static void Main(string[] args)
        {
            Application.Run(new Login());
        }

        public Login()
        {
            InitializeComponent();
        }

        private void LoginBT_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 13000);
                stream = client.GetStream();

                dynamic toJson = new
                {
                    id = "client",
                    data = new {
                        username = UserTB.Text,
                        password = PasswordTB.Text
                    }
                };

                string message = JsonConvert.SerializeObject(toJson);
                byte[] prefix = BitConverter.GetBytes(message.Length);
                byte[] request = Encoding.Default.GetBytes(message);

                byte[] buffer = new Byte[prefix.Length + message.Length];
                prefix.CopyTo(buffer, 0);
                request.CopyTo(buffer, prefix.Length);

                stream.Write(buffer, 0, buffer.Length);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: {0}", ex);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }
                new Client(stream);
        }
    }
}
