using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberRating.Commands;
using HairPro.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace HairPro.Application.Features.BarberRating.Handlers
{

    public class CreateBarberRatingCommandHandler : IRequestHandler<CreateBarberRatingCommand, Guid>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateBarberRatingCommandHandler(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBarberRatingCommand request, CancellationToken cancellationToken)
        {
            var barber = await _context.Barbers.FindAsync(request.BarberId);
            if (barber == null) throw new NotFoundException(nameof(Barber), request.BarberId);

            var customer = await _context.Customer.FindAsync(request.CustomerId);
            if (customer == null) throw new NotFoundException(nameof(Customer), request.CustomerId);

            var barberRating = _mapper.Map<HairPros.Core.Entities.BarberRating>(request);
            barberRating.CreatedOn = DateTime.UtcNow;
            barberRating.CreatedBy = "System";


            _context.BarberRating.Add(barberRating);
            await _context.SaveChangesAsync(cancellationToken);

            return barberRating.Id;
        }
    }




}
