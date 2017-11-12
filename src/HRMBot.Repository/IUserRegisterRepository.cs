using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Repository
{
    public interface IUserRegisterRepository
    {
        Task<string> GenerateOtpCodeAsync(string channelId, string id, string mobileNumber, string name);
        Task<bool> VarifyOtpAsync(string channelId, string id, string otp);
        Task<string> IsAlreadyVerifiedAsync(string channelId, string id);
    }
}
