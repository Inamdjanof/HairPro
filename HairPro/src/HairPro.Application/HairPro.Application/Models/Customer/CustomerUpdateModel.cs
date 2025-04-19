using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.Customer
{
    public class CustomerUpdateModel
    {
        public Guid Id { get; set; } // ID maydoni yangilash uchun kerak
        public Guid UserId { get; set; }
    }
}
