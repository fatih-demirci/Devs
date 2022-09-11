using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguages.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQueryRequest, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.pageRequest.Page, size: request.pageRequest.PageSize);
            ProgrammingLanguageListModel programmingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);
            return programmingLanguageListModel;
        }
    }
}
