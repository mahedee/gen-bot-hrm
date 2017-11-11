using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //PK
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserInfo UserInfo { get; set; }
    }
}
