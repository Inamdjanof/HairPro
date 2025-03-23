using HairPro.Application.Features.Orders.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using HairPros.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CreateOrderCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                BarberId = request.BarberId,
                TotalAmount = request.TotalAmount,
                Status = request.Status ?? OrderStatus.Pending,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "System" // Keyinchalik UserContext orqali olish mumkin
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
