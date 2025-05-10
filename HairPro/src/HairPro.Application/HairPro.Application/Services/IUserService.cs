using HairPro.Application.Models.User;
using HairPro.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Services
{
    public interface IUserService
    {
        Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel createUserModel);
        Task<ApiResult<bool>> SendOtpCode(Guid userId);
        Task<ApiResult<bool>> ResendOtpCode(Guid userId);
        Task<ApiResult<bool>> VerifyOtpAsync(string code, Guid userId);
        Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginModel);
    }
}
