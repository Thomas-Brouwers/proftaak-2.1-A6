using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace proftaak_2._1
{
    public partial class Form1 : Form
    {
        String[] data;
        SerialPortProgram spp;
        FakeData fd;
        bool simulator;

        public Form1(SerialPortProgram spp)
        {
            this.spp = spp;
            simulator = false;
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1000;
            InitializeComponent();
            timer.Start();
<<<<<<< HEAD
=======

>>>>>>> Server-Applicatie
        }

        public Form1(FakeData fd)
        {
            this.fd = fd;
            simulator = true;
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 500;
            InitializeComponent();
            timer.Start();
        }

        private void update()
        {
            if (data.Length == 8)
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
        }

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            if (simulator)
            {
                data = fd.update();
            }
            else
            {
                data = spp.update();
            }
            update();
        }
    }
}
