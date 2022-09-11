using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguages.DTOs;
using Devs.Application.Features.ProgrammingLanguages.Models;
using Devs.Application.Features.ProgrammingLanguages.Commands.Create.CreateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Commands.Delete.DeleteProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Commands.Update.UpdateProgrammingLanguage;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProgrammingLanguageCommandRequest, ProgrammingLanguage>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDTO>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDTO>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDTO>().ReverseMap();
            CreateMap<UpdateProgrammingLanguageCommandRequest, ProgrammingLanguage>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDTO>().ReverseMap();
            CreateMap<DeleteProgrammingLanguageCommandRequest, ProgrammingLanguage>().ReverseMap();
        }
    }
}
