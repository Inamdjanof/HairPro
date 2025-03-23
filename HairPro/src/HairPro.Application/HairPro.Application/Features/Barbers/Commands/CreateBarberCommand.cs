using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Barbers.Commands
{

    public class CreateBarberCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BarberShopId { get; set; }
        public float AverageRating { get; set; }
    }

}
