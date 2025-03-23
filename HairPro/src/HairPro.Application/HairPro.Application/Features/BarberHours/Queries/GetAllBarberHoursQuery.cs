using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberHours.Queries
{
    public class GetAllBarberHoursQuery : IRequest<List<BarberHoursResponseModel>>
    {

    }
}
