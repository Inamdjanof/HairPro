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
    public class GetAllBarbersQueryHandler : IRequestHandler<GetAllBarbersQuery, List<Barber>>
    {
        private readonly DatabaseContext _context;

        public GetAllBarbersQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Barber>> Handle(GetAllBarbersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Barbers
                .Include(b => b.User)
                .Include(b => b.BarberShop)
                .ToListAsync();
        }
    }

}
