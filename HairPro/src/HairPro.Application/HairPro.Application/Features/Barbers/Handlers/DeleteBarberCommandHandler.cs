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
    public class DeleteBarberCommandHandler : IRequestHandler<DeleteBarberCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteBarberCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBarberCommand request, CancellationToken cancellationToken)
        {
            var barber = await _context.Barbers.FindAsync(request.Id);
            if (barber == null) throw new NotFoundException(nameof(Barber), request.Id);

            _context.Barbers.Remove(barber);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
