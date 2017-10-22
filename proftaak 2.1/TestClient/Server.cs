using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{
    
    NetworkStream doctorstream;
    NetworkStream clientstream;
    string data;
    bool doctorexists = false;
    JObject jsondata;
    public static void Main()
    {
        new Server();
    }

    public Server()
    {
        TcpListener server = null;
        try
        {
            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];

            // Enter the listening loop.
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                jsondata = ReadObject(stream);

                if (jsondata.GetValue("id").ToString() == "doctor")
                {
                    doctorstream = stream;
                    Thread doctorThread = new Thread(new ParameterizedThreadStart(HandleDoctorComm));

                    doctorThread.Start(client);
                    doctorexists = true;
                }
                if (jsondata.GetValue("id").ToString() == "client")
                {
                    while (!doctorexists) { }
                    clientstream = stream;
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));

                    clientThread.Start(client);


                }
            }
            
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
        }


        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }

    private void HandleClientComm(object client)
    {
        Byte[] bytes = new Byte[256];
        data = null;
        // Process the data sent by the client.
        while (true)
        {
                jsondata = ReadObject(clientstream);
                Console.WriteLine(jsondata);
                SendObject(JsonConvert.SerializeObject(jsondata), doctorstream);
        }
    }
    private void HandleDoctorComm(object client)
    {
        Byte[] bytes = new Byte[256];
        data = null;
        // Process the data sent by the client.
        while (true)
        {
                jsondata = ReadObject(doctorstream);
                Console.WriteLine(jsondata);
                SendObject(JsonConvert.SerializeObject(jsondata), clientstream);
        }
    }

    public JObject ReadObject(NetworkStream stream)
    {
        try
        {
            byte[] preBuffer = new Byte[4];
            stream.Read(preBuffer, 0, 4);
            int lenght = BitConverter.ToInt32(preBuffer, 0);
            byte[] buffer = new Byte[lenght];
            int totalReceived = 0;
            while (totalReceived < lenght)
            {
                int receivedCount = stream.Read(buffer, totalReceived, lenght - totalReceived);
                totalReceived += receivedCount;
            }
            Console.WriteLine(Encoding.UTF8.GetString(buffer));
            JObject Json = JObject.Parse(Encoding.UTF8.GetString(buffer));
            Console.WriteLine(Json);
            return Json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }
    
    public void SendObject(string message, NetworkStream stream)
    {
        try
        {
            byte[] prefix = BitConverter.GetBytes(message.Length);
            byte[] request = Encoding.Default.GetBytes(message);

            byte[] buffer = new Byte[prefix.Length + message.Length];
            prefix.CopyTo(buffer, 0);
            request.CopyTo(buffer, prefix.Length);

            stream.Write(buffer, 0, buffer.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}