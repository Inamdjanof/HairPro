using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.User
{
    public class UserSettings
    {
        public int OtpExpirationTimeInSeconds { get; set; } = 300;
        public int OtpResendTimeInSeconds { get; set; } = 60;
        public int RefreshTokenExpirationDays { get; set; } = 3;
    }

}
