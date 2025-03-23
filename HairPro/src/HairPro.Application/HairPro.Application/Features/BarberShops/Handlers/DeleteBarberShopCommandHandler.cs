using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberShops.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberShops.Handlers
{
    public class DeleteBarberShopCommandHandler : IRequestHandler<DeleteBarberShopCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteBarberShopCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBarberShopCommand request, CancellationToken cancellationToken)
        {
            var barberShop = await _context.BarberShop.FindAsync(request.Id);
            if (barberShop == null) throw new NotFoundException(nameof(BarberShop), request.Id);

            _context.BarberShop.Remove(barberShop);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
