using System.Net.Sockets;

using System.Net;
using System.Text;

int listenPort = 12345;

UdpClient udpServer = new UdpClient(listenPort);

Console.WriteLine("UDP Server is listening on port {0}...", listenPort);

while (true)
{
    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
    byte[] receivedData = udpServer.Receive(ref clientEndPoint);

    DecodeUdpPacket(receivedData);
    string response = "Data received successfully";

    udpServer.Send(Encoding.UTF8.GetBytes(response), Encoding.UTF8.GetBytes(response).Length, clientEndPoint);
}
void DecodeUdpPacket(byte[] packetData)
{
    uint packetId = BitConverter.ToUInt32(packetData, 0);
    int unixTimestamp = BitConverter.ToInt32(packetData, 4);
    DateTime dateTimeStamp = new DateTime(1970, 1, 1).AddSeconds(unixTimestamp);
    byte textLength = packetData[8];
    string text = Encoding.UTF8.GetString(packetData, 9, textLength);

    Console.WriteLine("Packet ID: {0}", packetId);
    Console.WriteLine("Date Time: {0}", dateTimeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
    Console.WriteLine("Text Length: {0}", textLength);
    Console.WriteLine("Text: {0}", text);

}