using proftaak_2._1;
using System;
using VRconnection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.IO.Ports;

namespace Clientside
{

    class Client
    {
        private static System.Timers.Timer timer;
        FakeData spp;
        VRConnector vr;
        string[] bycicleData;
        VRCommands commands;
        string HUDUuid, chatUuid, routeUuid, cameraUuid;
        JArray sessionList;
        NetworkStream stream;
        string[] message;


        public Client(NetworkStream stream)
        {
            this.stream = stream;
            message = new string[4] { " ", " ", " ", " " };

            vr = new VRConnector();
            commands = new VRCommands(vr);
            vr.getClientInfo();

            sessionList = commands.refreshConnection(vr.readObject());
            commands.connectClient(sessionList);
            vr.Destination = vr.readObject().SelectToken("data").SelectToken("id").ToString();
            Thread readerThread = new Thread(reading);
            readerThread.Start();
            commands.route();
            commands.createPanel("hud");
            commands.find("Camera");
            commands.createPanel("chat");
            commands.addRoad(routeUuid);
            //string[] ports = SerialPort.GetPortNames();
            //for (int i = 0; i < ports.Length; i++)
            //{
            //    try
            //    {
            //        spp = new SerialPortProgram(ports[i]);

            //    }
            //    catch (Exception e){
            //        Console.WriteLine(e.StackTrace);
            //    }
            //}
            spp = new FakeData();


            Thread serverConnection = new Thread(serverReader);
            serverConnection.Start();


            Thread.Sleep(400);

            
            commands.follow(routeUuid, HUDUuid);
            commands.update(HUDUuid, cameraUuid);
            commands.update(HUDUuid, chatUuid);

            clientStart();
        }

        public void clientStart()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string[] newBycicleData = spp.update();
            if (newBycicleData.Length > 6)
            {
                bycicleData = newBycicleData;
                commands.HUD(bycicleData, HUDUuid);
                commands.speed(bycicleData[2], HUDUuid);
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
                send(JsonConvert.SerializeObject(toJson));
            }
        }

        public void reading()
        {
            while (true)
            {
                Thread.Sleep(1);
                try
                {
                    JObject Json = vr.readObject();
                    //Console.WriteLine(Json);
                    JToken token = Json.SelectToken("data").SelectToken("data");
                    string id = token.SelectToken("id").ToString();
                    switch (id)
                    {
                        case "session/list": commands.connectClient(token.SelectToken("data").ToObject<JArray>()); break;
                        case "tunnel/create": vr.Destination = vr.readObject().SelectToken("data").SelectToken("id").ToString(); break;
                        case "route/add": routeUuid = token.SelectToken("data").SelectToken("uuid").ToString(); break;
                        case "scene/node/find": nodeFound(token.SelectToken("data").ToObject<JArray>()); break;
                        case "scene/node/add": nodeAdded(token.SelectToken("data")); break;
                        case "scene/skybox/settime": break;
                        case "nothingHere": break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public void nodeAdded(JToken node)
        {
            switch (node.SelectToken("name").ToString())
            {
                case "hud": HUDUuid = node.SelectToken("uuid").ToString(); commands.setHUDUuid(HUDUuid); break;
                case "chat": chatUuid = node.SelectToken("uuid").ToString(); commands.setChatUuid(chatUuid); break;
                default: break;
            }
        }

        public void nodeFound(JArray data)
        {
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            JToken node = enumerator.Current;
            switch (node.SelectToken("name").ToString())
            {
                case "Camera": cameraUuid = node.SelectToken("uuid").ToString(); break;
                default: break;
            }
        }

        public void serverReader()
        {

            while(true){
                Thread.Sleep(1);
                try
                {
                    JObject Json = readObject();
                    Console.WriteLine(Json);
                    string id = Json.SelectToken("id").ToString();
                    switch (id)
                    {
                        case "doctor/chat": updateChat(Json.SelectToken("data").SelectToken("text").ToString()); break;
                        //case "doctor/start": clientStart(); break;
                        case "doctor/noodstop": commands.noodstop(); break;
                        case "doctor/powerup": spp.increasePower(); Console.WriteLine("powerup"); break;
                        case "doctor/powerdown": spp.decreasePower(); break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
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

        public JObject readObject()
        {
            int totalReceived = 0;
            byte[] preBuffer = new Byte[4];
            stream.Read(preBuffer, 0, 4);
            int lenght = BitConverter.ToInt32(preBuffer, 0);
            if (lenght != 0)
            {
                byte[] buffer = new Byte[lenght];
                while (totalReceived < lenght)
                {
                    int receivedCount = stream.Read(buffer, totalReceived, lenght - totalReceived);
                    totalReceived += receivedCount;
                }
                JObject Json = JObject.Parse(Encoding.UTF8.GetString(buffer));
                return Json;
            }
            else
            {
                dynamic toJson = new
                {
                    data = new
                    {
                        data = new
                        {
                            id = "nothingHere"
                        }
                    }
                };
                return toJson;
            }
        }

        public void updateChat(string newMessage)
        {
            for (int i = 0; i < message.Length - 1; i++) {
                message[i] = message[i + 1];
            }
            message[3] = newMessage;
            commands.chat(message, chatUuid);
        }
    }
}
