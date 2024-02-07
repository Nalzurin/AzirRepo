using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System.Diagnostics;
using MongoDB.Bson.Serialization.Attributes;
UdpClient udpServer = new UdpClient(12345);
string connectionUri = Environment.GetEnvironmentVariable("MONGODB_URI");


var settings = MongoClientSettings.FromConnectionString(connectionUri);

// Set the ServerApi field of the settings object to set the version of the Stable API on the client
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

// Create a new client and connect to the server
var client = new MongoClient(settings);

var collection = client.GetDatabase("weatherDataApp").GetCollection<BsonDocument>("weatherData");



Console.WriteLine("UDP Server is listening on port 12345...");

while (true)
{
    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
    byte[] data = udpServer.Receive(ref clientEndPoint);
    BsonDocument weatherDataBson = new BsonDocument();
    WeatherPacket weatherData = Deserialize<WeatherPacket>(data);
    weatherDataBson.Add("temperature", BsonValue.Create(weatherData.Temperature));
    weatherDataBson.Add("pressure", BsonValue.Create(weatherData.Pressure));
    weatherDataBson.Add("humidity", BsonValue.Create(weatherData.Humidity));


    collection.InsertOne(weatherDataBson);
    Console.WriteLine($"Received weather data from {clientEndPoint}:");
    Console.WriteLine($"Temperature: {weatherData.Temperature}°C");
    Console.WriteLine($"Humidity: {weatherData.Humidity}%");
    Console.WriteLine($"Pressure: {weatherData.Pressure} hPa");

    string response = "Data received successfully";

    udpServer.Send(Encoding.UTF8.GetBytes(response), Encoding.UTF8.GetBytes(response).Length, clientEndPoint);
}
T Deserialize<T>(byte[] data)
{
    string jsonData = Encoding.UTF8.GetString(data);
    return JsonSerializer.Deserialize<T>(jsonData);
}

[Serializable]
public class WeatherPacket
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Pressure { get; set; }
}