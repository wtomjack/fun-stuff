using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.Services
{
    public class SportsService
    {

        public SportsService()
        {

        }

        public async Task<string> Start()
        {

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://therundown-therundown-v1.p.rapidapi.com/sports"),
                    Headers = {
                            { "x-rapidapi-host", "therundown-therundown-v1.p.rapidapi.com" },
                            { "x-rapidapi-key", "d719cb1efamsh65a07c27581f0fdp1335abjsndda303ac9102" },
                          },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);

                    return body;
                }
            }
            catch(Exception e)
            {

                Console.WriteLine(e.ToString());
                return null;
            }
        }
        
    }
}