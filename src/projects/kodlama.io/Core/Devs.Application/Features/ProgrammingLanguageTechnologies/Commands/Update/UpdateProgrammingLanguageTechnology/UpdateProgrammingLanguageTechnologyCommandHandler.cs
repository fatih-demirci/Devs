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

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Update.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommandRequest, UpdatedProgrammingLanguageTechnologyDTO>
    {
        IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        IMapper _mapper;
        ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public UpdateProgrammingLanguageTechnologyCommandHandler
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

        public async Task<UpdatedProgrammingLanguageTechnologyDTO> Handle(UpdateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyNameCanNotBeDuplicated(request.Name);
            ProgrammingLanguage programmingLanguage = await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageShouldExistWhenAddProgrammingLanguageTechnology(request.ProgrammingLanguageId);
            await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyShouldExist(request.Id);

            ProgrammingLanguageTechnology programmingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
            ProgrammingLanguageTechnology updatedProgrammingLanguageTechnologyDTO = await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnology);
            updatedProgrammingLanguageTechnologyDTO.ProgrammingLanguage = programmingLanguage;
            UpdatedProgrammingLanguageTechnologyDTO createdProgrammingLanguageTechnologyDTO = _mapper.Map<UpdatedProgrammingLanguageTechnologyDTO>(updatedProgrammingLanguageTechnologyDTO);
            return createdProgrammingLanguageTechnologyDTO;
        }
    }
}
