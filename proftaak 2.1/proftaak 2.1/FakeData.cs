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
   public class FakeData : Ergometer, ISimulator
    {
        Random rand = new Random();
        int pulse = 0;
        double distance = 0;
        int rpm = 0;
        int speed = 0;
        int requestedPower = 0;
        int actualPower = 0;
        int energy = 0;
        DateTime timeOnStart = DateTime.Now;
        TimeSpan timeCurrent;
        string data;
        string[] data2;

        static void Main(string[] args)
        {
           Ergometer.Create("Simulator");
        }


        public FakeData()
        {
            requestedPower = rand.Next(1, 80) * 5;
            Application.Run(new Form1(this));
            Console.WriteLine("Sending Data");
        }

        public string[] update() {
            pulse = rand.Next(80, 120);
            rpm = rand.Next(50, 100);
            speed = rpm * 7 / 20;
            distance += speed / 7.2;
            timeCurrent = DateTime.Now - timeOnStart;
            if (actualPower < requestedPower) {
                actualPower += 5;
            }
            data = "\r" + pulse + "\t" + rpm + "\t" + speed + "\t" + Math.Round(distance) + "\t" + requestedPower + "\t" + energy + "\t" + timeCurrent.ToString(@"mm\:ss") + "\t" + actualPower;
            data2 = data.Split('\t');
            return data2;
        }
    }
}
