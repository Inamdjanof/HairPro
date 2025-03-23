using HairPro.Application.Exceptions;
using HairPro.Application.Features.Customers.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Customers.Handlers
{

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteCustomerCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customer.FindAsync(request.Id);
            if (customer == null) throw new NotFoundException(nameof(Customer), request.Id);

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
