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

    public class UpdateBarberServiceCommandHandler : IRequestHandler<UpdateBarberServiceCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UpdateBarberServiceCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateBarberServiceCommand request, CancellationToken cancellationToken)
        {
            var barberService = await _context.BarberServices.FindAsync(request.Id);
            if (barberService == null) throw new NotFoundException(nameof(BarberService), request.Id);

            barberService.Price = request.Price;
            barberService.UpdatedOn = DateTime.UtcNow;
            barberService.UpdatedBy = "System";

            _context.BarberServices.Update(barberService);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
