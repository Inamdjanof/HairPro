using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class Booking : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid BarberServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
        public bool IsConfirmed { get; set; }

        public Order Order { get; set; }
        public BarberService BarberService { get; set; }

     
    }

}
