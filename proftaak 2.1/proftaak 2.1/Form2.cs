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
        String destination;
        public Form2(VRConnector vr)
        {
            vrConnector = vr;
            InitializeComponent();
            data = vrConnector.getClientInfo();
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            
            enumerator.MoveNext();
            for (int i = 0; i < data.Count; i++)
            {
                comboBox1.Items.Add(enumerator.Current.ToObject<JObject>().GetValue("clientinfo").ToObject<JObject>().GetValue("user").ToString());
                enumerator.MoveNext();
            }

            for (int i = 0; i < 48; i++){
                comboBox2.Items.Add(i * 0.5);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < comboBox1.SelectedIndex; i++)
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
            destination = vrConnector.readObject().GetValue("data").ToObject<JObject>().GetValue("id").ToString();
            Console.WriteLine(vrConnector.readObject());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = destination,
                    data = new
                    {
                        id = "scene/skybox/settime",
                        data = new
                        {
                            time = comboBox2.SelectedValue
                        }
                    }
                }
            };
            vrConnector.send(JsonConvert.SerializeObject(toJson));

            Console.WriteLine(vrConnector.readObject());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = destination,
                    data = new
                    {
                        id = "scene/skybox/update",
                        data = new
                        {
                            type = "static",
                            files = new
                            {
                                xpos = "data/NetworkEngine/textures/SkyBoxes/interstellar/interstellar_rt.png",
                                xneg = "data/NetworkEngine/textures/SkyBoxes/interstellar/interstellar_lf.png",
                                ypos = "data/NetworkEngine/textures/SkyBoxes/interstellar/interstellar_up.png",
                                yneg = "data/NetworkEngine/textures/SkyBoxes/interstellar/interstellar_dn.png",
                                zpos = "data/NetworkEngine/textures/SkyBoxes/interstellar/interstellar_bk.png",
                                zneg = "data/NetworkEngine/textures/SkyBoxes/interstellar/interstellar_ft.png"

                            }
                        }
                    }
                }
            };
            vrConnector.send(JsonConvert.SerializeObject(toJson));

            Console.WriteLine(vrConnector.readObject());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = destination,
                    data = new
                    {
                        id = "pause",
                        data = new
                        {
                        }
                    }
                }
            };

            vrConnector.send(JsonConvert.SerializeObject(toJson));

            Console.WriteLine(vrConnector.readObject());
        }
    }
}
