using HairPros.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Orders.Commands
{

    public class UpdateOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public int TotalAmount { get; set; }
        public OrderStatus? Status { get; set; }
    }

}
