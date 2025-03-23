using HairPro.Application.Features.Booking.Queries;
using HairPro.DataAccess.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Booking.Handlers
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<HairPros.Core.Entities.Booking>>
    {
        private readonly DatabaseContext _context;

        public GetAllBookingsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<HairPros.Core.Entities.Booking>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Bookings
                .Include(b => b.Order)
                .Include(b => b.BarberService)
                .ToListAsync();
        }
    }
}
