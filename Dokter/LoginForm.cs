using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class LoginForm : Form
    {
        NetworkStream stream;
        public LoginForm()
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

                string usernameText = UserTB.Text;
                string passwordText = PasswordTB.Text;
                dynamic toJson = new
                {
                    id = "doctor/login",
                    data = new
                    {
                        username = usernameText,
                        password = passwordText
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

            JObject Json = readObject();

            if (Json.SelectToken("id").ToString() == "login/succes")
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    DataForm dataForm = new DataForm(stream);
                    dataForm.Show();
                    this.Close();
                }
                else
                {
                    HistoryForm historyForm = new HistoryForm();
                    historyForm.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("verkeerde username of wachtwoord ingevoerd");
            }
        }

        public JObject readObject()
        {
            try
            {
                int totalReceived = 0;
                byte[] preBuffer = new Byte[4];
                stream.Read(preBuffer, 0, 4);
                int lenght = BitConverter.ToInt32(preBuffer, 0);
                byte[] buffer = new Byte[lenght];
                while (totalReceived < lenght)
                {
                    int receivedCount = stream.Read(buffer, totalReceived, lenght - totalReceived);
                    totalReceived += receivedCount;
                }
                JObject Json = JObject.Parse(Encoding.UTF8.GetString(buffer));
                return Json;

            }
            catch (Exception e) { return null; }

        }
    }
}
