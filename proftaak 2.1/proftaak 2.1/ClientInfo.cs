using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proftaak_2._1
{
    class ClientInfo
    {
        string name;
        string password;
        int avgPulse;
        double distance;
        int avgRpm;
        int avgSpeed;
        int avgPower;
        int energy;

        public ClientInfo(string name, string password, int avgPulse, double distance, int avgRpm, int avgSpeed, int avgPower, int energy)
        {
            this.name = name;
            this.password = password;
            this.avgPulse = avgPulse;
            this.distance = distance;
            this.avgRpm = avgRpm;
            this.avgSpeed = avgSpeed;
            this.avgPower = avgPower;
            this.energy = energy;
        }

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public int Avgpulse { get => avgPulse; set => avgPulse = value; }
        public double Distance { get => distance; set => distance = value; }
        public int Avgrpm { get => avgRpm; set => avgRpm = value; }
        public int Avgspeed { get => avgSpeed; set => avgSpeed = value; }
        public int AvgPower { get => avgPower; set => avgPower = value; }
        public int Energy { get => energy; set => energy = value; }
    }
}
