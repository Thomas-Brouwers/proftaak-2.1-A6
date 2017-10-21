using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dokter
{
    public partial class Form1 : Form
    {
        NetworkStream stream;
        bool started = false;
        string jsonData;
        Data data;
        public Form1()
        {
            Thread connection = new Thread(ConnectionHandler);
            connection.Start();
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(stream);
            form3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            started = true;
            Console.WriteLine("started");
        }


        private void update(JObject Json)
        {
            if (started) { 
            Console.WriteLine("update");
            MethodInvoker mi = delegate
            {
                label7.Text = Json.GetValue("data").ToObject<JObject>().GetValue("pulse").ToString();
                label9.Text = Json.GetValue("data").ToObject<JObject>().GetValue("rpm").ToString();
                label3.Text = Json.GetValue("data").ToObject<JObject>().GetValue("speed").ToString();
                label5.Text = Json.GetValue("data").ToObject<JObject>().GetValue("distance").ToString();
                label15.Text = Json.GetValue("data").ToObject<JObject>().GetValue("requestedPower").ToString();
                label13.Text = Json.GetValue("data").ToObject<JObject>().GetValue("energy").ToString();
                label11.Text = Json.GetValue("data").ToObject<JObject>().GetValue("elapsedTime").ToString();
                label17.Text = Json.GetValue("data").ToObject<JObject>().GetValue("actualPower").ToString();
                
                data = new Data(label7.Text,
            label9.Text,
            label3.Text,
            label5.Text,
            label15.Text,
            label13.Text,
            label11.Text,
            label17.Text);

                TextWriter writer = null;
                try
                {
                    var contentsToWriteToFile = JsonConvert.SerializeObject(data);
                    writer = new StreamWriter("data.dat", false);
                    writer.Write(contentsToWriteToFile);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }

            };
            if (InvokeRequired)
                this.Invoke(mi);
        }
    }

        public void ConnectionHandler()
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                TcpClient client = new TcpClient("127.0.0.1", port);



                stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                dynamic toJson = new
                {
                    id = "doctor",
                    data = new
                    {

                    }
                };
                string message = JsonConvert.SerializeObject(toJson);

                byte[] prefix = BitConverter.GetBytes(message.Length);
                byte[] request = Encoding.Default.GetBytes(message);

                byte[] buffer = new Byte[prefix.Length + message.Length];
                prefix.CopyTo(buffer, 0);
                request.CopyTo(buffer, prefix.Length);

                stream.Write(buffer, 0, buffer.Length);
                while (true)
                {
                        byte[] preBuffer = new Byte[4];
                        stream.Read(preBuffer, 0, 4);
                        int lenght = BitConverter.ToInt32(preBuffer, 0);
                        buffer = new Byte[lenght];
                        int totalReceived = 0;
                        while (totalReceived < lenght)
                        {
                            int receivedCount = stream.Read(buffer, totalReceived, lenght - totalReceived);
                            totalReceived += receivedCount;
                        }
                        JObject Json = JObject.Parse(Encoding.UTF8.GetString(buffer));

                        string id = Json.GetValue("id").ToString();
                        switch (id)
                        {
                            case "client/data":update(Json); break;
                        }
                    }
               


            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            started = false;
            

        }
    }
}
