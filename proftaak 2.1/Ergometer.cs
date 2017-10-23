using System;

namespace proftaak_2._1
{
    public abstract class Ergometer
    {
        public static void Create(String port) {
            if (port == "simulator")
            {
                new FakeData();
            }
            else {
                new SerialPortProgram(port);
                    }
        
        }

    }
}
