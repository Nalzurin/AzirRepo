using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

UdpClient udpClient = new UdpClient();
IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
List<int> packets = new List<int>();
Random rand = new Random(67589);
try
{
    Console.Write("Sending packet to remote server: ");
    while (true)
    {
        

        int packetId = rand.Next();
        if (!packets.Contains(packetId))
        {
            packets.Add(packetId);
            byte length = (byte)rand.Next(5, 255);
            string message = RandomString(length);
            DateTime dateTimeStamp = DateTime.UtcNow;
            int unixTimestamp = (int)(dateTimeStamp.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            byte[] packetData = new byte[4 + 4 + 1 + message.Length];
            BitConverter.GetBytes(packetId).CopyTo(packetData, 0);
            BitConverter.GetBytes(unixTimestamp).CopyTo(packetData, 4);
            packetData[8] = length;
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            Array.Copy(messageBytes, 0, packetData, 9, messageBytes.Length);
            udpClient.Send(packetData, packetData.Length, serverEndPoint);
            Console.WriteLine("Data Sent");
            // Receive the response from the server
            byte[] receivedData = udpClient.Receive(ref serverEndPoint);
            string response = Encoding.UTF8.GetString(receivedData);

            Console.WriteLine($"Received response from server: {response}");
            Thread.Sleep(10000);
        }

    }


}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    udpClient.Close();
}
string RandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[rand.Next(s.Length)]).ToArray());
}
