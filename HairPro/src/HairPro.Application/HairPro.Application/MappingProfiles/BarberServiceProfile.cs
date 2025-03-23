using HairPro.Application.Features.BarberServices.Commands;
using HairPro.Application.Features.BarberServices;
using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HairPro.Application.MappingProfiles
{
    public class BarberServiceProfile : Profile
    {
        public BarberServiceProfile()
        {
            CreateMap<BarberService, BarberServiceResponseModel>()
                .ForMember(dest => dest.BarberName, opt => opt.MapFrom(src => src.Barber.User.FirstName))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name));

            CreateMap<CreateBarberServiceCommand, BarberService>();
            CreateMap<UpdateBarberServiceCommand, BarberService>();
        }

    }
}
