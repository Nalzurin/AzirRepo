using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;

TcpClient tcpClient;

List<int> packets = new List<int>();
Random rand = new Random(67589);

Console.WriteLine("Sending packet to remote server: ");
while (true)
{
    try
    {

        int packetId = rand.Next();
        if (!packets.Contains(packetId))
        {
            tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 12345);
            packets.Add(packetId);
            DateTime dateTimeStamp = DateTime.UtcNow;

            string base64Image = CreateAndEncodeImage();

            byte[] packetData = new byte[4 + 4 + base64Image.Length];

            BitConverter.GetBytes(packetId).CopyTo(packetData, 0);
            BitConverter.GetBytes((int)(dateTimeStamp.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).CopyTo(packetData, 4);
            Encoding.UTF8.GetBytes(base64Image).CopyTo(packetData, 8);

            NetworkStream stream = tcpClient.GetStream();
            stream.Write(packetData, 0, packetData.Length);
            Console.WriteLine("Data Sent");
            // Receive and display response from server
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Server Response: {0}", response);
            stream.Close();
            tcpClient.Close();
            Thread.Sleep(10000);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

string CreateAndEncodeImage()
{

    
    Bitmap image = new Bitmap(16, 16);
    Random random = new Random();

    for (int x = 0; x < 16; x++)
    {
        for (int y = 0; y < 16; y++)
        {
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            image.SetPixel(x, y, randomColor);
        }
    }

    
    MemoryStream memoryStream = new MemoryStream();
    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

    
    byte[] imageBytes = memoryStream.ToArray();
    string base64Image = Convert.ToBase64String(imageBytes);

    return base64Image;
}

