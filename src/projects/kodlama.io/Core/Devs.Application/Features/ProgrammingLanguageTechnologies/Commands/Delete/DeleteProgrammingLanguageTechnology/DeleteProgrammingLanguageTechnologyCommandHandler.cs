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

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Delete.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommandRequest, DeleteProgrammingLanguageTechnologyCommandResponse>
    {
        IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        IMapper _mapper;
        ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<DeleteProgrammingLanguageTechnologyCommandResponse> Handle(DeleteProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTechnology programmingLanguageTechnology = await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyShouldExist(request.Id);
            await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology);
            return new DeleteProgrammingLanguageTechnologyCommandResponse() { };
        }
    }
}
