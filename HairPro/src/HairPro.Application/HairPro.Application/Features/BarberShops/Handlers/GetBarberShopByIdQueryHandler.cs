using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberShops.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberShops.Handlers
{

    public class GetBarberShopByIdQueryHandler : IRequestHandler<GetBarberShopByIdQuery, BarberShop>
    {
        private readonly DatabaseContext _context;

        public GetBarberShopByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<BarberShop> Handle(GetBarberShopByIdQuery request, CancellationToken cancellationToken)
        {
            var barberShop = await _context.BarberShop
                .Include(bs => bs.Barbers)
                .FirstOrDefaultAsync(bs => bs.Id == request.Id);

            if (barberShop == null) throw new NotFoundException(nameof(BarberShop), request.Id);

            return barberShop;
        }
    }

}
