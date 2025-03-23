using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Booking.Commands
{
    public class UpdateBookingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid BarberServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
