using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HRMBot.Dialogs
{
    [Serializable]
    public class MobileNumberDialog : IDialog<int>
    {
        private int _attempts = 3;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("To verify please send your mobile number in 01XXXXXXXXX format. example:- 01771998817");

            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (int.TryParse(message.Text, out var mobileNumber) && (mobileNumber.ToString().Length == 10))
            {
                context.Done(mobileNumber);
            }
            else
            {
                --_attempts;
                if (message.Text.ToLower().Equals("cancel") || message.Text.ToLower().Equals("exit"))
                {
                    context.Fail(new OperationCanceledException(""));   
                }
                if (_attempts > 0)
                {
                    await context.PostAsync("I'm sorry, I don't understand your reply. What is your Mobile number (e.g. '01771998817')?");

                    context.Wait(MessageReceivedAsync);
                }
                else
                {
                    context.Fail(new TooManyAttemptsException("Message was not a valid mobile number."));
                }
            }
        }
    }
}