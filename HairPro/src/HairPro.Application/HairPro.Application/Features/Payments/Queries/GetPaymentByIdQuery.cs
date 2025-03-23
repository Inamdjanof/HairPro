using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Payments.Queries
{
    public class GetPaymentByIdQuery : IRequest<Payment>
    {
        public Guid Id { get; set; }
    }

}
