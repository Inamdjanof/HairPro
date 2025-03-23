using HairPro.Application.Exceptions;
using HairPro.Application.Features.BarberHours.Queries;
using HairPro.DataAccess.Persistence;
using MediatR;
using HairPros.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace HairPro.Application.Features.BarberHours.Handlers
{

    public class GetBarberHoursByIdQueryHandler : IRequestHandler<GetBarberHoursByIdQuery, BarberHoursResponseModel>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public GetBarberHoursByIdQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<BarberHoursResponseModel> Handle(GetBarberHoursByIdQuery request, CancellationToken cancellationToken)
        {
            var barberHours = await _context.BarberHours
                .Include(bh => bh.Barber)
                .FirstOrDefaultAsync(bh => bh.Id == request.Id);

            if (barberHours == null) throw new NotFoundException(nameof(BarberHours), request.Id);

            return _mapper.Map<BarberHoursResponseModel>(barberHours);
        }
    }

}
