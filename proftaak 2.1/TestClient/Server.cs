using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using proftaak_2._1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    Stream stream;
    public static void Main()
    {
        new Server();
    }

    public Server() {
        List<ClientInfo> clientInfo = new List<ClientInfo>();
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

                //data = null;

                // Get a stream object for reading and writing
                stream = client.GetStream();

                // Process the data sent by the client.

                JObject data = readObject();
                saveData(data);



                byte[] msg = System.Text.Encoding.ASCII.GetBytes("Acknowledged");

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", "Acknowledged");

                // Shutdown and end connection
                client.Close();
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


    public JObject readObject()
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
        JObject Json = JObject.Parse(Encoding.UTF8.GetString(buffer));
        Console.WriteLine(Json);
        return Json;
    }

    public void saveData(JObject data)
    {
        using (StreamWriter file = File.CreateText("data.txt"))
        {
            JsonSerializer serializer = new JsonSerializer();
            //serialize object directly into file stream
            serializer.Serialize(file, data);
        }
    }
}