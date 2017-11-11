using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Models
{
    //This is not structured table for professional way
    //But ok for just show up quickly
    public class LeaveBalance
    {
        public int Id { get; set; } //PK
        public int EmployeeId { get; set; } //FK_Employee
        public int CasualLeaveBalance { get; set; }
        public int SickLeaveBalance { get; set; }
        public int AnnualLeaveBalance { get; set; }
        public int AvailedLeave { get; set; }
        public int AvailedSickLeave { get; set; }
        public int AvailedAnnualLeave { get; set; }
    }
}
