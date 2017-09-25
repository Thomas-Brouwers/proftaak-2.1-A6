using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proftaak_2._1
{
    [Serializable]
    public class ClientInfo
    {
        string name;
        string password;
        int minPulse;
        int maxPulse;
        double distance;
        int avgRpm;
        int avgSpeed;
        int avgPower;
        int energy;
        TimeSpan time;


        public ClientInfo(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public int Minpulse { get => minPulse; set => minPulse = value; }
        public int Maxpulse { get => maxPulse; set => maxPulse = value; }
        public double Distance { get => distance; set => distance = value; }
        public int Avgrpm { get => avgRpm; set => avgRpm = value; }
        public int Avgspeed { get => avgSpeed; set => avgSpeed = value; }
        public int AvgPower { get => avgPower; set => avgPower = value; }
        public int Energy { get => energy; set => energy = value; }
        public TimeSpan Time { get => time; set => time = value; }
    }
}
