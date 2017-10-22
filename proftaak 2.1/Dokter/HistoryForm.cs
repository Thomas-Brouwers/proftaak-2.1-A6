using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dokter
{
    public partial class HistoryForm : Form
    {
        List<Data> dataList;
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Stream stream = File.Open("data.dat", FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                dataList = (List<Data>)bformatter.Deserialize(stream);
            }

                PulseLB.Text = dataList[0].pulse;
                RPMLB.Text = dataList[0].rpm;
                SpeedLB.Text = dataList[0].speed;
                DistanceLB.Text = dataList[0].distance;
                RequestedPowerLB.Text = dataList[0].requestedPower;
                EnergyLB.Text = dataList[0].energy;
                ElepsedTimeLB.Text = dataList[0].elapsedTime;
                ActualPowerLB.Text = dataList[0].actualpower;


                

                HistroyChart.DataSource = dataList.ToString();
                HistroyChart.Series["Pulse"].XValueMember = "elapsedTime";
                HistroyChart.Series["Pulse"].YValueMembers = "pulse";
                HistroyChart.DataBind();
            
        }
    }
}
