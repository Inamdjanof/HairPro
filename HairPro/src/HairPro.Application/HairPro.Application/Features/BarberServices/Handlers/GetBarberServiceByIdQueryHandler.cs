using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberServices.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberServices.Handlers
{
    public class GetBarberServiceByIdQueryHandler : IRequestHandler<GetBarberServiceByIdQuery, BarberService>
    {
        private readonly DatabaseContext _context;

        public GetBarberServiceByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<BarberService> Handle(GetBarberServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var barberService = await _context.BarberServices
                .Include(bs => bs.Barber)
                .Include(bs => bs.Service)
                .FirstOrDefaultAsync(bs => bs.Id == request.Id);

            if (barberService == null) throw new NotFoundException(nameof(BarberService), request.Id);

            return barberService;
        }
    }

}
