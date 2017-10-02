using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace VRconnection
{
    public partial class Form2 : Form
    {
        JArray data;
        VRConnector vrConnector;
        public Form2(VRConnector vr)
        {
            vrConnector = vr;
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
                            position = new[] { 5, 0, 0 },
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
        }

        private void TreeBT_Click(object sender, EventArgs e)
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
                            position = new[] { 10, 0, 5 },
                            scale = 1,
                            rotation = new[] { 0, 0, 0 }
                        },
                        model = new
                        {
                            file = "C:/Users/patri/Downloads/NetworkEngine.17.09.13.2/NetworkEngine/data/NetworkEngine/models/trees/fantasy/tree1.obj",
                            cullbackfaces = false,
                            animated = false,

                        },
                    }
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }
    }
}


