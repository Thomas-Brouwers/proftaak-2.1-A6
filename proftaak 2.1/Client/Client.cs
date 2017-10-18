using proftaak_2._1;
using System;
using VRconnection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;

namespace Clientside
{

    class Client
    {
        private static System.Timers.Timer timer;
        SerialPortProgram spp;
        VRConnector vr;
        string[] bycicleData;
        VRCommands commands;
        string HUDUuid, ChatUuid;
        JArray scene, sessionList;
        NetworkStream stream;

        static void Main(string[] args)
        {
            new Client();
        }

        public Client() {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                TcpClient client = new TcpClient("127.0.0.1", port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("client");

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                stream = client.GetStream();

                dynamic toJson = new
                {
                    id = "client",
                    data = new
                    {
                    }
                };
                string message = JsonConvert.SerializeObject(toJson);

                byte[] prefix = BitConverter.GetBytes(message.Length);
                byte[] request = Encoding.Default.GetBytes(message);

                byte[] buffer = new Byte[prefix.Length + message.Length];
                prefix.CopyTo(buffer, 0);
                request.CopyTo(buffer, prefix.Length);

                stream.Write(buffer, 0, buffer.Length);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                Thread chatThread = new Thread(readChat);
                chatThread.Start();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            //spp = new SerialPortProgram("COM3");
            vr = new VRConnector();
            commands = new VRCommands(vr);
            vr.getClientInfo();

            sessionList = commands.refreshConnection(vr.readObject());
            commands.connectClient(sessionList);
            vr.Destination = vr.readObject().GetValue("data").ToObject<JObject>().GetValue("id").ToString();
            Thread readerThread = new Thread(reading);
            readerThread.Start();
            
            commands.load("Brain.json");
            commands.find("hud");
            commands.find("chat");


        }

        public void clientStart() {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
           
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            bycicleData = spp.update();
            commands.HUD(bycicleData, HUDUuid);
        }

        public void reading()
        {
            while (true)
            {
                try
                {
                    JObject Json = vr.readObject().SelectToken("data").SelectToken("data").ToObject<JObject>();
                    Console.WriteLine(Json);
                    string id = Json.GetValue("id").ToString();
                    switch (id)
                    {
                        case "session/list": commands.connectClient(Json.GetValue("data").ToObject<JArray>()); break;
                        case "tunnel/create": vr.Destination = vr.readObject().GetValue("data").ToObject<JObject>().GetValue("id").ToString(); break;
                        case "scene/node/find": nodeFound(Json); break;
                        case "scene/skybox/settime": break;
                        case "notReady": break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public void nodeFound(JObject Json) {
            JObject node = Json.GetValue("data").ToObject<JObject>();
            switch (node.GetValue("name").ToString()) {
                case "hud": HUDUuid = node.GetValue("uuid").ToString(); break;
                case "chat": ChatUuid = node.GetValue("uuid").ToString(); break;
            }
        }

        public void readChat()
        {
            while (true)
            {
                byte[] preBuffer = new Byte[4];
                stream.Read(preBuffer, 0, 4);
                int lenght = BitConverter.ToInt32(preBuffer, 0);
                byte[] buffer = new Byte[lenght];
                int totalReceived = 0;
                while (totalReceived < lenght)
                {
                    int receivedCount = stream.Read(buffer, totalReceived, lenght - totalReceived);
                    totalReceived += receivedCount;
                }
                JObject Json = JObject.Parse(Encoding.UTF8.GetString(buffer));
                Console.WriteLine(Json);
            }
        }
    }
}
