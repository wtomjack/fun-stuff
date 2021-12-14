using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Project.Models.Weather;

namespace Project.Services
{
    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<WeatherObject> GetInitialWeather(string zip)
        {
            var apiKey = "7d7b91c90ab3a1a9ef45c4ec96aa91f6"; //Replace with config value

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api.openweathermap.org/data/2.5/weather?q=chicago&appid=7d7b91c90ab3a1a9ef45c4ec96aa91f6")
                };

                //using (var response = await client.SendAsync(request).ConfigureAwait(false))
                //{
                // response.EnsureSuccessStatusCode();
                var body = "{\"coord\":{\"lon\":-87.65,\"lat\":41.85},\"weather\":[{\"id\":600,\"main\":\"Snow\",\"description\":\"light snow\",\"icon\":\"13d\"}],\"base\":\"stations\",\"main\":{\"temp\":273.64,\"feels_like\":272.22,\"temp_min\":272.55,\"temp_max\":274.48,\"pressure\":1025,\"humidity\":56},\"visibility\":10000,\"wind\":{\"speed\":1.34,\"deg\":305,\"gust\":2.24},\"clouds\":{\"all\":90},\"dt\":1637273888,\"sys\":{\"type\":2,\"id\":2005153,\"country\":\"US\",\"sunrise\":1637239456,\"sunset\":1637274463},\"timezone\":-21600,\"id\":4887398,\"name\":\"Chicago\",\"cod\":200}";//await response.Content.ReadAsStringAsync();
                    var weather = Mapper.Mapper.WeatherMapper(body);
                weather.imageIcon = MapWeatherIcon(weather.MainWeather);
                return weather;
                //}
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private static string MapWeatherIcon(string main)
        {
            if (main == "snow")
            {
                return "Resources/WeatherComponent/WeatherIcons/Snow.png";
            }
            else
            {
                return "Resources/WeatherComponent/WeatherIcons/Sun.png";
            }
        }
    }
}