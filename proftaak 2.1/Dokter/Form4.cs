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
    public partial class Form4 : Form
    {
        List<Data> dataList;
        public Form4()
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

                label7.Text = dataList[0].pulse;
                label9.Text = dataList[0].rpm;
                label3.Text = dataList[0].speed;
                label5.Text = dataList[0].distance;
                label15.Text = dataList[0].requestedPower;
                label13.Text = dataList[0].energy;
                label11.Text = dataList[0].elapsedTime;
                label17.Text = dataList[0].actualpower;

                chart1.DataSource = dataList.ToString();
                chart1.Series["Pulse"].XValueMember = "elapsedTime";
                chart1.Series["Pulse"].YValueMembers = "pulse";
            chart1.DataBind();
            
        }
    }
}
