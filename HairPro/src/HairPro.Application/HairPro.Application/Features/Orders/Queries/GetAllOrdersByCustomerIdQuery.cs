using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Orders.Queries
{
    public class GetAllOrdersByCustomerIdQuery : IRequest<List<Order>>
    {
        public Guid CustomerId { get; set; }
    }
}
