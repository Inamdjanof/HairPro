using AutoMapper;
using HairPro.Application.Features.BarberShops.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberShops.Handlers
{
    public class CreateBarberShopCommandHandler : IRequestHandler<CreateBarberShopCommand, Guid>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;


        public CreateBarberShopCommandHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBarberShopCommand request, CancellationToken cancellationToken)
        {

            var barberShop = _mapper.Map<BarberShop>(request);

            _context.BarberShop.Add(barberShop);
            await _context.SaveChangesAsync(cancellationToken);

            return barberShop.Id;
        }
    }
}
