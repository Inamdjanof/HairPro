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
    public class DeleteBarberServiceCommandHandler : IRequestHandler<DeleteBarberServiceCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteBarberServiceCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBarberServiceCommand request, CancellationToken cancellationToken)
        {
            var barberService = await _context.BarberServices.FindAsync(request.Id);
            if (barberService == null) throw new NotFoundException(nameof(BarberService), request.Id);

            _context.BarberServices.Remove(barberService);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
