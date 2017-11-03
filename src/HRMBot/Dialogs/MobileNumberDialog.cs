using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HRMBot.Dialogs
{
    public class MobileNumberDialog : IDialog<int>
    {
        private int _attempts = 3;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("To verify please send your mobile number in 01XXXXXXXXX format. example:- 01771998817");

            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            int mobileNumber;

            if (Int32.TryParse(message.Text, out mobileNumber) && (mobileNumber == 10))
            {
                context.Done(mobileNumber);
            }
            else
            {
                --_attempts;
                if (_attempts > 0 && message.Text.Equals("cancel"))
                {
                    context.Fail(new OperationCanceledException(""));   
                }
                if (_attempts > 0)
                {
                    await context.PostAsync("I'm sorry, I don't understand your reply. What is your Mobile number (e.g. '01771998817')?");

                    context.Wait(this.MessageReceivedAsync);
                }
                else
                {
                    context.Fail(new TooManyAttemptsException("Message was not a valid mobile number."));
                }
            }
        }
    }
}