using HairPro.Application.Features.Orders.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Orders.Handlers
{
    public class GetAllOrdersByCustomerIdQueryHandler : IRequestHandler<GetAllOrdersByCustomerIdQuery, List<Order>>
    {
        private readonly DatabaseContext _context;

        public GetAllOrdersByCustomerIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Handle(GetAllOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == request.CustomerId)
                .OrderByDescending(o => o.CreatedOn)
                .ToListAsync();
        }
    }

}
