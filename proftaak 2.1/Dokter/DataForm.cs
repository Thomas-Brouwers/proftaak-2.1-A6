using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Dokter
{
    public partial class DataForm : Form
    {
        int destination;
        NetworkStream stream;
        bool started = false;
        string jsonData;
        List<Data> dataList = new List<Data>();
        public DataForm(NetworkStream networkStream)
        {
            stream = networkStream;
            Thread connection = new Thread(ConnectionHandler);
            connection.Start();
            InitializeComponent();
            creategraph();
        }

        private void ChatBT_Click(object sender, EventArgs e)
        {
            ChatForm form3 = new ChatForm(stream);
            form3.Show();
        }

        private void SessionStartBT_Click(object sender, EventArgs e)
        {
            started = true;
        }


        private void update(JObject Json)
        {
            if (started)
            {
                MethodInvoker mi = delegate
                {
                    PulseLB.Text = Json.GetValue("data").SelectToken("pulse").ToString();
                    RPMLB.Text = Json.GetValue("data").SelectToken("rpm").ToString();
                    SpeedLB.Text = Json.GetValue("data").SelectToken("speed").ToString();
                    DistanceLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("distance").ToString();
                    RequestedPowerLB.Text = Json.GetValue("data").SelectToken("requestedPower").ToString();
                    EnergyLB.Text = Json.GetValue("data").SelectToken("energy").ToString();
                    ElapsedTimeLB.Text = Json.GetValue("data").SelectToken("elapsedTime").ToString();
                    ActualPowerLB.Text = Json.GetValue("data").SelectToken("actualPower").ToString();



                    dataList.Add(new Data(PulseLB.Text,
                RPMLB.Text,
                SpeedLB.Text,
                DistanceLB.Text,
                RequestedPowerLB.Text,
                EnergyLB.Text,
                ElapsedTimeLB.Text,
                ActualPowerLB.Text));
                    SpeedChart.Invoke(new Action(() =>
                    {
                        SpeedChart.Series["speed"].Points.AddY(int.Parse(SpeedLB.Text));
                    }));

                };
                if (InvokeRequired)
                    this.Invoke(mi);
            }
        }

        public void updateClients(JObject Json) {
            JArray data = Json.SelectToken("data").SelectToken("clients").ToObject<JArray>();
            IEnumerator<JToken> enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < data.Count; i++)
            {
                ClientsCB.Items.Add(enumerator.Current);
                enumerator.MoveNext();
            }
        }

        public void ConnectionHandler()
        {
            while (true)
            {
                JObject Json = readObject(stream);
                if (Json.GetValue("dest") == ClientsCB.SelectedItem)
                {
                    string id = Json.GetValue("id").ToString();
                    switch (id)
                    {
                        case "client/data": update(Json); break;
                        case "doctor/clients": updateClients(Json); break;
                    }
                }
            }
        }

        private void SessionStopBT_Click(object sender, EventArgs e)
        {
            started = false;
            saveFileDialog1.Filter = "dat files (*.dat)|*.dat";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
                using (Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, dataList);
                }

        }

        private void EmergencyBreakBT_Click(object sender, EventArgs e)
        {
            Console.WriteLine("noodstop");
            dynamic toJson = new
            {
                id = "doctor/noodstop",
                dest = ClientsCB.SelectedIndex,
                data = new
                 {

                 }
            };
            SendObject(JsonConvert.SerializeObject(toJson), stream);
        }

        private void PowerUpBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "doctor/powerup",
                dest = ClientsCB.SelectedIndex,
                data = new
                 {

                 }
            };
            SendObject(JsonConvert.SerializeObject(toJson), stream);
        }

        private void PowerDownBT_Click(object sender, EventArgs e)
        {
            dynamic toJson = new
            {
                id = "doctor/powerdown",
                dest = ClientsCB.SelectedIndex,
                 data = new
                 {

                 }
            };
            SendObject(JsonConvert.SerializeObject(toJson), stream);
        }

        public void creategraph()
        {
            SpeedChart.Series.Add("speed");
            SpeedChart.Series["speed"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SpeedChart.ChartAreas[0].AxisX.IsMarginVisible = false;
        }


        public void SendObject(string message, NetworkStream stream)
        {
            byte[] prefix = BitConverter.GetBytes(message.Length);
            byte[] request = Encoding.Default.GetBytes(message);

            byte[] buffer = new Byte[prefix.Length + message.Length];
            prefix.CopyTo(buffer, 0);
            request.CopyTo(buffer, prefix.Length);

            stream.Write(buffer, 0, buffer.Length);
        }

        public JObject readObject(NetworkStream stream)
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
            totalReceived = 0;
            return Json;
        }
    }
}
