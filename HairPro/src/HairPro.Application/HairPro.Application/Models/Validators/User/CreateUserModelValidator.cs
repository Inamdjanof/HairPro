using FluentValidation;
using HairPro.Application.Models.User;
using HairPro.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HairPro.Application.Models.Validators.User
{
    public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
    {
        public readonly DatabaseContext _dbContext;

        public CreateUserModelValidator(DatabaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(u => u.Email)

                .MustAsync(EmailIsUniqueAsync)
                .WithMessage("Email address is already in use");

            RuleFor(u => u.Lastname)
            .Must(l => !string.IsNullOrWhiteSpace(l));

            RuleFor(u => u.Firstname)
           .Must(l => !string.IsNullOrWhiteSpace(l));


        }


        private async Task<bool> EmailIsUniqueAsync(string email, CancellationToken cancellationToken)
        {
            return !await _dbContext.Users.AnyAsync(x => x.Email == email, cancellationToken);
        }


        private bool PhoneNumberIsUnique(string phoneNumber)
        {
            bool phoneNumberExist = _dbContext.Users.Any(u => u.Email == phoneNumber);
            return !phoneNumberExist;
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            var phoneNumberRegex = new Regex(@"^998\d{9}$", RegexOptions.Compiled);

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }

            return phoneNumberRegex.IsMatch(phoneNumber);
        }



    }
}
