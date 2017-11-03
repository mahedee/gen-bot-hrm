using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Repository.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string OneTimePassword { get; set; }
        public string MobileNumber { get; set; }
        public string TemporaryMobileNumber { get; set; }
    }
}
