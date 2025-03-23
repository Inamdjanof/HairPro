using HairPro.Application.Features.Payments.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Payments.Handlers
{
    public class GetPaymentsByOrderIdQueryHandler : IRequestHandler<GetPaymentsByOrderIdQuery, List<Payment>>
    {
        private readonly DatabaseContext _context;

        public GetPaymentsByOrderIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> Handle(GetPaymentsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Payments
                .Where(p => p.OrderId == request.OrderId)
                .OrderByDescending(p => p.CreatedOn)
                .ToListAsync();
        }
    }
}
