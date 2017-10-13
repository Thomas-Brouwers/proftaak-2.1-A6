using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VRconnection
{
    public class VRCommands
    {

        VRConnector vrConnector;
        public VRCommands(VRConnector vr) {
            vrConnector = vr;

        }
        public void HUD(string[] bycicleData, string paneUuid)
        {
            string displayText;
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        displayText = "Pulse = " + bycicleData[0];
                        break;
                    case 1:
                        displayText = "Rpm = " + bycicleData[1];
                        break;
                    case 2:
                        displayText = "Speed = " + bycicleData[2];
                        break;
                    case 3:
                        displayText = "Distance = " + bycicleData[3];
                        break;
                    case 4:
                        displayText = "Requested power = " + bycicleData[4];
                        break;
                    case 5:
                        displayText = "Power = " + bycicleData[5];
                        break;
                    case 6:
                        displayText = "Elapsed time = " + bycicleData[6];
                        break;
                    case 7:
                        displayText = "Actual power = " + bycicleData[7];
                        break;
                    default:
                        displayText = "Error";
                        break;
                }
                dynamic toJson = new
                {
                    id = "scene/panel/drawtext",
                    data = new
                    {
                        id = paneUuid,
                        text = displayText,
                        position = new[] { 50 * (i / 4) + 150, 100.0 * (i % 4) + 100 },
                        color = new[] { 0, 0, 0, 1 }
                    }
                };
                vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
                Console.WriteLine(vrConnector.readObject());
            }
        }

        public void load(string filename)
        {
            dynamic toJson = new
            {
                id = "scene/load",
                data = new
                {
                    filename = filename

                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
            Console.WriteLine(vrConnector.readObject());
        }

        public void find(string item)
        {
            dynamic toJson = new
            {
                id = "scene/node/find",
                data = new
                {
                    name = item
                }
            };
            vrConnector.sendJson(JObject.Parse(JsonConvert.SerializeObject(toJson)));
        }
    }
}
