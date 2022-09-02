using AutoMapper;
using Devs.Application.Features.DTOs;
using Devs.Application.Features.ProgrammingLanguages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Update.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommandRequest, UpdatedProgrammingLanguageDTO>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository,
            IMapper mapper,
            ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageDTO> Handle(UpdateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExist(request.Id);
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
            ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
            UpdatedProgrammingLanguageDTO updatedProgrammingLanguageDTO = _mapper.Map<UpdatedProgrammingLanguageDTO>(updatedProgrammingLanguage);
            return updatedProgrammingLanguageDTO;
        }
    }
}
