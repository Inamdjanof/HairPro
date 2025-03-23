using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Services.Auth.Interfaces
{

    public interface IOtpService
    {
        Task GenerateAndSendOtpAsync(Guid userId, string email);
        Task<bool> VerifyOtpAsync(Guid userId, string code);
    }


}
