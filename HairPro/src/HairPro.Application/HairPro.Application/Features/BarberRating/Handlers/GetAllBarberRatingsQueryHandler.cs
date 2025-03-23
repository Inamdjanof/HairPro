using AutoMapper;
using HairPro.Application.Features.BarberRating.Queries;
using HairPro.DataAccess.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberRating.Handlers
{
    public class GetAllBarberRatingsQueryHandler : IRequestHandler<GetAllBarberRatingsQuery, List<BarberRatingResponseModel>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllBarberRatingsQueryHandler(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BarberRatingResponseModel>> Handle(GetAllBarberRatingsQuery request, CancellationToken cancellationToken)
        {
            var barberRatings = await _context.BarberRating.ToListAsync(cancellationToken);
            return _mapper.Map<List<BarberRatingResponseModel>>(barberRatings);
        }
    }
}
