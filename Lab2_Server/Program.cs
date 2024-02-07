using System.Net.Sockets;
using System.Net;
using System.Text;

UdpClient udpServer = new UdpClient(12345);

Console.WriteLine("UDP Server is listening on port 12345...");

while (true)
{
    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
    byte[] data = udpServer.Receive(ref clientEndPoint);
    string message = Encoding.UTF8.GetString(data);

    Console.WriteLine($"Received message from {clientEndPoint}: {message}");

    // Echo the message back to the client
    udpServer.Send(data, data.Length, clientEndPoint);
}