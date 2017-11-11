using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Models
{
    //This is not structured table for professional way
    //But ok for just show up quickly
    public class LeaveBalance
    {
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public int TotalCasualLeave { get; set; }
        public int TotalSickLeave { get; set; }
        public int TotalAnnualLeave { get; set; }
        public int AvailedCasualLeave { get; set; }
        public int AvailedSickLeave { get; set; }
        public int AvailedAnnualLeave { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
