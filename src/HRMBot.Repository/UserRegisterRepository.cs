using System;
using System.Threading.Tasks;
using HRMBot.Repository.Models;

namespace HRMBot.Repository
{
    class UserRegisterRepository : IUserRegisterRepository
    {

        public async Task<string> GenerateOtpCodeAsync(string id, string mobileNumber)
        {

            var generator = new Random();
            var otp = generator.Next(100000, 1000000).ToString();

            // store the otp with user id
            using (var db = new ApplicationDbContext())
            {
                var user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    user = new User
                    {
                        UserId = id,
                        OneTimePassword = otp,
                        TemporaryMobileNumber = mobileNumber
                    };

                    db.Users.Add(user);
                }
                else
                {
                    user.OneTimePassword = otp;
                    user.TemporaryMobileNumber = mobileNumber;
                }

                await db.SaveChangesAsync();
            }
            return otp;
        }

        public async Task<bool> VarifyOtpAsync(string id, string otp)
        {
            var success = false;
            using (var db = new ApplicationDbContext())
            {
                var user = await db.Users.FindAsync(id);
                // check if otp matches
                if (user?.OneTimePassword != null && user.OneTimePassword.Equals(otp))
                {
                    user.MobileNumber = user.TemporaryMobileNumber;
                    await db.SaveChangesAsync();
                    success = true;
                }
            }

            return success;
        }
    }
}
