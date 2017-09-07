using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proftaak_2._1
{
    public partial class Form1 : Form
    {
        String[] data;
        SerialPortProgram spp;

        public Form1()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 500;
            InitializeComponent();
            spp = new SerialPortProgram();
            timer.Start();

        }

        private void update()
        {

            pulseValue.Text = data[0];
            rpmValue.Text = data[1];
            speedValue.Text = data[2];
            distanceValue.Text = data[3];
            requestedPowerValue.Text = data[4];
            energyValue.Text = data[5];
            elapsedTimeValue.Text = data[6];
            actualPowerValue.Text = data[7];
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            data = spp.update();
            update();
        }

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            data = spp.update();
            update();
        }
    }
}
