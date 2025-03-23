using AutoMapper;
using HairPro.Application.Features.BarberHours.Commands;
using HairPro.Application.Features.BarberHours;
using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.MappingProfiles
{
    public class BarberHoursProfile : Profile
    {
        public BarberHoursProfile()
        {
            CreateMap<CreateBarberHoursCommand, BarberHours>();
            CreateMap<BarberHours, BarberHoursResponseModel>();
        }
    }

}
