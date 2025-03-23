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

    public class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, bool>
    {
        private readonly IOtpService _otpService;
        private readonly UserManager<User> _userManager;

        public VerifyOtpCommandHandler(IOtpService otpService, UserManager<User> userManager)
        {
            _otpService = otpService;
            _userManager = userManager;
        }

        public async Task<bool> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            var isValid = await _otpService.VerifyOtpAsync(request.UserId, request.Code);
            if (!isValid) return false;

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) throw new Exception("User not found");

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return true;
        }
    }



}
