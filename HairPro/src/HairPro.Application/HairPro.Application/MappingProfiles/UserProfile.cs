using AutoMapper;
using HairPro.Application.Models.User;
using HairPros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.MappingProfiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<CreateUserModel, User>()
         .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Firstname))
         .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Lastname));

        }

    }
}
