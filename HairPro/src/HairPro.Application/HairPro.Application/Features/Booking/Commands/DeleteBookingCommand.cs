using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Booking.Commands
{
    public class DeleteBookingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

}
