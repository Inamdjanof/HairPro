using HairPro.Application.Features.Services.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Services.Handlers
{

    public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, List<Service>>
    {
        private readonly DatabaseContext _context;

        public GetAllServicesHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services.ToListAsync(cancellationToken);
        }
    }

}
