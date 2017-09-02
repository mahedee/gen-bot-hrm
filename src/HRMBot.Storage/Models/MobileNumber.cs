using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Storage.Models
{
    class MobileNumber
    {
        [Display(Name = "Mobile Number")]
        [Required]
        public int Number { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
