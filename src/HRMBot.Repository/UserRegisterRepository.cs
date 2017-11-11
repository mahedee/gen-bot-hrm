using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Threading.Tasks;
using HRMBot.Models;
using HRMBot.Repository.Models;

namespace HRMBot.Repository
{
    public class UserRegisterRepository : IUserRegisterRepository
    {

        public async Task<int> GenerateOtpCodeAsync(string id, string mobileNumber, string name)
        {


            var generator = new Random();
            var otp = generator.Next(100000, 1000000);

            // store the otp with user id
            using (var db = new ApplicationDbContext())
            {

                var employee = await db.Employees.FirstOrDefaultAsync(p => p.MobileNo.Equals(mobileNumber));
                if (employee == null)
                {
                    throw new ObjectNotFoundException("Mobile number is not in database");
                }

                // if there is no userInfo link then create new UserInfo entry
                if (employee?.UserId == null)
                {
                    var userInfo = new UserInfo
                    {
                        FacebookId = id,
                        FacebookOTP = otp
                    };
                }
                else
                {
                    employee.UserInfo.FacebookId = id;
                    employee.UserInfo.FacebookOTP = otp;
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
                if (user?.OneTimePassword != null && user.OneTimePassword.Equals(otp.Trim()))
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
