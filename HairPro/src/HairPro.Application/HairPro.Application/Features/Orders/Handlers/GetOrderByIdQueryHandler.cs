using HairPro.Application.Exceptions;
using HairPro.Application.Features.Orders.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Orders.Handlers
{

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly DatabaseContext _context;

        public GetOrderByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Barber)
                .FirstOrDefaultAsync(o => o.Id == request.Id);

            if (order == null) throw new NotFoundException(nameof(Order), request.Id);

            return order;
        }
    }

}
