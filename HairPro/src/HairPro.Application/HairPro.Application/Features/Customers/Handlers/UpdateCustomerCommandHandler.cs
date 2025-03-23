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
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UpdateCustomerCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customer.FindAsync(request.Id);
            if (customer == null) throw new NotFoundException(nameof(Customer), request.Id);

            customer.UserId = request.UserId;
            customer.Name = request.Name;
            customer.UpdatedOn = DateTime.UtcNow;
            customer.UpdatedBy = "System";

            _context.Customer.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
