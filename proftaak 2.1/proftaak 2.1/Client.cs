﻿using proftaak_2._1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestClient
{
    class Client
    //testclient om de server te testen
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                TcpClient client = new TcpClient("127.0.0.1", port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("quit");

                // Get a client stream for reading and writing.
                  Stream stream = client.GetStream();
                

                // Send the message to the connected TcpServer. 

                stream.Write(data, 0, data.Length);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Server response: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
        //public void send(string message)
        //{
        //    byte[] prefix = BitConverter.GetBytes(message.Length);
        //    byte[] request = Encoding.Default.GetBytes(message);

        //    byte[] buffer = new Byte[prefix.Length + message.Length];
        //    prefix.CopyTo(buffer, 0);
        //    request.CopyTo(buffer, prefix.Length);

        //    stream.Write(buffer, 0, buffer.Length);
        //}
    }
}

