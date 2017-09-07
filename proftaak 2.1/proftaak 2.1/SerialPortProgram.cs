using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace proftaak_2._1
{
    class SerialPortProgram : Ergometer, ISimulator
    {
        private SerialPort serialPort;
        //static void Main(string[] args)
        //{
        //    new SerialPortProgram();
        //}


        public SerialPortProgram(String port)
        {
            serialPort = new SerialPort(port, 9600, Parity.None);
            Boolean on = true;
            Console.WriteLine("Incoming Data");
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataRecieved);
            serialPort.Open();
            while (on)
            {
                serialPort.WriteLine("st");
                Console.Write("\r" + serialPort.ReadLine());
                Thread.Sleep(500);

            }
        }

        private void serialPort_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(serialPort.ReadExisting());
        }
    }
}
