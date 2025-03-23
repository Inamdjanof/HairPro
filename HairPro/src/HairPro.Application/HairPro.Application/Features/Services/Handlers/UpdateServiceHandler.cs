using HairPro.Application.Features.Services.Commands;
using HairPro.DataAccess.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Services.Handlers
{

    public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UpdateServiceHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FindAsync(request.Id);
            if (service == null) return false;

            service.Name = request.Name;
            service.UpdatedBy = "System";
            service.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
