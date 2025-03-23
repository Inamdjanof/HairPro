using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Barbers.Commands
{
    public class DeleteBarberCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
