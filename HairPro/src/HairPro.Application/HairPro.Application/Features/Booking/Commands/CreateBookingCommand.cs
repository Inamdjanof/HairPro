using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Booking.Commands
{

    public class CreateBookingCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid BarberServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
