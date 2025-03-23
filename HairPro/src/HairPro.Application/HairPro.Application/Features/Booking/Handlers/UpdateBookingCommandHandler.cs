using HairPro.Application.Exceptions;
using HairPro.Application.Features.Booking.Commands;
using HairPro.DataAccess.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Booking.Handlers
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UpdateBookingCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings.FindAsync(request.Id);
            if (booking == null) throw new NotFoundException(nameof(Booking), request.Id);

            booking.OrderId = request.OrderId;
            booking.BarberServiceId = request.BarberServiceId;
            booking.BookingTime = request.BookingTime;
            booking.IsConfirmed = request.IsConfirmed;
            booking.UpdatedOn = DateTime.UtcNow;
            booking.UpdatedBy = "System";

            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
