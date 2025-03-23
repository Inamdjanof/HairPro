using HairPro.Application.Exceptions;
using HairPro.Application.Features.Booking.Queries;
using HairPro.DataAccess.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HairPro.Application.Features.Booking.Handlers
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, HairPros.Core.Entities.Booking>
    {
        private readonly DatabaseContext _context;

        public GetBookingByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<HairPros.Core.Entities.Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings
                .Include(b => b.Order)
                .Include(b => b.BarberService)
                .FirstOrDefaultAsync(b => b.Id == request.Id);

            if (booking == null) throw new NotFoundException(nameof(Booking), request.Id);

            return booking;
        }
    }

}
