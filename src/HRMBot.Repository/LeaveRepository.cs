using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using HRMBot.Models;

namespace HRMBot.Repository
{
    public class LeaveRepository
    {
        public async Task<LeaveBalance> LeaveAsync(string fromId, string channelId)
        {
            using (var db = new ApplicationDbContext())
            {
                UserInfo userInfo;
                if (channelId.Equals("facebook"))
                {
                    userInfo = await db.UserInfos.FirstOrDefaultAsync(p => p.FacebookId.Equals(fromId));
                }
                else if (channelId.Equals("skype"))
                {
                    userInfo = await db.UserInfos.FirstOrDefaultAsync(p => p.SkypeId.Equals(fromId));
                }
                else
                {
                    throw new PlatformNotSupportedException("Chat channel is not supported");
                }

                if(userInfo == null) throw new AuthenticationException("Not verified");

                var employee = await db.Employees.FirstOrDefaultAsync(p => p.UserId == userInfo.Id);
                var leave = await db.LeaveBalances.FirstOrDefaultAsync(p => p.EmployeeId == employee.Id);

                return leave;

            }
        }

    }
}
