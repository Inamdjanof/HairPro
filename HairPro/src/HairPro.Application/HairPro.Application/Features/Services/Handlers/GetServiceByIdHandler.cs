using HairPro.Application.Features.Services.Queries;
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
    public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, Service?>
    {
        private readonly DatabaseContext _context;

        public GetServiceByIdHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Service?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services.FindAsync(request.Id);
        }
    }

}
