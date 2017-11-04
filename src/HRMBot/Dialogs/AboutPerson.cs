using HRMBot.Extensions;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HRMBot.Repository;

namespace HRMBot.Dialogs
{
    public partial class RootLuisDialog
    {

        [LuisIntent("AboutPerson")]
        public async Task AboutPerson(IDialogContext context, LuisResult result)
        {

            var name = result.GetResolvedEntity("Person");
            name = name?.ToLower() ?? "";
            string message;
            using(var personRepository = new PersonRepository())
            {
                message = personRepository.GetPersonInformation(name);
            }
            
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
            

        }

    }
}