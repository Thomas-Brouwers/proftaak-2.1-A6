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
            int size = -1;
            var FD = new System.Windows.Forms.OpenFileDialog();
            DialogResult result = FD.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = FD.FileName;
                try
                {
                    using (Stream stream = File.Open(file, FileMode.Open))
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
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }
    }
}

