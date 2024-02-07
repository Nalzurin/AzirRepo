using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.Serialization.Serializers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;


UdpClient udpClient = new UdpClient();
HttpClient caller = new HttpClient();
IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
string apiKey = Environment.GetEnvironmentVariable("ApiKey");
try
{
    Console.Write("Enter city name: ");
    string city = Console.ReadLine().ToLower();
    while(true)
    {
        WeatherPacket weatherInfo = await GetWeather(city);
        if(weatherInfo != null)
        {
            string jsonData = Serialize(weatherInfo);

            // Convert the JSON string to a byte array
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            // Send the message to the server
            udpClient.Send(data, data.Length, serverEndPoint);
            Console.WriteLine("Data Sent");

            // Receive the response from the server
            byte[] receivedData = udpClient.Receive(ref serverEndPoint);
            string response = Encoding.UTF8.GetString(receivedData);

            Console.WriteLine($"Received response from server: {response}");
            Thread.Sleep(60000);

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

async Task<WeatherPacket> GetWeather(string city)
{
    string weatherInfoJsonRaw = await GetApiResponse($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");
    JObject weather = JObject.Parse(weatherInfoJsonRaw);
    JArray weatherArray = (JArray)weather["weather"];

    JObject weatherInfo = (JObject)weatherArray.First();
    string weatherType = (string)weatherInfo["main"];

    JObject weatherDetails = (JObject)weather["main"];
    string temperatureKelvin = (string)weatherDetails["temp"];

    WeatherPacket weatherPacket = new WeatherPacket();
    weatherPacket.Temperature = float.Round(float.Parse(temperatureKelvin) - 273.15f,2);
    weatherPacket.Pressure = (float)weatherDetails["pressure"];
    weatherPacket.Humidity = (float)weatherDetails["humidity"];
    return weatherPacket;


}

async Task<string> GetApiResponse(string apiUrl)
{
    try
    {
        HttpResponseMessage response = await caller.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        else
        {
            // Handle the error, e.g., log, throw an exception, etc.
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            return null;
        }
    }
    catch (Exception ex)
    {
        // Handle exceptions, e.g., network issues, timeouts, etc.
        Console.WriteLine($"Exception: {ex.Message}");
        return null;
    }
}
static string Serialize(object obj)
{
    return JsonSerializer.Serialize(obj);
}

[Serializable]
public class WeatherPacket
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Pressure { get; set; }
}
