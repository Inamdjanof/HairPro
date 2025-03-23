using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Barbers.Queries
{

    public class GetBarberByIdQuery : IRequest<Barber>
    {
        public Guid Id { get; set; }
    }
}
