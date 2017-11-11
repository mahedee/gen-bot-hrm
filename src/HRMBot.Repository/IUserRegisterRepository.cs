using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Repository
{
    public interface IUserRegisterRepository
    {
        Task<int> GenerateOtpCodeAsync(string id, string mobileNumber, string name);
        Task<bool> VarifyOtpAsync(string id, string otp);
        Task<string> isAlreadyVerifiedAsync(string id);
    }
}
