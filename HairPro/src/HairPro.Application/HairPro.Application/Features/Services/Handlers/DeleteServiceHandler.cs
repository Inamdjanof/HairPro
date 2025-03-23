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

    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteServiceHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FindAsync(request.Id);
            if (service == null) return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

}
