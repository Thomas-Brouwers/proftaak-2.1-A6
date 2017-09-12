using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.IO;

namespace VRconnection
{
    public class VRConnector
    {
        TcpClient client;
        Stream stream;
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

                dynamic toJson = new
                {
                    id = "session/list",
                    data = new { }
                };
                String sessionRequest = JsonConvert.SerializeObject(toJson);

                send(sessionRequest);

                byte[] preBuffer = new Byte[4];
                stream.Read(preBuffer, 0, 4);
                int lenght = 0;
                lenght = BitConverter.ToInt32(preBuffer, 0);
                byte[] buffer = new Byte[lenght];
                int totalReceived = 0;
                while (totalReceived < lenght)
                {
                    int receivedCount = stream.Read(buffer, totalReceived, lenght - totalReceived);
                    totalReceived += receivedCount;
                }
                string json = Encoding.Default.GetString(buffer);

                Console.WriteLine(json);

                stream.Close();
                client.Close();
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
    }
}
