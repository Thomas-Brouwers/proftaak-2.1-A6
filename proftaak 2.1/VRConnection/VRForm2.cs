using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VRconnection;
using System.Threading;

namespace VRConnection
{
    public partial class VRForm2 : Form
    {
        JArray data, scene;
        static VRConnector vrConnector;
        //string routeUuid, treeUuid, paneUuid, headUuid;
        //SerialPortProgram spp;



        public VRForm2(VRConnector vr)
        {
            vrConnector = vr;
            InitializeComponent();
            vrConnector.getClientInfo();
            refreshConnection(vrConnector.readObject());

            for (int i = 0; i < 24; i++)
            {
                TimeCB.Items.Add(i);
            }
            SceneLV.MultiSelect = false;
        }

        private void ConnectBT_Click(object sender, EventArgs e)
        {
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < ConnectCB.SelectedIndex; i++)
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
            Thread readerThread = new Thread(reading);
            readerThread.Start();
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
        }

        private void FindBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "scene/node/find",
                data = new
                {
                    name = FindTF.Text
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        private void RefreshSceneBT_Click(object sender, EventArgs e)
        {
            SceneLV.Items.Clear();
            dynamic toJson = new
            {
                id = "scene/get"
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }

        private void RefreshConnectionsBT_Click(object sender, EventArgs e)
        {
            ConnectCB.Items.Clear();
            vrConnector.getClientInfo();
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < data.Count; i++)
            {
                ConnectCB.Items.Add(enumerator.Current.ToObject<JObject>().GetValue("clientinfo").ToObject<JObject>().GetValue("user").ToString());
                enumerator.MoveNext();
            }
        }

        private void SceneLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SceneLV.SelectedIndices.Count > 0)
            {
                IEnumerator<JToken> enumerator = scene.GetEnumerator();
                enumerator.MoveNext();
                for (int i = 0; i < SceneLV.SelectedIndices[0]; i++)
                {
                    enumerator.MoveNext();
                }
                ItemLB.Text = enumerator.Current.ToString();
            }
        }

        private void reading()
        {
            while (true)
            {
                try
                {
                    JObject Json = vrConnector.readObject().SelectToken("data").SelectToken("data").ToObject<JObject>();
                    Console.WriteLine(Json);
                    string id = Json.GetValue("id").ToString();
                    switch (id)
                    {
                        case "scene/get": refreshScene(Json); break;
                        case "session/list": refreshConnection(Json); break;
                        case "tunnel/create": vrConnector.Destination = vrConnector.readObject().GetValue("data").ToObject<JObject>().GetValue("id").ToString(); break;
                        case "scene/skybox/settime": break;
                        case "notReady": break;
                        default:  break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        private void refreshScene(JObject Json) {
            scene = Json.SelectToken("data").SelectToken("children").ToObject<JArray>();
            IEnumerator<JToken> enumerator = scene.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < scene.Count; i++)
            {
                SceneLV.Items.Add(enumerator.Current.ToObject<JObject>().GetValue("name").ToString());
                enumerator.MoveNext();
            }
        }

        private void VRForm2_Load(object sender, EventArgs e)
        {

        }

        private void refreshConnection(JObject Json)
        {
            ConnectCB.Items.Clear();
            data = Json.GetValue("data").ToObject<JArray>();
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < data.Count; i++)
            {
                ConnectCB.Items.Add(enumerator.Current.ToObject<JObject>().GetValue("clientinfo").ToObject<JObject>().GetValue("user").ToString());
                enumerator.MoveNext();
            }

        }


    }
}
