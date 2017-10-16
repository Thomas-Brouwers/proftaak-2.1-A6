using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using VRConnection;

namespace VRconnection
{
    public class VRConnector
    {
        string destination;
        TcpClient client;
        Stream stream;
        int lenght;
        int totalReceived = 0;
        byte[] buffer;

        static void Main(string[] args)
        {
            new VRConnector();
        }

        public VRConnector()
        {
            try
            {
                client = new TcpClient();
                client.Connect("145.48.6.10", 6666);
                stream = client.GetStream();
                Application.Run(new VRForm2(this));

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public void send(string message)
        {
            byte[] prefix = BitConverter.GetBytes(message.Length);
            byte[] request = Encoding.Default.GetBytes(message);

            byte[] buffer = new Byte[prefix.Length + message.Length];
            prefix.CopyTo(buffer, 0);
            request.CopyTo(buffer, prefix.Length);

            stream.Write(buffer, 0, buffer.Length);
        }

        public void sendJson(JObject Json)
        {
            dynamic toJson = new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = destination,
                    data = Json
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

        public JObject readObject()
        {
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
            totalReceived = 0;
            return Json;
        }

        public void getClientInfo()
        {
            dynamic toJson = new
            {
                id = "session/list",
                data = new { }
            };
            send(JsonConvert.SerializeObject(toJson));
        }

        public JArray ClientInfo()
        {
            JObject sessionlist = readObject();
            return sessionlist.GetValue("data").ToObject<JArray>();
        }
        public string Destination { get => destination; set => destination = value; }
    }
}
