using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberRating.Commands
{
    public class DeleteBarberRatingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
