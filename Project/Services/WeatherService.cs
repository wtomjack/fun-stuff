using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Project.Services
{
    using Project.Models;

    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Weather> GetInitialWeather(string zip)
        {
            client.BaseAddress = new Uri("http://dataservice.accuweather.com/");//Replace in config value
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var apiKey = "Kf8qXhrRPgTFQN59hoYGHpMFbeJ2AmCk"; //Replace with config value

            try
            {
               // var locationResponse = await client.GetAsync($"locations/v1/postalcodes/search?apikey={apiKey}&q={zip}");
                var locationKey = "9204_PC";

                //var response = await client.GetAsync($"forecasts/v1/hourly/12hour/{locationKey}?apikey={apiKey}");
                //var hourlyWeather = await response.Content.ReadAsAsync<List<WeatherHour>>();
                var weather = this.TestWeather();//new Weather { Hours = hourlyWeather };

                return weather;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private Weather TestWeather()
        {
            var weather = new Weather();
            weather.Hours.Add(new WeatherHour
                                  {
                                     DateTime = new DateTime(2019, 11, 08, 11, 0, 0),
                                     WeatherIcon = 1,
                                     IconPhrase = "Sunny",
                                     HasPrecipitation = false,
                                     IsDaylight = true,
                                     Temperature = new Temperature
                                                       {
                                                           Unit = "F",
                                                           UnitType = 18,
                                                          Value = 45
                                                       },
                                     PrecipitationProbability = 40
                                    });

            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 12, 0, 0),
                WeatherIcon = 20,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });

            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 13, 0, 0),
                WeatherIcon = 40,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });

            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 14, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });

            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 15, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });
            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 16, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });

            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 17, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });
            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 18, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });
            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 19, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 40
                },
                PrecipitationProbability = 40
            });
            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 20, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 42
                },
                PrecipitationProbability = 40
            });
            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 21, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 45
                },
                PrecipitationProbability = 40
            });

            weather.Hours.Add(new WeatherHour
            {
                DateTime = new DateTime(2019, 11, 08, 22, 0, 0),
                WeatherIcon = 27,
                IconPhrase = "Sunny",
                HasPrecipitation = false,
                IsDaylight = true,
                Temperature = new Temperature
                {
                    Unit = "F",
                    UnitType = 18,
                    Value = 38
                },
                PrecipitationProbability = 40
            });


            return weather;

        }
    }
}