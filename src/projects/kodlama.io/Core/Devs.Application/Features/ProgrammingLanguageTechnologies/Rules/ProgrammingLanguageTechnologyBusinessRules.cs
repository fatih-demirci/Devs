using Core.CrossCuttingConcerns.Exceptions;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Rules
{
    public class ProgrammingLanguageTechnologyBusinessRules
    {
        IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageTechnologyBusinessRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageTechnologyNameCanNotBeDuplicated(string name)
        {
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(plt => plt.Name == name);
            if (programmingLanguageTechnology != null)
            {
                throw new BusinessException("Programming language technology name exists.");
            }
        }

        public async Task<ProgrammingLanguage> ProgrammingLanguageShouldExistWhenAddProgrammingLanguageTechnology(int programmingLanguageId)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == programmingLanguageId);
            if (programmingLanguage == null) throw new BusinessException("Programming language does not exists.");
            return programmingLanguage;
        }

        public async Task<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologyShouldExist(int id)
        {
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(pl => pl.Id == id);
            if (programmingLanguageTechnology == null) throw new BusinessException("Programming language technology does not exists.");
            return programmingLanguageTechnology;
        }
    }
}
