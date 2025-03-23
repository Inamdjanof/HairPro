using AutoMapper;
using HairPro.Application.Features.BarberRating.Commands;
using HairPro.Application.Features.BarberRating;
using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.MappingProfiles
{
    public class BarberRatingProfile : Profile
    {

        public BarberRatingProfile()
        {
            CreateMap<BarberRating, BarberRatingResponseModel>();
            CreateMap<CreateBarberRatingCommand, BarberRating>();

        }


    }
}
