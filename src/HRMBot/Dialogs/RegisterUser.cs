using HRMBot.Extensions;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HRMBot.Repository;
using HRMBot.Services;

namespace HRMBot.Dialogs
{
    public partial class RootLuisDialog
    {

        [LuisIntent("RegisterUser")]
        public async Task RegisterUser(IDialogContext context, LuisResult result)
        {
            //await context.PostAsync("Hello");
            //context.Wait(this.MessageReceived

            var repo = new UserRegisterRepository();
            var registerdMobile = await repo.IsAlreadyVerifiedAsync(context.Activity.ChannelId, context.Activity.From.Id);

            if (registerdMobile != null)
            {
                await context.PostAsync($"You have already verified your mobile number {registerdMobile}");
                context.Wait(this.MessageReceived);
            }
            else
            {
                context.Call(new MobileNumberDialog(), PhoneNumberDialogResumeAfter);
            }


        }

        private async Task PhoneNumberDialogResumeAfter(IDialogContext context, IAwaitable<int> result)
        {
            try
            {
                var mobileNumber = await result;
                // await context.PostAsync($"Your mobile number is {mobileNumber}");

                // generate otp and sent it to mobile
                var repo = new UserRegisterRepository();
                var otp = await repo.GenerateOtpCodeAsync(context.Activity.ChannelId, context.Activity.From.Id, mobileNumber.ToString("D11"), context.Activity.From.Name);
                // send varification message
                // await context.PostAsync($"Your generated otp code is {otp}");
                string message = $"Your verification code for the HRMBot is {otp}";
                IMessageProvider provider = new Sms();
                var success = await provider.SendAsync(mobileNumber.ToString("D11"), message);

                if (!success)
                {
                    await context.PostAsync("Sorry we are having trouble sending OTP. Please try again later");
                    context.Wait(MessageReceived);
                }
                else
                {
                    // start varify dialog
                    context.Call(new ConfirmMobileNumberDialog(), ConfirmMobileNumberResumeAfter);
                }
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Try again later.");
                context.Wait(MessageReceived);
            }
            catch (OperationCanceledException)
            {
                await context.PostAsync("You have canceled the mobile verification process");
                context.Wait(MessageReceived);
            }
            catch (Exception e)
            {
                await context.PostAsync(e.Message);
            }
            
        }

        private async Task ConfirmMobileNumberResumeAfter(IDialogContext context, IAwaitable<bool> result)
        {
            try
            {
                var success = await result;
                if (success)
                {
                    await context.PostAsync("You have successfully verified your mobile number with this account");
                }
                else
                {
                    await context.PostAsync("I'm sorry, I can not confirm your mobile number now. Try again later?");
                }
                context.Wait(MessageReceived);

            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I can not confirm your mobile number now. Try again later.");
                context.Wait(MessageReceived);
            }
            catch (OperationCanceledException)
            {
                await context.PostAsync("You have canceled the mobile verification process");
                context.Wait(MessageReceived);
            }
            catch (Exception e)
            {
                await context.PostAsync(e.Message);
                context.Wait(MessageReceived);
            }
            
        }
    }
}