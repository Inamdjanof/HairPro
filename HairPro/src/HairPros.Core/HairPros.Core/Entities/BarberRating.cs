using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class BarberRating : BaseEntity
    {
        public  Guid BarberId { get; set; }
        public Guid CustomerId { get; set; }
        public short Rating { get; set; }
        public string? Comment { get; set; }

        public Barber Barber { get; set; }
        public Customer Customer { get; set; }



    }
}
