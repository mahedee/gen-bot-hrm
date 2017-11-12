using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBot.Services
{
    public interface IMessageProvider
    {
        Task<bool> SendAsync(string mobileNumber, string message);
    }
}
