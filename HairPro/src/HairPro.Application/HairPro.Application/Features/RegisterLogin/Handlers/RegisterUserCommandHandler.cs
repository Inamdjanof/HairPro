using HairPro.Application.Features.RegisterLogin.Commands;
using HairPro.Application.Services.Auth.Interfaces;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.RegisterLogin.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOtpService _otpService;

        public RegisterUserCommandHandler(UserManager<User> userManager, IOtpService otpService)
        {
            _userManager = userManager;
            _otpService = otpService;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserName = request.UserName
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", " , result.Errors.Select(e=>e.Description));    
                    throw new Exception($"User registration failed {errors} ");
                }

                // ✅ OTP kod generatsiya qilinadi va yuboriladi
                await _otpService.GenerateAndSendOtpAsync(user.Id, user.Email);

                return user.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xato {ex.Message}");
                throw;
            }

        }

    }
}


