using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

int listenPort = 12345; 

TcpListener tcpListener = new TcpListener(IPAddress.Any, listenPort);
tcpListener.Start();


Console.WriteLine("TCP Server is listening on port {0}...", listenPort);
try
{

    while (true)
    {
        TcpClient tcpClient = tcpListener.AcceptTcpClient();
        Console.WriteLine("Client connected.");

        NetworkStream stream = tcpClient.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        byte[] receivedData = new byte[bytesRead];
        Array.Copy(buffer, receivedData, bytesRead);

        ProcessTcpImagePacket(receivedData);

        string responseMessage = "Image received successfully!";
        byte[] responseBytes = Encoding.UTF8.GetBytes(responseMessage);
        stream.Write(responseBytes, 0, responseBytes.Length);
        stream.Close();
        tcpClient.Close();
        Console.WriteLine("Client disconnected.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

void ProcessTcpImagePacket(byte[] packetData)
{
    uint packetId = BitConverter.ToUInt32(packetData, 0);
    int unixTimestamp = BitConverter.ToInt32(packetData, 4);
    DateTime dateTimeStamp = new DateTime(1970, 1, 1).AddSeconds(unixTimestamp);
    string base64Image = Encoding.UTF8.GetString(packetData, 8, packetData.Length - 8);
    SavePacketDetailsToJson(packetId, dateTimeStamp, base64Image);
}



void SavePacketDetailsToJson(uint packetId, DateTime dateTimeStamp, string base64Image)
{
    var packetDetails = new
    {
        PacketId = packetId,
        DateTimeStamp = dateTimeStamp.ToString("yyyy-MM-dd HH:mm:ss"),
        Base64Image = base64Image
    };
    string json = JsonConvert.SerializeObject(packetDetails);
    string fileName = $"{packetId}.json";
    File.WriteAllText(fileName, json);
    Console.WriteLine($"Packet details saved to: {fileName}");
}