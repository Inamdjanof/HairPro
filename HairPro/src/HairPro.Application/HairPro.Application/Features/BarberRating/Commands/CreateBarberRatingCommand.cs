using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberRating.Commands
{
    public class CreateBarberRatingCommand: IRequest<Guid>
    {
        public Guid BarberId { get; set; }
        public Guid CustomerId { get; set; }
        public short Rating { get; set; }
        public string? Comment { get; set; }

    }
}
