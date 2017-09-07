using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace proftaak_2._1
{
    class FakeData : Ergometer, ISimulator
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



        static void Main(string[] args)
        {
            new FakeData();
        }


        public FakeData()
        {
            Ergometer.Create("COM1");
            requestedPower = rand.Next(1, 80) * 5;
            Boolean on = true;
            Console.WriteLine("Sending Data");
            while (on)
            {
                update();
                Console.WriteLine("\r" + pulse + "\t" + rpm + "\t" + speed + "\t" + Math.Round(distance) + "\t" + requestedPower + "\t" + energy + "\t" + timeCurrent.ToString(@"mm\:ss") + "\t" + actualPower);
                Thread.Sleep(500);
            }
        }

        private void update() {
            pulse = rand.Next(80, 120);
            rpm = rand.Next(50, 100);
            speed = rpm * 7 / 20;
            distance += speed / 7.2;
            timeCurrent = DateTime.Now - timeOnStart;
            if (actualPower < requestedPower) {
                actualPower += 5;
            }
        }
    }
}
