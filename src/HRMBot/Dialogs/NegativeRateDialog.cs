using HRMBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HRMBot.Dialogs
{
    public partial class RootLuisDialog
    {
        [LuisIntent("NegativeRating")]
        public async Task NegativeRating(IDialogContext context, LuisResult result)
        {
            List<String> messagePoll = new List<string>
            {
                "Sorry to hear that :( . My creators are working night and day to improve me.",
                "I am extremly sorry.",
                "I am sorry for not being able to help you"
            };

            string message = messagePoll.OrderBy(s => Guid.NewGuid()).First();
            message += " " + StaticMessage.AboutDemo;
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    }
}