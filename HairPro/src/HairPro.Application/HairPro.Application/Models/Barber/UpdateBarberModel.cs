using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.Barber
{
    public class UpdateBarberModel
    {
        public Guid Id { get; set; }            
        public Guid UserId { get; set; }      
        public Guid BarberShopId { get; set; }


    }
}
