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
        [LuisIntent("WhatsUp")]
        public async Task WhatsUp(IDialogContext context, LuisResult result)
        {

            List<String> messagePoll = new List<string>
            {
                "I am fine",
                "Fine",
                "Quite good"
            };

            string message = messagePoll.OrderBy(s => Guid.NewGuid()).First() + ". How can I help you?";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    }
}