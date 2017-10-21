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

namespace Dokter
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader("data.dat");
                var fileContents = reader.ReadToEnd();
                Data data = JsonConvert.DeserializeObject<Data>(fileContents);

                label7.Text = data.pulse;
                label9.Text = data.rpm;
                label3.Text = data.speed;
                label5.Text = data.distance;
                label15.Text = data.requestedPower;
                label13.Text = data.energy;
                label11.Text = data.elapsedTime;
                label17.Text = data.actualpower;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
