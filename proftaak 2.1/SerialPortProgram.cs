using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace proftaak_2._1
{
    public class SerialPortProgram : Ergometer
    {
        private SerialPort serialPort;
        string[] data2;
        int requestedPower = 25;

        public SerialPortProgram(String port)
        {
            serialPort = new SerialPort(port, 9600, Parity.None);
            
            Console.WriteLine("Incoming Data");
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataRecieved);
            serialPort.Open();
            serialPort.WriteLine("rs");
            Thread.Sleep(10000);
        }

        private void serialPort_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(serialPort.ReadExisting());
        }

        public string[] update()
        {
                serialPort.WriteLine("st");
                string data = serialPort.ReadLine();
                Console.WriteLine(data);
                data2 = data.Split('\t');
                return data2;
        }

        public void increasePower()
        {
            if (requestedPower < 400)
            {
                int power = requestedPower + 5;
                
                serialPort.WriteLine("pw " + power);
                serialPort.WriteLine("cd");
            }
        }

        public void decreasePower()
        {
            if (requestedPower > 25)
            {
                int power = requestedPower - 5;
                serialPort.WriteLine("pw " + power);
                serialPort.WriteLine("cd");
            }
        }
    }
}
