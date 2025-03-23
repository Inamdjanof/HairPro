using AutoMapper;
using HairPro.Application.Features.Barbers.Commands;
using HairPro.Application.Features.Barbers;
using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.MappingProfiles
{
    public class BarberProfile : Profile
    {
        public BarberProfile()
        {
            CreateMap<CreateBarberCommand, Barber>();
            CreateMap<UpdateBarberCommand, Barber>();
            CreateMap<Barber, BarberResponseModel>();
        }
    }
}
