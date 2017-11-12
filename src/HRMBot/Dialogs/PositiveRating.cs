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
        [LuisIntent("PositiveRating")]
        public async Task PositiveRating(IDialogContext context, LuisResult result)
        {
            List<String> messagePoll = new List<string>
            {
                "It's awesome being able to help",
                "Thank you.",
                "It's my pleasure"
            };

            string message = messagePoll.OrderBy(s => Guid.NewGuid()).First();
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    }
}