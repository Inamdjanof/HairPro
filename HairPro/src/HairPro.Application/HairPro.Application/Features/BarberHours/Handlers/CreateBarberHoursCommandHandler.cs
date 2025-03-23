using AutoMapper;
using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberHours.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberHours.Handlers
{
    public class CreateBarberHoursCommandHandler : IRequestHandler<CreateBarberHoursCommand, Guid>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;


        public CreateBarberHoursCommandHandler(DatabaseContext context,IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBarberHoursCommand request, CancellationToken cancellationToken)
        {
            var barber = await _context.Barbers.FindAsync(request.BarberId);
            if (barber == null) throw new NotFoundException(nameof(Barber), request.BarberId);

            var barberHours = _mapper.Map<HairPros.Core.Entities.BarberHours>(request);
            barberHours.CreatedOn = DateTime.Now;
            barberHours.CreatedBy = "System";

            _context.BarberHours.Add(barberHours);
            await _context.SaveChangesAsync(cancellationToken);

            return barberHours.Id;
        }

    }
    }
