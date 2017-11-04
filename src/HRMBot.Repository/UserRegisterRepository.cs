using System;
using System.Threading.Tasks;
using HRMBot.Repository.Models;

namespace HRMBot.Repository
{
    public class UserRegisterRepository : IUserRegisterRepository
    {

        public async Task<string> GenerateOtpCodeAsync(string id, string mobileNumber, string name)
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
                        TemporaryMobileNumber = mobileNumber,
                        Name = name
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

        public async Task<string> isAlreadyVerifiedAsync(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = await db.Users.FindAsync(id);
                return user?.MobileNumber;
            }
        }
    }
}
