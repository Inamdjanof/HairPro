using HairPro.Application.Models;
using HairPro.Application.Models.User;
using HairPro.Application.Models.Validators.User;
using HairPro.Application.Services;
using HairPro.Application.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UsersController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;

        }


        [HttpPost("Registration")]
        public async Task<ActionResult> SignUpAsync(CreateUserModel createUserModel)
        {
            var createuser = await this._userService
                .SignUpAsync(createUserModel);
            return Created("" , createuser);    
        }

        [HttpPost("Login")]
        public async Task<ApiResult<LoginResponseModel>>LoginAsync(LoginUserModel loginModel)
        {
            var result = await _userService.LoginAsync(loginModel); 
            return result;
        }


        [HttpPost("SentOtpCode")]
        public async Task<ApiResult<bool>>SentOtpCode(Guid userId)
        {
            var result = await _userService.SendOtpCode(userId);
            return result;
        }


        [HttpPost("ResendOtpCode")]
        public async Task<ApiResult<bool>>ResentOtpCode(Guid userId)
        {
            var result = await _userService.ResendOtpCode(userId);
            return result;  
        }

        [HttpPost("VerifyOtp")]

        public async Task<ApiResult<bool>>VerifyOtpAsync(string otpCode,Guid userId)
        {
            var result = await _userService.VerifyOtpAsync(otpCode, userId);
            return result;  
        }

        
    }
}

