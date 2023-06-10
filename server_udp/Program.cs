using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // create server endpoint
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("10.7.173.218"), 3344);

        // create UDP socket
        UdpClient server = new UdpClient(endPoint); // bind to endpoint

        while (true)
        {
            Console.WriteLine("...Waiting for the request...");

            IPEndPoint clientEndPoint = null; // stores sender endpoint

            byte[] request = server.Receive(ref clientEndPoint); // wait until new data received

            string message = Encoding.UTF8.GetString(request);
            Console.WriteLine($"Received message: {message} : {DateTime.Now.ToShortTimeString()} from {clientEndPoint}");

            // send response to the client
            byte[] response = Encoding.UTF8.GetBytes("Thanks for the request!");
            server.Send(response, response.Length, clientEndPoint);
        }
    }
}