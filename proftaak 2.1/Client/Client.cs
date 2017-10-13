using proftaak_2._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRconnection;

namespace Clientside
{
    class Client
    {
        
        SerialPortProgram spp;
        VRConnector vr;
        string[] bycicleData;
        VRCommands commands;
        string paneUuid;

        static void Main(string[] args)
        {
            new Client();
        }

        public Client() {
            //spp = new SerialPortProgram("COM3");
            vr = new VRConnector();
            commands = new VRCommands(vr);
            commands.load("Brain.json");
            commands.find("hud");

        }

        public void clientStart() {

            while (true)
            {

                bycicleData = spp.update();

                commands.HUD(bycicleData, paneUuid);
            }
        }

        public string PaneUuid { get => paneUuid; set => paneUuid = value; }
    }
}
