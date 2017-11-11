using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Models
{
    /// <summary>
    /// <see cref="HRMBot.Models."/>
    /// </summary>
    public class Employee
    {
        public int Id { get; set; } //PK
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual LeaveBalance LeaveBalance { get; set; }
    }
}
