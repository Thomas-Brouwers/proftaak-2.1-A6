using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dokter
{
    class Data
    {
        public string pulse;
        public string rpm;
        public string speed;
        public string distance;
        public string requestedPower;
        public string energy;
        public string elapsedTime;
        public string actualpower;

        public Data(string pulse, string rpm, string speed, string distance, string requestedPower, string energy, string elapsedTime, string actualpower)
        {
            this.pulse = pulse;
            this.rpm = rpm;
            this.speed = speed;
            this.distance = distance;
            this.requestedPower = requestedPower;
            this.energy = energy;
            this.elapsedTime = elapsedTime;
            this.actualpower = actualpower;
        }
    }
}
