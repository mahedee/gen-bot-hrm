using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using HRMBot.Models;
using Newtonsoft.Json;

namespace HRMBot.Services
{
    public class Sms : IMessageProvider
    {
        public async Task<bool> SendAsync(string mobileNumber, string message)
        {
            const string apiUrl = "http://smsgateway.me/api/v3/messages/send";

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var email = Environment.GetEnvironmentVariable("mymainemail");
                //var password = Environment.GetEnvironmentVariable("smsgateway_password");
                //var device = Environment.GetEnvironmentVariable("smsgateway_device");
                const string email = "ratanparai@gmail.com";
                const string password = "thisisratan321";
                const string device = "64960";

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("device", device),
                    new KeyValuePair<string, string>("number", mobileNumber),
                    new KeyValuePair<string, string>("message", message)
                });

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}