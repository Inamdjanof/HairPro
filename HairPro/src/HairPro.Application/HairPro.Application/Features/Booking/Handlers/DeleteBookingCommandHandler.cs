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
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteBookingCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings.FindAsync(request.Id);
            if (booking == null) throw new NotFoundException(nameof(Booking), request.Id);

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
