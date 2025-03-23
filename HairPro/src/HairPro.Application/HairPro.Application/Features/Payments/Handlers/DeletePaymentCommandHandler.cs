using HairPro.Application.Exceptions;
using HairPro.Application.Features.Payments.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Payments.Handlers
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeletePaymentCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _context.Payments.FindAsync(request.Id);
            if (payment == null) throw new NotFoundException(nameof(Payment), request.Id);

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
