using Lab1.Service;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> weatherPictures;
        private List<string> countryNames;
        private List<string> countryFlags;
        private List<string> countryCities;
        private string selectedCountry;
        private bool countrySet;

        public Form1()
        {
            InitializeComponent();
            countryNames = new List<string>();
            countryFlags = new List<string>();
            countryCities = new List<string>();
            selectedCountry = "";
            countrySet = false;
            weatherPictures = new Dictionary<string, string>
            {
                { "rain", "D:\\Uni\\Year4\\AZIR\\Lab1\\Weather\\rainy_weather.jpg" },
                { "snow", "D:\\Uni\\Year4\\AZIR\\Lab1\\Weather\\snowy_weather.jpg" },
                {"storm", "D:\\Uni\\Year4\\AZIR\\Lab1\\Weather\\stormy_weather.jpg" },
                {"clouds", "D:\\Uni\\Year4\\AZIR\\Lab1\\Weather\\cloudy_weather.jpg" },
                {"sunny", "D:\\Uni\\Year4\\AZIR\\Lab1\\Weather\\sunny_weather.jpg" }
            };
            getCountries();
            currentCountryLabel.Text = "";
        }

        private async void getCountries()
        {
            APICalls api = new APICalls();
            string response = await api.GetCountries();
            JArray countries = JArray.Parse(response);
            foreach (JObject country in countries)
            {
                JObject names = (JObject)country["name"];
                string name = (string)names["common"];
                JObject flags = (JObject)country["flags"];
                string flag = (string)flags["png"];
                countryNames.Add(name);
                countryFlags.Add(flag);
            }
        }
        private async void getWeatherInfo(string city)
        {
            APICalls api = new APICalls();
            string response = await api.GetWeather(city);
            JObject weather = JObject.Parse(response);
            JArray weatherArray = (JArray)weather["weather"];

            JObject weatherInfo = (JObject)weatherArray.First();
            string weatherType = (string)weatherInfo["main"];

            JObject weatherDetails = (JObject)weather["main"];
            string temperatureKelvin = (string)weatherDetails["temp"];
            double temperatureNumber = double.Parse(temperatureKelvin) - 273.15;
            string pressure = (string)weatherDetails["pressure"];
            string humidity = (string)weatherDetails["humidity"];
            temperatureLabel.Text = $"Temperature: {Math.Round(temperatureNumber)} Celsius";
            pressureLabel.Text = $"Pressure: {pressure} mmHg";
            humidityLabel.Text = $"Humidity: {humidity}%";
            if (weatherPictures.ContainsKey(weatherType.ToLower()))
            {
                this.BackgroundImage = System.Drawing.Image.FromFile(weatherPictures[weatherType.ToLower()]);
            }
            else
            {
                this.BackgroundImage = System.Drawing.Image.FromFile(weatherPictures["sunny"]);
            }



        }
        private async void getCities(string country)
        {
            APICalls api = new APICalls();
            string response = await api.GetCountryCities(country);
            JObject responseObject = JObject.Parse(response);
            JArray cities = (JArray)responseObject["data"];
            foreach (string city in cities)
            {
                countryCities.Add(city);
            }

        }

        private void countryName_TextChanged(object sender, EventArgs e)
        {
            string searchText = countryName.Text.ToLower();
            if (countrySet)
            {
                if (searchText.Length > 3)
                {
                    // Filter suggestions based on the current text
                    List<string> filteredSuggestions = countryCities
                        .Where(suggestion => suggestion.ToLower().Contains(searchText))
                        .ToList();

                    // Update the suggestion list
                    UpdateSuggestions(filteredSuggestions);

                    // Show/hide the suggestion list based on the user input
                    suggestionCountryListBox.Visible = filteredSuggestions.Count > 0;
                }
                else
                {
                    suggestionCountryListBox.Visible = false;

                }
            }
            else
            {
                if (searchText.Length > 3)
                {
                    // Filter suggestions based on the current text
                    List<string> filteredSuggestions = countryNames
                        .Where(suggestion => suggestion.ToLower().Contains(searchText))
                        .ToList();

                    // Update the suggestion list
                    UpdateSuggestions(filteredSuggestions);

                    // Show/hide the suggestion list based on the user input
                    suggestionCountryListBox.Visible = filteredSuggestions.Count > 0;
                }
                else
                {
                    suggestionCountryListBox.Visible = false;

                }
            }




        }

        private void UpdateSuggestions(List<string> filteredSuggestions)
        {
            suggestionCountryListBox.Items.Clear();
            suggestionCountryListBox.Items.AddRange(filteredSuggestions.ToArray());
        }

        private void setCountryButton_Click(object sender, EventArgs e)
        {
            if (countrySet)
            {
                getWeatherInfo(countryName.Text);
            }
            else
            {
                selectedCountry = countryName.Text;
                using (WebClient webClient = new WebClient())
                {

                    // Download the image from the URL
                    byte[] imageData = webClient.DownloadData(countryFlags[countryNames.IndexOf(selectedCountry)]);

                    // Create a MemoryStream from the downloaded image data
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageData))
                    {
                        // Set the Image property of the PictureBox
                        countryFlag.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                currentCountryLabel.Text = selectedCountry;
                getCities(selectedCountry);
                countryLabel.Text = "City";
                countrySet = true;
                changeCountry.Visible = true;
                countryName.Text = "";
            }

        }

        private void suggestionCountryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the TextBox with the selected suggestion
            if (suggestionCountryListBox.SelectedIndex != -1)
            {
                countryName.Text = suggestionCountryListBox.SelectedItem.ToString();
                suggestionCountryListBox.Visible = false; // Hide the suggestion list
            }
        }

        private void changeCountry_Click(object sender, EventArgs e)
        {
            countryLabel.Text = "Country";
            currentCountryLabel.Text = "";
            countryFlag.Image = null;
            countrySet = false;
            changeCountry.Visible = false;
            countryName.Text = "";

        }
    }
}
