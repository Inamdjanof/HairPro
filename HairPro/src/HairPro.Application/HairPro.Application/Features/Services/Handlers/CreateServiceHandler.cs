using HairPro.Application.Features.Services.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Services.Handlers
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CreateServiceHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreatedBy = "System",
                CreatedOn = DateTime.UtcNow
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync(cancellationToken);
            return service.Id;
        }
    }

}
