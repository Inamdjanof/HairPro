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
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CreatePaymentCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                OrderId = request.OrderId,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                Status = request.Status,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "System"
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(cancellationToken);

            return payment.Id;
        }
    }

}
