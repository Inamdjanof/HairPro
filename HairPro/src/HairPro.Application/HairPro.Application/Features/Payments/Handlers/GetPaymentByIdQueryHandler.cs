using HairPro.Application.Exceptions;
using HairPro.Application.Features.Payments.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Payments.Handlers
{

    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Payment>
    {
        private readonly DatabaseContext _context;

        public GetPaymentByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Payment> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _context.Payments
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (payment == null) throw new NotFoundException(nameof(Payment), request.Id);

            return payment;
        }
    }



}

