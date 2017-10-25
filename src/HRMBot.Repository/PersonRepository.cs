using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Repository
{
    public class PersonRepository : IDisposable
    {
        public void Dispose()
        {
            
        }

        public string GetPersonInformation(string name)
        {
            string message;

            if (name.Contains("mahedee") || name.Contains("mahadee") || name.Contains("mehede") || name.Contains("mehede"))
            {
                message = "Mahedee Hasan is a Senior Software Architect of Leadsoft Bangladesh Limited";
                message += "\n Mobile: +8801787139383 \nfacebook: https://www.facebook.com/mahedee19";
            }
            else if (name.Contains("ratan") || name.Contains("roton"))
            {
                message = "Ratan Sunder Parai is a Software Engineer at Leads Corpooration Ltd. You can contact him via +8801771998817";
            }
            else
            {
                message = "Sorry I don't have any information about the person right now.";
                string funadd = " Or my developers only care about themselves :p. Please don't tell them about it ;) ";

                Random random = new Random();
                if (random.Next(1, 6) == 6)
                {
                    message += funadd;
                }
            }

            return message;
        }

    }
}
