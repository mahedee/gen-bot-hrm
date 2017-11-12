using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HRMBot.Repository;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HRMBot.Dialogs
{
    [Serializable]
    public class ConfirmMobileNumberDialog : IDialog<bool>
    {
        private int _attempts = 3;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("I have send you a code in your number. Please send me the code");

            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var confirmCode = await result;

            var repo = new UserRegisterRepository();
            var success = await repo.VarifyOtpAsync(context.Activity.ChannelId, context.Activity.From.Id, confirmCode.Text);

            if (success)
            {
                context.Done(true);
            }
            else
            {
                --_attempts;
                if (confirmCode.Text.ToLower().Equals("cancel") || confirmCode.Text.ToLower().Equals("exit"))
                {
                    context.Fail(new OperationCanceledException(""));
                }
                else if (_attempts > 0)
                {
                    await context.PostAsync("Sorry I can not verify your OTP code. What is the OTP code you received in SMS?");

                    context.Wait(this.MessageReceivedAsync);
                }
                else
                {
                    context.Fail(new TooManyAttemptsException("Message was not a valid OTP."));
                }
            }

        }
    }
}