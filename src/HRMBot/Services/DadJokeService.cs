using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMBot.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HRMBot.Services
{
    public static class DadJokeService
    {
        public static async Task<string> GetJoke()
        {
            const string apiUrl = "https://icanhazdadjoke.com/";

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if(response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var rootResult = JsonConvert.DeserializeObject<DadJoke>(result);
                    return rootResult.joke;
                } else
                {
                    return null;
                }
            }
        }
    }
}