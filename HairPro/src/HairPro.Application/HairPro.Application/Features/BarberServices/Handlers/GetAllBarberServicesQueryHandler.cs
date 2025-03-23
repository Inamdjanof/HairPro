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
    public class GetAllBarberServicesQueryHandler : IRequestHandler<GetAllBarberServicesQuery, List<BarberService>>
    {
        private readonly DatabaseContext _context;

        public GetAllBarberServicesQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<BarberService>> Handle(GetAllBarberServicesQuery request, CancellationToken cancellationToken)
        {
            return await _context.BarberServices
                .Include(bs => bs.Barber)
                .Include(bs => bs.Service)
                .ToListAsync();
        }
    }
}
