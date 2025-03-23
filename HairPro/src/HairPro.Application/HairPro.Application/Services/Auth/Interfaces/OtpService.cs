using HairPro.Application.Common.Email;
using HairPro.Core.Entities;
using HairPro.DataAccess.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Services.Auth.Interfaces
{

    public class OtpService : IOtpService
    {
        private readonly DatabaseContext _context;
        private readonly ICustomEmailSender _emailSender; // Email jo‘natish xizmati

        public OtpService(DatabaseContext context, ICustomEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task GenerateAndSendOtpAsync(Guid userId, string email)
        {
            var otpCode = new OtpCode
            {
                UserId = userId,
                Code = new Random().Next(100000, 999999).ToString(),
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            _context.OtpCodes.Add(otpCode);
            await _context.SaveChangesAsync();

            // ✅ OTP ni foydalanuvchiga jo‘natish (email yoki SMS)
            await _emailSender.SendEmailAsync(email, "Verification Code", $"Your OTP code is: {otpCode.Code}");
        }

        public async Task<bool> VerifyOtpAsync(Guid userId, string code)
        {
            var otp = await _context.OtpCodes
                .Where(o => o.UserId == userId && o.Code == code && !o.IsUsed && o.ExpiryTime > DateTime.UtcNow)
                .FirstOrDefaultAsync();

            if (otp == null) return false;

            otp.IsUsed = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }



}
