using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.User
{
    public class CreateUserModel
    {
     
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Lastname { get; set; } = null!;

        [Required]
        public string Firstname { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;

        public string? PhoneNumber { get; set; }

       
    }

    public class CreateUserResponseModel : BaseResponseModel {}



}
