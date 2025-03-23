using HairPros.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Payments.Commands
{
    public class UpdatePaymentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
