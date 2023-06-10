using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client_udp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // endpoint = ip address + port (127.10.55.255:1024)

            UdpClient udpClient = new UdpClient();

            // create server endpoint
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("10.7.173.218"), 3344);

            string message = string.Empty;
            do
            {
                // write a message from keyboard
                Console.Write("Enter a message (enter 'END' to exit): ");
                message = Console.ReadLine();

                // create byte array to send
                byte[] data = Encoding.UTF8.GetBytes(message);

                // send data to the server
                udpClient.Send(data, data.Length, endPoint);

                // show server response
                IPEndPoint serverEndPoint = null; // stores sender endpoint
                byte[] response = udpClient.Receive(ref serverEndPoint);
                string responseMessage = Encoding.UTF8.GetString(response);
                Console.WriteLine($"Server response: {responseMessage} : {DateTime.Now.ToShortTimeString()}");

            } while (message != "END");

            Console.WriteLine("Closing the client application...");
        }
    }
}