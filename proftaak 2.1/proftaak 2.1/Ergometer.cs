using System;

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
