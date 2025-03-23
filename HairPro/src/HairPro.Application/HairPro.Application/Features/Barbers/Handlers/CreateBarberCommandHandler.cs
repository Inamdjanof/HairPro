using AutoMapper;
using HairPro.Application.Exceptions;
using HairPro.Application.Features.Barbers.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Barbers.Handlers
{
    public class CreateBarberCommandHandler : IRequestHandler<CreateBarberCommand, Guid>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;


        public CreateBarberCommandHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBarberCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null) throw new NotFoundException(nameof(User), request.UserId);

            var barberShop = await _context.BarberShop.FindAsync(request.BarberShopId);
            if (barberShop == null) throw new NotFoundException(nameof(BarberShop), request.BarberShopId);

            var barber = _mapper.Map<Barber>(request);
            barber.Id = Guid.NewGuid();
            barber.CreatedOn = DateTime.UtcNow;
            barber.CreatedBy = "System";

            _context.Barbers.Add(barber);
            await _context.SaveChangesAsync(cancellationToken);

            return barber.Id;
        }
    }
}
