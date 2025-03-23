using MediatR;
using HairPros.Core.Entities;
namespace HairPro.Application.Features.Booking.Queries
{
    public class GetBookingByIdQuery : IRequest<HairPros.Core.Entities.Booking>
    {
        public Guid Id { get; set; }
    }
}
    