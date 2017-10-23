using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dokter
{
    [Serializable]
    class Data
    {
        public String pulse;
        public String rpm;
        public String speed;
        public String distance;
        public String requestedPower;
        public String energy;
        public String elapsedTime;
        public String actualpower;

        public Data(String pulse, String rpm, String speed, String distance, String requestedPower, String energy, String elapsedTime, String actualpower)
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
