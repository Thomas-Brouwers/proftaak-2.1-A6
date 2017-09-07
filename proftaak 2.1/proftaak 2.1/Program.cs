using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using proftaak_2._1;


namespace proftaak_2._1
{
    class SerialPortProgram
    {
        private SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None);
        static void Main(string[] args)
        {
            new SerialPortProgram();
        }


        private SerialPortProgram()
        {
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
