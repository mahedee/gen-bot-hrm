using HRMBot.Extensions;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HRMBot.Dialogs
{
    public partial class RootLuisDialog
    {

        [LuisIntent("AboutPerson")]
        public async Task AboutPerson(IDialogContext context, LuisResult result)
        {

            var name = result.GetResolvedEntity("Person");
            name = name == null ? "" : name.ToLower();
            //if(name != null)
            //{

            if (name.Contains("mahedee") || name.Contains("mahadee") || name.Contains("mehede") || name.Contains("mehede"))
            {
                string message = "Mahedee Hasan is a Senior Software Architect of Leadsoft Bangladesh Limited";
                await context.PostAsync(message);
                context.Wait(this.MessageReceived);
            }
            else if (name.Contains("ratan") || name.Contains("roton"))
            {
                string message = "Ratan Sunder Parai is a Software Engineer at Leads Corpooration Ltd. You can contact him via +8801771998817";
                await context.PostAsync(message);
                context.Wait(this.MessageReceived);
            }
            else
            {
                string message = "Sorry I don't have any information about the person right now.";
                string funadd = " Or my developers only care about themselves :p. Please don't tell them about it ;) ";

                Random random = new Random();
                if (random.Next(1, 6) == 6)
                {
                    message += funadd;
                }

                message += StaticMessage.AboutDemo;
                await context.PostAsync(message);
                context.Wait(this.MessageReceived);
            }

        }

    }
}