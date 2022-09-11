using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguages.Models;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create.CreateProgrammingLanguageTechnology;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Update.UpdateProgrammingLanguageTechnology;
using Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyListDTO>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ForMember(c => c.ProgrammingLanguageTechnologyName, opt => opt.MapFrom(c => c.Name))
                .ReverseMap();
            CreateMap<CreateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologyDTO>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ForMember(c => c.ProgrammingLanguageTechnologyName, opt => opt.MapFrom(c => c.Name))
                .ReverseMap();
            CreateMap<UpdateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, UpdatedProgrammingLanguageTechnologyDTO>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ForMember(c => c.ProgrammingLanguageTechnologyName, opt => opt.MapFrom(c => c.Name))
                .ReverseMap();
        }
    }
}
