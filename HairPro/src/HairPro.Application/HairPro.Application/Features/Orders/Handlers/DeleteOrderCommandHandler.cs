using HairPro.Application.Exceptions;
using HairPro.Application.Features.Orders.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Orders.Handlers
{

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteOrderCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order == null) throw new NotFoundException(nameof(Order), request.Id);

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }


}
