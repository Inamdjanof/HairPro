using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberRating.Queries;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using HairPro.DataAccess.Persistence;
using AutoMapper;

namespace HairPro.Application.Features.BarberRating.Handlers
{
    public class GetBarberRatingByIdQueryHandler : IRequestHandler<GetBarberRatingByIdQuery, BarberRatingResponseModel>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public GetBarberRatingByIdQueryHandler(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BarberRatingResponseModel> Handle(GetBarberRatingByIdQuery request, CancellationToken cancellationToken)
        {
            var barberRating = await _context.BarberRating.FindAsync(request.Id);

            if (barberRating == null) throw new NotFoundException(nameof(BarberRating), request.Id);

            return _mapper.Map<BarberRatingResponseModel>(barberRating);    
        }
    }
}
