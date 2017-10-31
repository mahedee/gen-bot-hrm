using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HRMBot.Services
{
    public class DemoSms : ISms
    {
        public async Task SendAsync(string mobileNumber, string message)
        {
            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", "ratanparai@gmail.com"),
                    new KeyValuePair<string, string>("password", "thisisratan321"),
                    new KeyValuePair<string, string>("device", "64960"),
                    new KeyValuePair<string, string>("number", mobileNumber),
                    new KeyValuePair<string, string>("message", message)

                });

                var response = await client.PostAsync("http://smsgateway.me/api/v3/messages/send", formContent);
            }
        }

        
    }
}