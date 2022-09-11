using Core.CrossCuttingConcerns.Exceptions;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Developers.Rules
{
    public class DeveloperBusinesRules
    {
        IDeveloperRepository _developerRepository;

        public DeveloperBusinesRules(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<Developer> DeveloperShouldExist(int id)
        {
            Developer? developer = await _developerRepository.GetAsync(d => d.Id == id);
            if (developer == null) throw new BusinessException("Developer does not exists.");
            return developer;
        }
    }
}
