using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Models
{
    public class UserInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string FacebookId { get; set; }
        public int FacebookOTP { get; set; }
        public string SkypeId { get; set; }
        public int SkypeOTP { get; set; }
        public string SlackId { get; set; }
        public int SlackOTP { get; set; }
       
        //OPT for web chat means chatting from web interface
        //Not sure how to maintain credintial from web interface, will fix later
        public int WebOTP { get; set; }

    }
}
