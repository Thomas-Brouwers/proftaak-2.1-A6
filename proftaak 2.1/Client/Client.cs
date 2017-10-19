using proftaak_2._1;
using System;
using VRconnection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

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



        public Client() {

            vr = new VRConnector();
            commands = new VRCommands(vr);
            vr.getClientInfo();

            sessionList = commands.refreshConnection(vr.readObject());
            commands.connectClient(sessionList);
            vr.Destination = vr.readObject().SelectToken("data").SelectToken("id").ToString();
            Thread readerThread = new Thread(reading);
            readerThread.Start();
            commands.createPanel("hud");
            commands.route();
            commands.find("Camera");
            //commands.find("chat");

            spp = new FakeData();

            Thread.Sleep(200);

            commands.follow(routeUuid, HUDUuid);
            commands.update(HUDUuid, cameraUuid);

            clientStart();
        }

        public void clientStart()
        {
            Console.WriteLine(HUDUuid);
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
                    Console.WriteLine(Json);
                    JToken token = Json.SelectToken("data").SelectToken("data");
                    string id = token.SelectToken("id").ToString();
                    switch (id)
                    {
                        case "session/list": commands.connectClient(token.SelectToken("data").ToObject<JArray>()); break;
                        case "tunnel/create": vr.Destination = vr.readObject().SelectToken("data").SelectToken("id").ToString(); break;
                        case "route/add": routeUuid = token.SelectToken("data").SelectToken("uuid").ToString(); break;
                        case "scene/node/find":nodeFound(token.SelectToken("data").ToObject<JArray>()); break;
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

        public void nodeAdded(JToken node) {
            switch (node.SelectToken("name").ToString()) {
                case "hud": HUDUuid = node.SelectToken("uuid").ToString(); break;
                case "chat": chatUuid = node.SelectToken("uuid").ToString(); break;
                case "Camera": cameraUuid = node.SelectToken("uuid").ToString(); break;
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
    }
}
