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
                if (channelId.Equals("facebook") || channelId.Equals("skype"))
                {
                    var tempOtp = new TempOtp
                    {
                        ChannelId = channelId,
                        Otp = otp,
                        FromId = id,
                        UserId = userInfo.Id
                    };

                    db.TempOtps.Add(tempOtp);
                    await db.SaveChangesAsync();
                } 
                else
                {
                    throw new PlatformNotSupportedException("Chat medium not supported");
                }

            }
            return otp;
        }

        public async Task<bool> VarifyOtpAsync(string channelId, string id, string otp)
        {
            using (var db = new ApplicationDbContext())
            {
                var tempOtp = await db.TempOtps.Where(p => p.FromId.Equals(id) && p.ChannelId.Equals(channelId) && p.Otp.Equals(otp))
                    .FirstOrDefaultAsync();
                if (tempOtp == null) return false;
                var userInfo = await db.UserInfos.Where(p => p.Id == tempOtp.UserId).FirstOrDefaultAsync();
                if (channelId.Equals("facebook"))
                {
                    userInfo.FacebookId = id;
                } else if (channelId.Equals("skype"))
                {
                    userInfo.SkypeId = id;
                }
                // remove entry from TempOtp table
                db.TempOtps.Remove(tempOtp);
                await db.SaveChangesAsync();
                
                return true;
            }

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
