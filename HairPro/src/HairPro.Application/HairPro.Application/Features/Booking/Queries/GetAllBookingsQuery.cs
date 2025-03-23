using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Booking.Queries
{

    public class GetAllBookingsQuery : IRequest<List<HairPros.Core.Entities.Booking>> { }

}
