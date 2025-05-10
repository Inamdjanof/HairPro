using HairPros.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HairPro.Application.Services.Impl
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<User> _userManager;  
        private readonly string _businessMail;  
        private readonly string _smtpPassword; 

        public EmailService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;

            _businessMail = configuration["SmtpSettings:BusinessMail"];
            _smtpPassword = configuration["SmtpSettings:SmtpPassword"];
        }

        public async Task<bool> SendEmailAsync(string email, string otp)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return false; // Agar foydalanuvchi topilmasa
                }

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_businessMail, _smtpPassword)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_businessMail),
                    Subject = "Verification Code",
                    Body = $"Dear {user.UserName}," +
                           "\nYou are using this email address to register on our website." +
                           $"\n\nYour verification code is {otp}." +
                           "\nPlease use it to complete your registration before it expires." +
                           "\n\nIf you didn't request this, please ignore this email." +
                           "\n\nThank you!",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                // Exception loglashni qo‘shish yaxshi bo‘ladi
                return false;
            }
        }
    }
}
