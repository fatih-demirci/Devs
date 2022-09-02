using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            ProgrammingLanguage? result = await _programmingLanguageRepository.GetAsync(b => b.Name == name);
            if (result != null)
            {
                throw new BusinessException("Programming language name exists.");
            }
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested Programming language does not exist.");
        }

        public async Task ProgrammingLanguageShouldExist(int id)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == id);
            if (programmingLanguage == null) throw new BusinessException("Programming language does not exist.");
        }
    }
}
