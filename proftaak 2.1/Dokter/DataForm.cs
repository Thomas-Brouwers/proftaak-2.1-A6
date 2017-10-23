using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dokter
{
    public partial class DataForm : Form
    {
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
        }

        private void ChatBT_Click(object sender, EventArgs e)
        {
            ChatForm form3 = new ChatForm(stream);
            form3.Show();
        }

        private void SessionStartBT_Click(object sender, EventArgs e)
        {
            started = true;
            Console.WriteLine("started");
            /*dynamic toJson = new
            {
                id = "doctor/start",
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
            */
        }


        private void update(JObject Json)
        {
            if (started) { 
            Console.WriteLine("update");
            MethodInvoker mi = delegate
            {
                PulseLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("pulse").ToString();
                RPMLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("rpm").ToString();
                SpeedLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("speed").ToString();
                DistanceLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("distance").ToString();
                RequestedPowerLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("requestedPower").ToString();
                EnergyLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("energy").ToString();
                ElapsedTimeLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("elapsedTime").ToString();
                ActualPowerLB.Text = Json.GetValue("data").ToObject<JObject>().GetValue("actualPower").ToString();
               
                
                dataList.Add(new Data(PulseLB.Text,
            RPMLB.Text,
            SpeedLB.Text,
            DistanceLB.Text,
            RequestedPowerLB.Text,
            EnergyLB.Text,
            ElapsedTimeLB.Text,
            ActualPowerLB.Text));
            };
            if (InvokeRequired)
                this.Invoke(mi);
        }
    }

        public void ConnectionHandler()
        {
            while (true)
            {
                JObject Json = readObject(stream);

                string id = Json.GetValue("id").ToString();
                switch (id)
                {
                    case "client/data": update(Json); break;
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
                 data = new
                 {

                 }
            };
            SendObject(JsonConvert.SerializeObject(toJson), stream);
        }

        //public void creategraph() {

        //    SpeedChart.Series.Add("speed");
        //    SpeedChart.Series["speed"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //    SpeedChart.ChartAreas[0].AxisX.IsMarginVisible = false;


        //    SpeedChart.Invoke(new Action(() =>
        //    {
        //        SpeedChart.Series["speed"].Points.AddY(item);
        //    }));


        //    SpeedChart.Invoke(new Action(() =>
        //    {
        //        foreach () {
        //            SpeedChart.Series["speed"].Points.AddY(item);
        //        }
        //    }));
        //}


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
