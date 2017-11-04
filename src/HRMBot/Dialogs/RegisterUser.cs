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

        [LuisIntent("RegisterUser")]
        public async Task RegisterUser(IDialogContext context, LuisResult result)
        {
            //await context.PostAsync("Hello");
            //context.Wait(this.MessageReceived);
            

            context.Call(new MobileNumberDialog(), PhoneNumberDialogResumeAfter);

            ////var activity = context.Activity.;
            //const string message = "To verify please send your mobile number in 01XXXXXXXXX format. example:- 01771998817";
            //await context.PostAsync(message);

            //// start new dialog to get the mobile number

            //context.Wait(this.MessageReceived);


        }

        private async Task PhoneNumberDialogResumeAfter(IDialogContext context, IAwaitable<int> result)
        {
            try
            {
                var mobileNumber = await result;
                await context.PostAsync($"Your mobile number is {mobileNumber}");

                // generate otp and sent it to mobile
                var repo = new UserRegisterRepository();
                var otp = await repo.GenerateOtpCodeAsync(context.Activity.From.Id, mobileNumber.ToString("D11"));
                // send varification message
                await context.PostAsync($"Your generated otp code is {otp}");
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Try again later.");
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception e)
            {
                await context.PostAsync(e.Message);
            }
            finally
            {
                context.Wait(this.MessageReceived);
            }
        }

    }
}