using AutoMapper;
using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberServices.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberServices.Handlers
{
    public class CreateBarberServiceCommandHandler : IRequestHandler<CreateBarberServiceCommand, Guid>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public CreateBarberServiceCommandHandler(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBarberServiceCommand request, CancellationToken cancellationToken)
        {
            var barber = await _context.Barbers.FindAsync(request.BarberId);
            if (barber == null) throw new NotFoundException(nameof(Barber), request.BarberId);

            var service = await _context.Services.FindAsync(request.ServiceId);
            if (service == null) throw new NotFoundException(nameof(Service), request.ServiceId);

            var barberService = new BarberService
            {
                BarberId = request.BarberId,
                ServiceId = request.ServiceId,
                Price = request.Price,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "System"
            };

            _context.BarberServices.Add(barberService);
            await _context.SaveChangesAsync(cancellationToken);

            return barberService.Id;
        }
    }
}
