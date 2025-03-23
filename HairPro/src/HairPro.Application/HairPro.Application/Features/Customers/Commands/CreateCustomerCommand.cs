using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
