using proftaak_2._1;
using System;
using VRconnection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

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

        static void Main(string[] args)
        {
            new Client();
        }

        public Client() {
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
    }
}
