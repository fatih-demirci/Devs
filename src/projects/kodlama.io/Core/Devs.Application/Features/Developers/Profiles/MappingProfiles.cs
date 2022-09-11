using AutoMapper;
using Devs.Application.Features.Developers.DTOs;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Developers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Developer, UpdatedDeveloperDTO>().ReverseMap();
        }
    }
}
