using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Services.Auth.Interfaces
{
   public interface IJwtTokenService
    {
        Task<string> GenerateToken(User user);
        string GenerateRefreshToken();

    }

}
