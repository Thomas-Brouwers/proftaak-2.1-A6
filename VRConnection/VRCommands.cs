using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace VRconnection
{
    public class VRCommands
    {
        JObject chatClear, chatSwap, bycicleClear, bycicleSwap;
        string HUDUuid, chatUuid;
        VRConnector vrConnector;

        public VRCommands(VRConnector vr)
        {
            vrConnector = vr;

        }

        public void HUD(string[] bycicleData, string HUDUuid)
        {
            vrConnector.sendJson(bycicleClear);

            Thread.Sleep(50);
            string displayText;
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        displayText = "Pulse = " + bycicleData[0];
                        break;
                    case 1:
                        displayText = "Rpm = " + bycicleData[1];
                        break;
                    case 2:
                        displayText = "Speed = " + bycicleData[2];
                        break;
                    case 3:
                        displayText = "Distance = " + bycicleData[3];
                        break;
                    case 4:
                        displayText = "Requested power = " + bycicleData[4];
                        break;
                    case 5:
                        displayText = "Power = " + bycicleData[5];
                        break;
                    case 6:
                        displayText = "Elapsed time = " + bycicleData[6];
                        break;
                    case 7:
                        displayText = "Actual power = " + bycicleData[7];
                        break;
                    default:
                        displayText = "Error";
                        break;
                }
                dynamic toJsonText = new
                {
                    id = "scene/panel/drawtext",
                    data = new
                    {
                        id = HUDUuid,
                        text = displayText,
                        position = new[] { 200 * (i / 4) + 50, 100.0 * (i % 4) + 50 },
                        color = new[] { 0, 0, 0, 1 }
                    }
                };
                vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJsonText)));
            }

            vrConnector.sendJson(bycicleSwap);
        }

        public void chat(string[] chat, string chatUuid)
        {
            vrConnector.sendJson(chatClear);

            for (int i = 0; i < chat.Length; i++)
            {
                dynamic toJsonText = new
                {
                    id = "scene/panel/drawtext",
                    data = new
                    {
                        id = chatUuid,
                        text = chat[i],
                        position = new[] { 50, 100.0 * (i % 4) + 50 },
                        color = new[] { 0, 0, 0, 1 }
                    }
                };
                vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJsonText)));
            }

            vrConnector.sendJson(chatSwap);
        }

        public void find(string item)
        {
            dynamic toJson = new
            {
                id = "scene/node/find",
                data = new
                {
                    name = item
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        public void getClients()
        {
            dynamic toJson = new
            {
                id = "session/list",
                data = new { }
            };
            vrConnector.send(JsonConvert.SerializeObject(toJson));
        }

        public void connectClient(JArray data)
        {
            string folderpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            string[] folders = folderpath.Split('\\');
            string username = folders[folders.Length - 1];
            Console.WriteLine(folderpath);
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < data.Count; i++)
            {
                if (enumerator.Current.SelectToken("clientinfo").SelectToken("user").ToString() == username)
                {
                    i = data.Count;
                }
                else
                {
                    enumerator.MoveNext();
                }
            }

            dynamic toJson = new
            {
                id = "tunnel/create",
                data = new
                {
                    session = enumerator.Current.SelectToken("id").ToString(),
                    key = "brain"
                }
            };
            vrConnector.send(JsonConvert.SerializeObject(toJson));
        }

        public JArray refreshConnection(JObject Json)
        {
            return Json.GetValue("data").ToObject<JArray>();
        }

        public void route()
        {
            dynamic toJson = new
            {
                id = "route/add",
                data = new
                {
                    nodes = new[] {

                        new {   pos = new[] { 0, 0, 0 },    dir = new[] { -10, 0, 10} },
                        new {   pos = new[] { 0, 1, 10 },   dir = new[] { 10, 2, 10} },
                        new {   pos = new[] { 10, 2, 10 },  dir = new[] { 10, 2, -10} },
                        new {   pos = new[] { 10, 3, 0 },   dir = new[] { -10, 0, -10} },
                        new {   pos = new[] { 0, 3, 0 },    dir = new[] { -10, 0, 10} },
                        new {   pos = new[] { -10, 3, 0 },  dir = new[] { -10, 0, -10} },
                        new {   pos = new[] { -10, 2, -10 }, dir = new[] { 10, -2, -10} },
                        new {   pos = new[] { 0, 1, -10 },  dir = new[] { 10, -2, 10} }
                    }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }


        public void follow(string routeUuid, string paneUuid)
        {
            dynamic toJson = new
            {
                id = "route/follow",
                data = new
                {
                    route = routeUuid,
                    node = paneUuid,
                    speed = 1.0,
                    offset = 0.0,
                    rotate = "XYZ",
                    followHeight = false,
                    rotateOffset = new[] { 0, 0, 0 },
                    positionOffset = new[] { 0, 0, 0 }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        public void speed(string speed, string paneUuid)
        {
            float newSpeed = float.Parse(speed) / 25;
            dynamic toJson = new
            {
                id = "route/follow/speed",
                data = new
                {
                    node = paneUuid,
                    speed = newSpeed,
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        public void createPanel(string panelName)
        {
            dynamic toJson = new
            {
                id = "scene/node/add",
                data = new
                {
                    name = panelName,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { 1, 1, 1 },
                            scale = 1,
                            rotation = new[] { 0, 0, 0 }
                        },
                        panel = new
                        {
                            size = new[] { 1, 1 },
                            resolution = new[] { 512, 512 },
                            background = new[] { 1, 1, 1, 0 }
                        }
                    }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        public void update(string parent, string child, float[]offset)
        {
            dynamic toJson = new
            {
                id = "scene/node/update",
                data = new
                {
                    id = child,
                    parent = parent,
                    transform = new
                    {
                        position = offset,
                        scale = 1.0,
                        rotation = new[] { 0, 0, 0 },
                    }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        public void setHUDUuid(string huduuid)
        {
            HUDUuid = huduuid;
            dynamic toJson = new
            {
                id = "scene/panel/clear",
                data = new
                {
                    id = HUDUuid
                }
            };
            bycicleClear = JObject.Parse(JsonConvert.SerializeObject(toJson));
            dynamic toJsonSwap = new
            {
                id = "scene/panel/swap",
                data = new
                {
                    id = HUDUuid
                }
            };
            bycicleSwap = JObject.Parse(JsonConvert.SerializeObject(toJsonSwap));

        }

        public void setChatUuid(string chatUuid)
        {
            this.chatUuid = chatUuid;

            dynamic toJson = new
            {
                id = "scene/panel/clear",
                data = new
                {
                    id = chatUuid
                }
            };
            chatClear = JObject.Parse(JsonConvert.SerializeObject(toJson));

            dynamic toJsonSwap = new
            {
                id = "scene/panel/swap",
                data = new
                {
                    id = chatUuid
                }
            };
            chatSwap = JObject.Parse(JsonConvert.SerializeObject(toJsonSwap));
        }

        public void addRoad(string routeUuid)
        {
            dynamic toJson = new
            {
                id = "scene/road/add",
                data = new
                {
                    route = routeUuid,
                    diffuse = "data/NetworkEngine/textures/tarmac_diffuse.png",
                    normal = "data/NetworkEngine/textures/tarmac_normale.png",
                    specular = "data/NetworkEngine/textures/tarmac_specular.png",
                    heightoffset = 0.01
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        public void noodstop() {
            dynamic toJson = new
            {
                id = "pause",
                data = new
                {
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        public void bike() {
            dynamic toJson = new
            {
                id = "scene/node/add",
                data = new
                {
                    name = "bike",
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { 0, 0, 0 },
                            scale = 0.25,
                            rotation = new[] { 0, 0, 0 }
                        },
                        model = new
                        {
                            file = "C:/Users/patri/Downloads/NetworkEngine.17.09.25.1/NetworkEngine/data/NetworkEngine/models/trees/fantasy/tree1.obj",
                            cullbackfaces = false,
                            animated = false
                        },
                    }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }
    }
}
