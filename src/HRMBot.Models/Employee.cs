using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Models
{
    public class Employee
    {
        public int Id { get; set; } //PK
        public string FullName { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; } //FK_UserInfo
        //To do --- other properties //
    }
}
