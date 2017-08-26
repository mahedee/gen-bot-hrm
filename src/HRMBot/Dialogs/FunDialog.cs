using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using HRMBot.Services;
using Microsoft.Bot.Connector;

namespace HRMBot.Dialogs
{
    public partial class RootLuisDialog
    {
        [LuisIntent("Jokes")]
        public async Task Jokes(IDialogContext context, LuisResult result)
        {
            List<String> messagePoll = new List<string>
            {
                "One joke incoming...",
                "I hope this one will make you laugh...",
                "Joke incoming"
            };

            string preMessage = messagePoll.OrderBy(s => Guid.NewGuid()).First();
            await context.PostAsync(preMessage);

            var typingMessage = context.MakeMessage();
            typingMessage.Type = ActivityTypes.Typing;
            await context.PostAsync(typingMessage);



            string message = await DadJokeService.GetJoke();
            await context.PostAsync(message);

            
            //BotData userData = await context.UserData.Get()

            context.Wait(this.MessageReceived);
        }
    }
}