using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Models.Boking
{
    public class BookingCreateModel
    {
        public Guid OrderId { get; set; }
        public Guid BarberServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
        public bool IsConfirmed { get; set; }
    }

}
