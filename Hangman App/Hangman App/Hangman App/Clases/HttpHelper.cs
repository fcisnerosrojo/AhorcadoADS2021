using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_App.Clases
{
    public class HttpHelper<T>
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> sendLevelAsync(string level)
        {
            var values = new Dictionary<string, string>
            {
                {"word", level }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://10.0.2.2:3200/hangman/api/v1.0/level/", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }


        public async Task<T> GetRestServiceDataAsync(string serviceAddress)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(serviceAddress);

            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;
        }
    }
}
