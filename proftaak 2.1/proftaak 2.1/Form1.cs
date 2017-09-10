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
        FakeData fd;

        public Form1(String port, SerialPortProgram spp, FakeData fd)
        {
            this.spp = spp;
            this.fd = fd;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 500;
            InitializeComponent();
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

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            if (fd == null)
            {
                data = spp.update();
            } else
            {
                data = fd.update();
            }
            update();
        }
    }
}
