using AutoMapper;
using Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommandRequest, CreatedProgrammingLanguageTechnologyDTO>
    {
        IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        IMapper _mapper;
        ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public CreateProgrammingLanguageTechnologyCommandHandler
            (
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository,
            IMapper mapper,
            ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules
            )
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageTechnologyDTO> Handle(CreateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyNameCanNotBeDuplicated(request.Name);
            ProgrammingLanguage programmingLanguage = await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageShouldExistWhenAddProgrammingLanguageTechnology(request.ProgrammingLanguageId);

            ProgrammingLanguageTechnology programmingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
            ProgrammingLanguageTechnology createdProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.AddAsync(programmingLanguageTechnology);
            createdProgrammingLanguageTechnology.ProgrammingLanguage = programmingLanguage;
            CreatedProgrammingLanguageTechnologyDTO createdProgrammingLanguageTechnologyDTO = _mapper.Map<CreatedProgrammingLanguageTechnologyDTO>(createdProgrammingLanguageTechnology);
            return createdProgrammingLanguageTechnologyDTO;
        }
    }
}
