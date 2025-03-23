using AutoMapper;
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
    public class GetAllBarberShopsQueryHandler : IRequestHandler<GetAllBarberShopsQuery, List<BarberShopResponseModel>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public GetAllBarberShopsQueryHandler(DatabaseContext context, IMapper mapper ) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BarberShopResponseModel>> Handle(GetAllBarberShopsQuery request, CancellationToken cancellationToken)
        {
            var barberShops = await _context.BarberShop.ToListAsync(cancellationToken);
            return _mapper.Map<List<BarberShopResponseModel>>(barberShops);
        }
    }
}
