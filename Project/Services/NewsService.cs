using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Project.Services
{
    public class NewsService
    {
        public async Task<string> GetNews()
        {

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://newsdata.io/api/1/news?apikey=pub_2740273453f235601a0dd28a2577dd712fb7&country=us&language=en")
                };

                using (var response = await client.SendAsync(request).ConfigureAwait(false))
                {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Mapper.Mapper.NewsMapper(body);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}