using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Models
{
    public class QuickEntryVM
    {
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }
    }
}
