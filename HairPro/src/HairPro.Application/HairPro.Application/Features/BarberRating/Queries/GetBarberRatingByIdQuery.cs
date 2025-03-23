using MediatR;
using System;
using HairPros.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberRating.Queries
{
    public class GetBarberRatingByIdQuery : IRequest<BarberRatingResponseModel>
    {
        public Guid Id { get; set; }
    }
}
