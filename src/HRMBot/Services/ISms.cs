using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Services
{
    interface ISms
    {
        async Task SendAsync(string mobileNumber, string message);
    }
}
