using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberServices.Commands
{

    public class CreateBarberServiceCommand : IRequest<Guid>
    {
        public Guid BarberId { get; set; }
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }
    }

}
