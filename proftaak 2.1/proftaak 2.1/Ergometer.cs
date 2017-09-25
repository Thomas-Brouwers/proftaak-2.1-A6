using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proftaak_2._1;

namespace proftaak_2._1
{
    public abstract class Ergometer : ISimulator
    {
        public static ISimulator Create(String port) {
            if (port == "simulator")
            {
                return new FakeData();
            }
            else {
                return new SerialPortProgram(port);
                    }
        
        }

    }
}
