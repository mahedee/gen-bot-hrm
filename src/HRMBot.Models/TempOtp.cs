using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Models
{
    public class TempOtp
    {
        public int TempOtpId { get; set; }
        public string ChannelId { get; set; }
        public string Otp { get; set; }
        public int UserId { get; set; }
    }
}
