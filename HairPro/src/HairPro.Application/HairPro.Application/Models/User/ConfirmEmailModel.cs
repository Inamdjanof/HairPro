using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.User
{
    public class ConfirmEmailModel
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public string Token { get; set; } = null!;
    }

    public class ConfirmEmailResponseModel
    {
        public bool Confirmed { get; set; }
    }
}
