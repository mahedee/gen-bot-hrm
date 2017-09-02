using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Storage.Models
{
    class Employee
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<MobileNumber> MobileNumbers { get; set; }
        
    }
}
