using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberRating.Commands
{
    public class UpdateBarberRatingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public short Rating { get; set; }
        public string? Comment { get; set; }
    }

}
