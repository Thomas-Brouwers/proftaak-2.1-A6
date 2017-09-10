using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proftaak_2._1
{
    public class SerialPortProgram : Ergometer, ISimulator
    {
        private SerialPort serialPort;
        string[] data2;
        //static void Main(string[] args)
        //{
        //    new SerialPortProgram();
        //}


        public SerialPortProgram(String port)
        {
            serialPort = new SerialPort(port, 9600, Parity.None);
            Application.Run(new Form1(this));
            Console.WriteLine("Incoming Data");
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataRecieved);
            serialPort.Open();
        }

        private void serialPort_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(serialPort.ReadExisting());
        }

        public string[] update()
        {
            serialPort.WriteLine("st");
            string data = serialPort.ReadLine();
            data2 = data.Split('\t');
            return data2;
        }
    }
}
