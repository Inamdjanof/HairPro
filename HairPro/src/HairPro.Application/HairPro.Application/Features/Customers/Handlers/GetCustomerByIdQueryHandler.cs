using HairPro.Application.Exceptions;
using HairPro.Application.Features.Customers.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Customers.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly DatabaseContext _context;

        public GetCustomerByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customer
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (customer == null) throw new NotFoundException(nameof(Customer), request.Id);

            return customer;
        }
    }
}
