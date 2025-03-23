using HairPro.Application.Exceptions;
using HairPro.Application.Features.Barbers.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Barbers.Handlers
{
    public class GetBarberByIdQueryHandler : IRequestHandler<GetBarberByIdQuery, Barber>
    {
        private readonly DatabaseContext   _context;

        public GetBarberByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Barber> Handle(GetBarberByIdQuery request, CancellationToken cancellationToken)
        {
            var barber = await _context.Barbers
                .Include(b => b.User)
                .Include(b => b.BarberShop)
                .FirstOrDefaultAsync(b => b.Id == request.Id);

            if (barber == null) throw new NotFoundException(nameof(Barber), request.Id);

            return barber;
        }
    }
}
