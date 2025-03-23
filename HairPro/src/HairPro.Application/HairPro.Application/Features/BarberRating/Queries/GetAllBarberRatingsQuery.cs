using MediatR;
using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberRating.Queries
{
    public class GetAllBarberRatingsQuery : IRequest<List<BarberRatingResponseModel>> { }
}
