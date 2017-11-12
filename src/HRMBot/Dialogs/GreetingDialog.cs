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
        [LuisIntent("Greetings")]
        public async Task Greetings(IDialogContext context, LuisResult result)
        {

            List<String> messagePoll = new List<string>
            {
                "Hi",
                "Hello there",
                "Hello",
                "Hello " + userData,
                "Hi " + userData
            };

            string message = messagePoll.OrderBy(s => Guid.NewGuid()).First() + ". I am HR Bot. How can I help you?";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    }
}