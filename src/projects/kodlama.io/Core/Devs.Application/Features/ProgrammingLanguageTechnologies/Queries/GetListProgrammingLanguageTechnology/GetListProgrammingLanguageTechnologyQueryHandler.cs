using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQueryRequest, ProgrammingLanguageTechnologyListModel>
    {
        IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        IMapper _mapper;

        public GetListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologies = await _programmingLanguageTechnologyRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include: plt => plt.Include(c => c.ProgrammingLanguage)
                );
            ProgrammingLanguageTechnologyListModel programmingLanguageTechnologyListModel = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);
            return programmingLanguageTechnologyListModel;
        }
    }
}
