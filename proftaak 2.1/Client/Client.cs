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
        FakeData fd;
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

            Thread connectionThread = new Thread(connector);
            connectionThread.Start();
            clientStart();
            //spp = new SerialPortProgram("COM3");
            fd = new FakeData();
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

            bycicleData = fd.update();
            //commands.HUD(bycicleData, HUDUuid);
            dynamic toJson = new
            {
                id = "client/data",
                data = new
                {
                    pulse = bycicleData[0],
                    rpm = bycicleData[1],
                    speed = bycicleData[2],
                    distance = bycicleData[3],
                    requestedPower = bycicleData[4],
                    energy = bycicleData[5],
                    elapsedTime = bycicleData[6],
                    actualPower = bycicleData[7]
                }
            };
            Console.WriteLine(toJson);
            string message = JsonConvert.SerializeObject(toJson);
            byte[] prefix = BitConverter.GetBytes(message.Length);
            byte[] request = Encoding.Default.GetBytes(message);

            byte[] buffer = new Byte[prefix.Length + message.Length];
            prefix.CopyTo(buffer, 0);
            request.CopyTo(buffer, prefix.Length);
            
            stream.Write(buffer, 0, buffer.Length);
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

        public void readChat(JObject Json)
        {
            
                Console.WriteLine(Json);
            
        }

        public void connector()
        {
            try
            {

                Int32 port = 13000;
                TcpClient client = new TcpClient("127.0.0.1", port);

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

                
                    while (true)
                    {
                        byte[] preBuffer = new Byte[4];
                        stream.Read(preBuffer, 0, 4);
                        int lenght = BitConverter.ToInt32(preBuffer, 0);
                        buffer = new Byte[lenght];
                        int totalReceived = 0;
                        while (totalReceived < lenght)
                        {
                            int receivedCount = stream.Read(buffer, totalReceived, lenght - totalReceived);
                            totalReceived += receivedCount;
                        }
                        JObject Json = JObject.Parse(Encoding.UTF8.GetString(buffer));

                        string id = Json.GetValue("id").ToString();
                        switch (id)
                        {
                            case "doctor/chat": readChat(Json); break;
                            //case "doctor/start": clientStart(); break;
                            case "doctor/noodstop": Environment.Exit(0); break;
                            case "doctor/powerup": increasePower(); break;
                            case "doctor/powerdown": decreasePower(); break;
                    }
                    }
                

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

        public void increasePower()
        {

            Console.WriteLine("increasePower");

        }

        public void decreasePower()
        {

            Console.WriteLine("decreasepower");

        }
    }
}
