﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using HRMBot.Extensions;
using HRMBot.Repository;

namespace HRMBot.Dialogs
{
    [LuisModel("6f13a4ce-dabe-485a-bb3f-9aba3156ea95", "5ea418ae538a402a9b99a936389fd0e7",
        domain: "westus.api.cognitive.microsoft.com")]
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
            try
            {
                var repo = new LeaveRepository();
                var leave = await repo.LeaveAsync(context.Activity.From.Id, context.Activity.ChannelId);


                var message = "You have {0} days of {1} available.";

                switch (result.GetResolvedListEntity("LeaveType"))
                {
                    case "SickLeave":
                        var availableSickLeave = leave.TotalSickLeave - leave.AvailedSickLeave;
                        message = "You have " + availableSickLeave + " days of sick leaves available ";
                        break;

                    case "AnnualLeave":
                        message = string.Format(message, (leave.TotalAnnualLeave - leave.AvailedAnnualLeave),
                            "annual leaves");
                        break;

                    case "CasualLeave":
                        message = string.Format(message, (leave.TotalCasualLeave - leave.AvailedCasualLeave),
                            "casual leave");
                        break;

                    default:
                        var totalAvailableLeave =
                            (leave.TotalSickLeave + leave.TotalAnnualLeave + leave.TotalCasualLeave) -
                            (leave.AvailedSickLeave + leave.AvailedAnnualLeave + leave.AvailedCasualLeave);
                        message = string.Format(message, totalAvailableLeave, "total leaves");
                        break;
                }

                // message += result.GetResolvedListEntity("LeaveType");

                await context.PostAsync(message);
                context.Wait(this.MessageReceived);

            }
            catch (AuthenticationException)
            {
                await context.PostAsync(
                    "You need to verify yourself before I can provide you this information. Please write verify to start the procecss");
                context.Wait(MessageReceived);
            }
            catch (PlatformNotSupportedException)
            {
                await context.PostAsync("This chat platform is not yet supported. Please use Facebook or skype");
                context.Wait(MessageReceived);
            }
        }


        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I don’t have answer of this question. " +
                             $"I am an artificial intelligence system. " +
                             $"I am still learning. ";
            message += StaticMessage.AboutDemo;
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("AvailedLeave")]
        public async Task AvailedLeave(IDialogContext context, LuisResult result)
        {

            try
            {
                var repo = new LeaveRepository();
                var leave = await repo.LeaveAsync(context.Activity.From.Id, context.Activity.ChannelId);


                var message = "You have spent {0} days of {1} so far.";

                switch (result.GetResolvedListEntity("LeaveType"))
                {
                    case "SickLeave":
                        message = string.Format(message, leave.AvailedSickLeave, "sick leaves");
                        break;

                    case "AnnualLeave":
                        message = string.Format(message, leave.AvailedAnnualLeave, "annual leaves");
                        break;

                    case "CasualLeave":
                        message = string.Format(message, leave.AvailedCasualLeave, "casual leave");
                        break;

                    default:
                        message = string.Format(message,
                            leave.AvailedAnnualLeave + leave.AvailedSickLeave + leave.AvailedCasualLeave,
                            "total leaves");
                        break;
                }

                // message += result.GetResolvedListEntity("LeaveType");

                await context.PostAsync(message);
                context.Wait(this.MessageReceived);

            }
            catch (AuthenticationException)
            {
                await context.PostAsync(
                    "You need to verify yourself before I can provide you this information. Please write verify to start the procecss");
                context.Wait(MessageReceived);
            }
            catch (PlatformNotSupportedException)
            {
                await context.PostAsync("This chat platform is not yet supported. Please use Facebook or skype");
                context.Wait(MessageReceived);
            }
        }


        [LuisIntent("EntitledLeave")]
        public async Task EntitledLeave(IDialogContext context, LuisResult result)
        {

            try
            {
                var repo = new LeaveRepository();
                var leave = await repo.LeaveAsync(context.Activity.From.Id, context.Activity.ChannelId);


                var message = "You are entitled to have {0} days of {1} per year.";

                switch (result.GetResolvedListEntity("LeaveType"))
                {
                    case "SickLeave":
                        message = String.Format(message, leave.TotalSickLeave, "sick leaves");
                        break;

                    case "AnnualLeave":
                        message = String.Format(message, leave.TotalAnnualLeave, "annual leaves");
                        break;

                    case "CasualLeave":
                        message = string.Format(message, leave.TotalCasualLeave, "casual leave");
                        break;

                    default:
                        message = string.Format(message,
                            leave.TotalSickLeave + leave.TotalSickLeave + leave.TotalCasualLeave, "total leaves");
                        break;
                }

                // message += result.GetResolvedListEntity("LeaveType");

                await context.PostAsync(message);
                context.Wait(this.MessageReceived);
            }
            catch (AuthenticationException)
            {
                await context.PostAsync(
                    "You need to verify yourself before I can provide you this information. Please write verify to start the procecss");
                context.Wait(MessageReceived);
            }
            catch (PlatformNotSupportedException)
            {
                await context.PostAsync("This chat platform is not yet supported. Please use Facebook or skype");
                context.Wait(MessageReceived);
            }

        }
    }
}