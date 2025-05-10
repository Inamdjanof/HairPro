using AutoMapper;
using HairPro.Application.Helpers;
using HairPro.Application.Helpers.GenerateJwt;
using HairPro.Application.Models;
using HairPro.Application.Models.User;
using HairPro.Application.Models.Validators.User;
using HairPro.Core.Entities;
using HairPro.Core.Enums;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using HairPros.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<User> _userManager;
        public readonly DatabaseContext _dbContext;
        private readonly SignInManager<User> _signInManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IEmailService _emailService;
        private readonly UserSettings _userSettings;

        public UserService(
            IMapper mapper,
            IConfiguration configuration,
            ILogger<UserService> logger,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IPasswordHasher<User> passwordHasher,
            IJwtTokenService jwtTokenService,
            IEmailService emailService,
            IOptions<UserSettings> userSettings,
            DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _emailService = emailService;
            _userSettings = userSettings.Value;
            _dbContext = databaseContext;
        }
        public async Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel createUserModel)
        {
            var validator = new CreateUserModelValidator(_dbContext);
            var validationResult = await validator.ValidateAsync(createUserModel);
            if (!validationResult.IsValid)
            {
                return ApiResult<CreateUserResponseModel>
                        .Failure(validationResult.Errors
                        .Select(a => a.ErrorMessage));
            }

            if (_dbContext == null)
            {
                throw new Exception("DatabaseContext is not injected into UserService");
            }

            var user = _mapper.Map<User>(createUserModel);
            user.UserName=createUserModel.Email;
            

            var result = await _userManager.CreateAsync(user, createUserModel.Password);

            if (!result.Succeeded)
            {
                return ApiResult<CreateUserResponseModel>.Failure(result.Errors.Select(e => e.Description));
            }

        
           await _userManager.AddToRoleAsync(user,UserRole.Customer.ToString()); 


            return ApiResult<CreateUserResponseModel>.Success(new CreateUserResponseModel
            {
                Id = user.Id
            });
        }
        public async Task<ApiResult<bool>> SendOtpCode(Guid userId)
        {
            var maybeUser = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(a=>a.Id== userId);

            if(maybeUser == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            var otpcode = new OtpCode
            {
                UserId = userId,
                Code = OtpCodeHelper.GenerateOptCode(),
                Status = OtpCodeStatus.Unverified
            };
            
            _dbContext.OtpCodes.Add(otpcode);

            bool isSent = await _emailService.SendEmailAsync(maybeUser.Email, otpcode.Code);
            if (!isSent)
            {
                return ApiResult<bool>.Failure(new List<string> { "Failed to send OTP email" });
            }
            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);


        }
        public async Task<ApiResult<bool>> ResendOtpCode(Guid userId)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(a=>a.Id== userId);

            if (user == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            var lastOtp = await _dbContext.OtpCodes
                           .Where(o => o.UserId == userId)
                            .OrderByDescending(o=>o.CreatedAt)
                           .FirstOrDefaultAsync();
             
            if(lastOtp == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "No OTP found to resend" });
            }

            if (!CanResend(lastOtp.CreatedAt))
            {
                var waitiTimeSeconds = GetWaitTimeForResend(lastOtp.CreatedAt);
                return ApiResult<bool>.Failure(new List<string>
                { $"Please wait {waitiTimeSeconds} seconds before requesting a new code"});
            }
            if (!IsExpired(lastOtp.CreatedAt))
            {
                bool isSent = await _emailService.SendEmailAsync(user.Email, lastOtp.Code);
                if (!isSent)
                {
                    return ApiResult<bool>.Failure(new List<string> { "Failed to sent OTP email " });
                }
                return ApiResult<bool>.Success(true);   
             }

            var newOtpCode = new OtpCode
            {
                UserId = userId,
                Code = OtpCodeHelper.GenerateOptCode(),
                Status = OtpCodeStatus.Unverified
            };

            _dbContext.OtpCodes.Add(newOtpCode);
            bool isSentNew = await _emailService.SendEmailAsync(user.Email, newOtpCode.Code);
            if (!isSentNew)
            {
                return ApiResult<bool>.Failure(new List<string> { "Failed to send Otp" });
            }
            await _dbContext.SaveChangesAsync();
            return ApiResult<bool>.Success(true);


        }
        public async Task<ApiResult<bool>> VerifyOtpAsync(string code , Guid userId)
        {
            if (string.IsNullOrEmpty(code))
            {
                return ApiResult<bool>.Failure(new List<string> { "OTP code cannot be empty" });
            }
            var user = await _dbContext.Users
                 .FirstOrDefaultAsync(u=>u.Id== userId);
            if(user == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "User not found" });
            }

            var lastOtp = await _dbContext.OtpCodes
                .Where(otp=>otp.UserId==userId&&otp.Status==OtpCodeStatus.Unverified)
                .OrderByDescending(otp=>otp.CreatedAt)
                .FirstOrDefaultAsync(); 

            if(lastOtp == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "No active otp found" });
                
            }

            if (IsExpired(lastOtp.CreatedAt))
            {
                lastOtp.Status = OtpCodeStatus.Expired;
                await _dbContext.SaveChangesAsync();
                return ApiResult<bool>.Failure(new List<string> { "OTP has expired" });
            }

            if(lastOtp.Code != code)
            {
                return ApiResult<bool>.Failure(new List<string> { "Invalid OTP code" });
            }

            lastOtp.Status = OtpCodeStatus.Verified;
            user.EmailConfirmed= true;
            await _dbContext.SaveChangesAsync();
            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<LoginResponseModel>>LoginAsync(LoginUserModel loginModel)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(a=>a.Email==loginModel.Email);
            if (user == null)
            {
                return ApiResult<LoginResponseModel>.Failure(new List<string> { "User not found" });
            }

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
            if(!passwordCheck.Succeeded)
            {
                return ApiResult<LoginResponseModel>.Failure(new List<string> { "Invalid password" });
            }

            var accessToken = await _jwtTokenService.GenerateToken(user);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_userSettings.RefreshTokenExpirationDays);
            await _userManager.UpdateAsync(user);

            return ApiResult<LoginResponseModel>.Success(new LoginResponseModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Email = user.Email,
                Id = user.Id
            });
               
                
        }








        public bool IsExpired(DateTimeOffset createdAt) =>
       createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds) < DateTimeOffset.Now;

        private bool CanResend(DateTimeOffset createdAt) =>
            createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds - _userSettings.OtpResendTimeInSeconds) < DateTimeOffset.Now;

        private int GetWaitTimeForResend(DateTimeOffset createdAt)
        {
            var resendTime = createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds - _userSettings.OtpResendTimeInSeconds);
            var waitTime = resendTime - DateTimeOffset.Now;
            return Math.Max(0, (int)waitTime.TotalSeconds);
        }


    }

}
