using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairPro.Application.Features.Customers.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
namespace HairPro.Application.Features.Customers.Handlers
{


    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CreateCustomerCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                UserId = request.UserId,
                Name = request.Name,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "System"
            };

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }

}
