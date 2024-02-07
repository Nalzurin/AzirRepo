using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Net.Http;


UdpClient udpClient = new UdpClient();
HttpClient caller = new HttpClient();
IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

try
{
    Console.Write("Enter city name: ");
    string city = Console.ReadLine().ToLower();
    while(true)
    {
        string weatherInfo = await GetWeather(city);
        if(weatherInfo != null)
        {
            
        }
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Send the message to the server
        udpClient.Send(data, data.Length, serverEndPoint);

        // Receive the response from the server
        byte[] receivedData = udpClient.Receive(ref serverEndPoint);
        string response = Encoding.UTF8.GetString(receivedData);

        Console.WriteLine($"Received response from server: {response}");
        Thread.Sleep(60000);
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

async Task<string> GetWeather(string city)
{
    return await GetApiResponse($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=");//Didn't put the api key for safety :P

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

[Serializable]
public class WeatherPacket
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Pressure { get; set; }
}