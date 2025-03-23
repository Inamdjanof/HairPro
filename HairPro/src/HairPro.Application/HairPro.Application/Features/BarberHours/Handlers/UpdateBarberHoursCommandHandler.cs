using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberHours.Commands;
using HairPro.DataAccess.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberHours.Handlers
{
    public class UpdateBarberHoursCommandHandler : IRequestHandler<UpdateBarberHoursCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UpdateBarberHoursCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateBarberHoursCommand request, CancellationToken cancellationToken)
        {
            var barberHours = await _context.BarberHours.FindAsync(request.Id);
            if (barberHours == null) throw new NotFoundException(nameof(BarberHours), request.Id);

            barberHours.OpenTime = request.OpenTime;
            barberHours.CloseTime = request.CloseTime;
            barberHours.UpdatedOn = DateTime.UtcNow;
            barberHours.UpdatedBy = "System";

            _context.BarberHours.Update(barberHours);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
