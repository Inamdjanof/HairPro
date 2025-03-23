using HairPro.Application.Features.Booking.Commands;
using HairPro.DataAccess.Persistence;
using MediatR;
using System;
using HairPros.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Booking.Handlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CreateBookingCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new HairPros.Core.Entities.Booking
            {
                OrderId = request.OrderId,
                BarberServiceId = request.BarberServiceId,
                BookingTime = request.BookingTime,
                IsConfirmed = request.IsConfirmed,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "System"
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync(cancellationToken);

            return booking.Id;
        }
    }
}
