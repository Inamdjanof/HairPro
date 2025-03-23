using AutoMapper;
using HairPro.Application.Features.BarberHours.Queries;
using HairPro.DataAccess.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberHours.Handlers
{
    public class GetAllBarberHoursQueryHandler : IRequestHandler<GetAllBarberHoursQuery, List<BarberHoursResponseModel>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllBarberHoursQueryHandler(DatabaseContext context,IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BarberHoursResponseModel>> Handle(GetAllBarberHoursQuery request, CancellationToken cancellationToken)
        {
            var barberhours =  await _context.BarberHours
                .Include(bh => bh.Barber)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<BarberHoursResponseModel>>(barberhours);    
        }
    }

}
