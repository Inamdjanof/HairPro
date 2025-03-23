using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberRating.Commands;
using HairPro.DataAccess.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberRating.Handlers
{
    public class DeleteBarberRatingCommandHandler : IRequestHandler<DeleteBarberRatingCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteBarberRatingCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBarberRatingCommand request, CancellationToken cancellationToken)
        {
            var barberRating = await _context.BarberRating.FindAsync(request.Id);
            if (barberRating == null) throw new NotFoundException(nameof(BarberRating), request.Id);

            _context.BarberRating.Remove(barberRating);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
