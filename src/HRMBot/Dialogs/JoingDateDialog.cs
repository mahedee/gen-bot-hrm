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
        [LuisIntent("JoiningDate")]
        public async Task JoiningDate(IDialogContext context, LuisResult result)
        {
            List<String> messagePoll = new List<string>
            {
                "Your first day at Leads is {0} ",
                "You joined this company in {0}",
                "It was {0}, when you first enter the office as an employee"
            };

            string message = messagePoll.OrderBy(s => Guid.NewGuid()).First();
            message = String.Format(message, "2nd August, 2009");
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    }
}