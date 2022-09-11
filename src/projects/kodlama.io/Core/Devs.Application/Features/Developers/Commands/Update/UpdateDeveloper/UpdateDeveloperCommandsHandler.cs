using AutoMapper;
using Devs.Application.Features.Developers.DTOs;
using Devs.Application.Features.Developers.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Developers.Commands.Update.UpdateDeveloper
{
    public class UpdateDeveloperCommandsHandler : IRequestHandler<UpdateDeveloperCommandRequest, UpdatedDeveloperDTO>
    {
        IDeveloperRepository _developerRepository;
        DeveloperBusinesRules _developerBusinesRuless;
        IMapper _mapper;

        public UpdateDeveloperCommandsHandler(IDeveloperRepository developerRepository, DeveloperBusinesRules developerBusinesRuless, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _developerBusinesRuless = developerBusinesRuless;
            _mapper = mapper;
        }

        public async Task<UpdatedDeveloperDTO> Handle(UpdateDeveloperCommandRequest request, CancellationToken cancellationToken)
        {
            Developer developer = await _developerBusinesRuless.DeveloperShouldExist(request.Id);

            developer.FirstName = request.FirstName;
            developer.LastName = request.LastName;
            developer.GithubURL = request.GithubURL;
            developer.Name = $"{request.FirstName} {request.LastName}";
            await _developerRepository.UpdateAsync(developer);

            UpdatedDeveloperDTO updatedDeveloperDTO = _mapper.Map<UpdatedDeveloperDTO>(developer);
            return updatedDeveloperDTO;
        }
    }
}
