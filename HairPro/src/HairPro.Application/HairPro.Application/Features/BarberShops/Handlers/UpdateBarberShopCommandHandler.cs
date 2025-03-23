using AutoMapper;
using HairPro.Application.Exceptions;
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
    public class UpdateBarberShopCommandHandler : IRequestHandler<UpdateBarberShopCommand, Guid>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UpdateBarberShopCommandHandler(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Guid> Handle(UpdateBarberShopCommand request, CancellationToken cancellationToken)
        {
            var barberShop = await _context.BarberShop.FindAsync(request.Id);
            if (barberShop == null)
            {
                throw new NotFoundException(nameof(BarberShop), request.Id);
            }

            _mapper.Map(request, barberShop); // AutoMapper orqali yangilash

            await _context.SaveChangesAsync(cancellationToken);

            return barberShop.Id;
        }

    }
}
