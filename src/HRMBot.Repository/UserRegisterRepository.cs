using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using HRMBot.Models;
using HRMBot.Repository.Models;

namespace HRMBot.Repository
{
    public class UserRegisterRepository : IUserRegisterRepository
    {

        public async Task<string> GenerateOtpCodeAsync(string channelId, string id, string mobileNumber, string name)
        {


            var generator = new Random();
            var otp = generator.Next(100000, 1000000).ToString();

            // store the otp with user id
            using (var db = new ApplicationDbContext())
            {

                var userInfo = await db.UserInfos.FirstOrDefaultAsync(p => p.MobileNo.Equals(mobileNumber));
                if (userInfo == null)
                {
                    throw new ObjectNotFoundException("Mobile number is not in database");
                }

                // if there is no userInfo link then create new UserInfo entry
                var tempOtp = new TempOtp();
                if (channelId.Equals("facebook") || channelId.Equals("skype"))
                {
                    tempOtp.ChannelId = channelId;
                    tempOtp.Otp = otp;
                } 
                else
                {
                    throw new PlatformNotSupportedException("Chat medium not supported");
                }

                await db.SaveChangesAsync();
            }
            return otp;
        }

        public async Task<bool> VarifyOtpAsync(string channelId, string id, string otp)
        {
            var success = false;
            UserInfo userInfo;
            using (var db = new ApplicationDbContext())
            {
                if (channelId.Equals("facebook"))
                {
                }
            }

            return success;
        }

        public async Task<string> IsAlreadyVerifiedAsync(string channelId, string id)
        {
            using (var db = new ApplicationDbContext())
            {
                UserInfo user;
                if (channelId.Equals("facebook"))
                {
                    user = await db.UserInfos.FirstOrDefaultAsync(p => p.FacebookId.Equals(id));
                } else if (channelId.Equals("skype"))
                {
                    user = await db.UserInfos.FirstOrDefaultAsync(p => p.SkypeId.Equals(id));
                }
                else
                {
                    throw new PlatformNotSupportedException("Chat medium not supported");
                }
                // var user = await db.Users.FindAsync(id);
                return user?.MobileNo;
            }
        }
    }
}
