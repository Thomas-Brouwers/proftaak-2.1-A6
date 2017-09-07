using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using proftaak_2._1;
using System.Windows.Forms;

namespace proftaak_2._1
{
    public class SerialPortProgram
    {
        string[] data2;
        private SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None);
        static void Main(string[] args)
        {
            
            Application.Run(new Form1());

        }


        public SerialPortProgram()
        {
            //Console.WriteLine("Incoming Data");
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataRecieved);
            serialPort.Open();
            
        }

        private void serialPort_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.WriteLine(serialPort.ReadExisting());
        }
        public string[] update() {
            serialPort.WriteLine("st");
            string data = serialPort.ReadLine();
            data2 = data.Split('\t');
            return data2;
        }
    }
}
