using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace Lab1.Service
{
    internal class APICalls
    {
        private readonly HttpClient httpClient;
        public APICalls()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<string> GetWeather(string city)
        {
            return await GetApiResponse($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=");//Didn't put the api key for safety :P

        }

        public async Task<string> GetCountries()
        {
            return await GetApiResponse("https://restcountries.com/v3.1/all?fields=name,flags");
        }

        public async Task<string> GetCountryCities(string Country)
        {
            string jsonData = "{\"country\": \"" + Country + "\"}";
            return await PostApi("https://countriesnow.space/api/v0.1/countries/cities", jsonData);
        }
        private async Task<string> PostApi(string apiUrl, string jsonData)
        {
            try
            {
                // Create a StringContent object with the JSON data
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send a POST request and get the response
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"POST successful. Response: {responseData}");
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
        private async Task<string> GetApiResponse(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

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
    }
}
