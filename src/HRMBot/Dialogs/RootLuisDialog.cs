using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using HRMBot.Extensions;

namespace HRMBot.Dialogs
{
    [LuisModel("6f13a4ce-dabe-485a-bb3f-9aba3156ea95", "5ea418ae538a402a9b99a936389fd0e7", domain: "westus.api.cognitive.microsoft.com", staging: true)]
    [Serializable]
    public partial class RootLuisDialog : LuisDialog<object>
    {
        private string userData;

        public RootLuisDialog(string userData)
        {
            this.userData = userData;
        }

        [LuisIntent("AvailableLeave")]
        public async Task AvailableLeave(IDialogContext context, LuisResult result)
        {
            //(result.Entities).Items[0]).Resolution).Items[0]).Value
            string message = "You have {0} days of {1} available.";

            switch(result.GetResolvedListEntity("LeaveType"))
            {
                case "SickLeave":
                    message = String.Format(message, 13, "sick leaves");
                    break;

                case "AnnualLeave":
                    message = String.Format(message, 37, "annual leaves");
                    break;

                case "CasualLeave":
                    message = String.Format(message, 9, "casual leave");
                    break;

                default:
                    message = String.Format(message, 59, "total leaves");
                    break;
            }

            // message += result.GetResolvedListEntity("LeaveType");

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);


        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I don’t have answer of this question. I am an artificial intelligence system. I am still learning.";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("AvailedLeave")]
        public async Task AvailedLeave(IDialogContext context, LuisResult result)
        {
            string message = "You have spent {0} days of {1} so far.";

            switch(result.GetResolvedListEntity("SickLeave"))
            {
                case "SickLeave":
                    message = String.Format(message, 8, "sick leaves");
                    break;

                case "AnnualLeave":
                    message = String.Format(message, 15, "annual leaves");
                    break;

                case "CasualLeave":
                    message = String.Format(message, 2, "casual leaves");
                    break;

                case "LeaveWithoutPay":
                    message = String.Format(message, 1, "leave without pay");
                    break;

                default:
                    message = String.Format(message, 26, "total leaves");
                    break;
            }
           


            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }


        [LuisIntent("EntitledLeave")]
        public async Task EntitledLeave(IDialogContext context, LuisResult result)
        {
            string message = "You are entitled to have {0} days of {1} per year.";

            switch (result.GetResolvedListEntity("SickLeave"))
            {
                case "SickLeave":
                    message = String.Format(message, 14, "sick leaves");
                    break;

                case "AnnualLeave":
                    message = String.Format(message, 20, "annual leaves");
                    break;

                case "CasualLeave":
                    message = String.Format(message, 10, "casual leaves");
                    break;

                default:
                    message = String.Format(message, 44, "total leaves");
                    break;
            }

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

    }    
}