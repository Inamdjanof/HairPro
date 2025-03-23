using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberServices.Queries
{
    public class GetAllBarberServicesQuery : IRequest<List<BarberService>> { }
}
