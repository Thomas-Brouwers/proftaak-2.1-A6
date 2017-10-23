using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Sockets;
using System.Text;
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
                    data = new
                    {
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

            JObject Json = readObject();
            Console.WriteLine(Json);
            if (Json.SelectToken("id").ToString() == "login/succes")
            {
                new Client(stream);
            }
            else
            {
                MessageBox.Show("verkeerde username of wachtwoord ingevoerd");
            }
        }
    }

}