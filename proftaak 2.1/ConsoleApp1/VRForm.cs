using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using proftaak_2._1;

namespace VRconnection
{
    public partial class VRForm : Form
    {
        JArray data;
        VRConnector vrConnector;
        string routeUuid, treeUuid, paneUuid, headUuid;
        SerialPortProgram spp;
        Timer timer;
        
        public VRForm(VRConnector vr)
        {
            vrConnector = vr;
            //spp = new SerialPortProgram("Simulator");
            InitializeComponent();
            data = vrConnector.getClientInfo();
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < data.Count; i++)
            {
                ConnectionsCB.Items.Add(enumerator.Current.ToObject<JObject>().GetValue("clientinfo").ToObject<JObject>().GetValue("user").ToString());
                enumerator.MoveNext();
            }

            for (int i = 0; i < 24; i++)
            {
                TimeCB.Items.Add(i);
            }
        }

        private void ConnectionsBT_Click(object sender, EventArgs e)
        {
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < ConnectionsCB.SelectedIndex; i++)
            {
                enumerator.MoveNext();
            }

            dynamic toJson = new
            {
                id = "tunnel/create",
                data = new
                {
                    session = enumerator.Current.ToObject<JObject>().GetValue("id").ToString(),
                    key = "brain"
                }
            };

            vrConnector.send(JsonConvert.SerializeObject(toJson));
            vrConnector.Destination = vrConnector.readObject().GetValue("data").ToObject<JObject>().GetValue("id").ToString();
            //Console.WriteLine(vrConnector.readObject());
        }

        private void TimeBT_Click(object sender, EventArgs e)
        {
            float selectedTime = TimeCB.SelectedIndex;
            dynamic toJson = new
            {
                id = "scene/skybox/settime",
                data = new
                {
                    time = selectedTime
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            Console.WriteLine(vrConnector.readObject());
        }



        private void PlayBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "pause",
                data = new
                {
                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            Console.WriteLine(vrConnector.readObject());
        }

        private void PaneBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "scene/node/add",
                data = new
                {
                    name = "paneltest",
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { 5, 1, 0 },
                            scale = 1,
                            rotation = new[] { 0, 0, 0 }
                        },
                        panel = new
                        {
                            size = new[] { 1, 1 },
                            resolution = new[] { 512, 512 },
                            background = new[] { 1, 1, 1, 1 }
                        }
                    }
                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));

            JObject PaneObject = vrConnector.readObject();
            paneUuid = PaneObject.GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JObject>().GetValue("uuid").ToString();
            Console.WriteLine(PaneObject);
        }

        private void TreeBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "scene/node/add",
                data = new
                {
                    name = "treetest",
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { 10, 0, 5 },
                            scale = 1,
                            rotation = new[] { 0, 0, 0 }
                        },
                        model = new
                        {
                            file = "C:/Users/patri/Downloads/NetworkEngine.17.09.25.1/NetworkEngine/data/NetworkEngine/models/trees/fantasy/tree1.obj",
                            cullbackfaces = false,
                            animated = false,

                        },
                    }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            JObject treeObject = vrConnector.readObject();
            treeUuid = treeObject.GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JObject>().GetValue("uuid").ToString();
            Console.WriteLine(treeObject);
        }

        private void RouteBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "route/add",
                data = new
                {
                    nodes = new[] {

                        new {   pos = new[] { 0, 0, 0 }, dir = new[] { -10, 0, 10} },
                        new {   pos = new[] { 0, 1, 10 }, dir = new[] { 10, 2, 10} },
                        new {   pos = new[] { 10, 2, 10 }, dir = new[] { 10, 2, -10} },
                        new {   pos = new[] { 10, 3, 0 }, dir = new[] { -10, 0, -10} },
                        new {   pos = new[] { 0, 3, 0 }, dir = new[] { -10, 0, 10} },
                        new {   pos = new[] { -10, 3, 0 }, dir = new[] { -10, 0, -10} },
                        new {   pos = new[] { -10, 2, -10 }, dir = new[] { 10, -2, -10} },
                        new {   pos = new[] { 0, 1, -10 }, dir = new[] { 10, -2, 10} },
                    }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            JObject routeObject = vrConnector.readObject();
            routeUuid = routeObject.GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JObject>().GetValue("uuid").ToString();
            Console.WriteLine(routeObject);
        }

        private void DebugBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "route/show",
                data = new { }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));

            Console.WriteLine(vrConnector.readObject());
        }

        private void TerrainBT_Click(object sender, EventArgs e)
        {
            int[] heightarray = new int[1024];
            Random random = new Random();
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    heightarray.SetValue((int)(Math.Sin((j + i) * (16/Math.PI)) * 10), i * 32 + j);
                }
            }

            dynamic toJson = new
            {
                id = "scene/terrain/add",
                data = new
                {
                    size = new[] { 32, 32 },
                    heights = heightarray // 1024 values
                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            Console.WriteLine(vrConnector.readObject());

            dynamic toJson2 = new
            {
                id = "scene/node/add",
                data = new
                {
                    name = "terrainTest",
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { 10, 0, 5 },
                            scale = 1,
                            rotation = new[] { 0, 0, 0 }
                        },
                        terrain = new
                        {
                            smoothnormals = true
                        }
                    }
                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson2)));
            Console.WriteLine(vrConnector.readObject());

        }

        private void HUDBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "scene/panel/clear",
                data = new
                {
                    id = paneUuid

                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            Console.WriteLine(vrConnector.readObject());
            dynamic toJson5 = new
            {
                id = "scene/panel/swap",
                data = new
                {
                    id = paneUuid
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson5)));
            Console.WriteLine(vrConnector.readObject());

            dynamic toJson2 = new
            {
                id = "scene/panel/setclearcolor",
                data = new
                {
                    id = paneUuid,
                    color = new[] { 1, 1, 1, 1 }
                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson2)));
            Console.WriteLine(vrConnector.readObject());

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson5)));
            Console.WriteLine(vrConnector.readObject());

            dynamic toJson3 = new
            {
                id = "scene/panel/drawtext",
                data = new
                {
                    id = paneUuid,
                    text = "Hello World",
                    position = new[] { 50.0, 50.0 },
                    color = new[] { 0, 0, 0, 1 }
                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson3)));
            Console.WriteLine(vrConnector.readObject());

            dynamic toJson4 = new
            {
                id = "scene/panel/drawtext",
                data = new
                {
                    id = paneUuid,
                    text = "Hello World",
                    position = new[] { 100.0, 100.0 },
                    color = new[] { 0, 0, 0, 1 }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson4)));
            Console.WriteLine(vrConnector.readObject());



            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson5)));
            Console.WriteLine(vrConnector.readObject());

            timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1500;
            timer.Start();
        }

        private void UpdateBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new {
                id = "scene/node/update",
                data = new
                {
                    id = headUuid,
                    parent = paneUuid,
                    transform = new
                    {
                        position = new[] { 1, 0, 0 },
                        scale = 1.0,
                        rotation = new[] { 0, 0, 0 },
                    }
                    //animation = new
                    //{
                    //    name = "walk",
                    //    speed = 0.5
                    //}
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            Console.WriteLine(vrConnector.readObject());
        }

        private void HeadBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "scene/node/find",
                data = new
                {
                    name = "Camera"
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            JObject headObject = vrConnector.readObject();
            JArray headArray = headObject.GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JObject>().GetValue("data").ToObject<JArray>();
            IEnumerator<JToken> enumerator = headArray.GetEnumerator();
            enumerator.MoveNext();
            headUuid = enumerator.Current.ToObject<JObject>().GetValue("uuid").ToString();
            Console.WriteLine(headObject);

        }

        private void FollowBT_Click(object sender, EventArgs e)
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
            Console.WriteLine(vrConnector.readObject());
        }



        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs) {
            string[] bycicleData = spp.update();
            string displayText;

            dynamic toJson1 = new
            {
                id = "scene/panel/clear",
                data = new
                {
                    id = paneUuid

                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson1)));



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
                dynamic toJson = new
                {
                    id = "scene/panel/drawtext",
                    data = new
                    {
                        id = paneUuid,
                        text = displayText,
                        position = new[] {50 * (i / 4) + 150 , 100.0 * (i % 4) + 100 },
                        color = new[] { 0, 0, 0, 1 }
                    }
                };
                vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
                Console.WriteLine(vrConnector.readObject());
            }
            dynamic toJson5 = new
            {
                id = "scene/panel/swap",
                data = new
                {
                    id = paneUuid
                }
            };

            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson5)));
            Console.WriteLine(vrConnector.readObject());

        }
    }
}


