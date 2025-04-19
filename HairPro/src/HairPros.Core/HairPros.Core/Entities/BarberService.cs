using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class BarberService : BaseEntity
    {
        public Guid BarberId { get; set; }
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }

        public Barber Barber { get; set; }
        public AllService Service { get; set; }

      
    }
}
