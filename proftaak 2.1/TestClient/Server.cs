using proftaak_2._1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

class Server
{

    public static void Main()
    {
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

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                //data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                // Process the data sent by the client.
                BinaryFormatter formatter = new BinaryFormatter();

                clientInfo = (List<ClientInfo>)(formatter.Deserialize(stream));



                Console.WriteLine("Received: {0} {1}", clientInfo[0].Name, clientInfo[0].Password);

                byte[] msg = System.Text.Encoding.ASCII.GetBytes("gelukt");

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", "gelukt");

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
}