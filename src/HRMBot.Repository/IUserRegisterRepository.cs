using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Repository
{
    public interface IUserRegisterRepository
    {
        Task<string> GenerateOtpCodeAsync(string id, string mobileNumber);
        Task<bool> VarifyOtpAsync(string id, string otp);
    }
}
