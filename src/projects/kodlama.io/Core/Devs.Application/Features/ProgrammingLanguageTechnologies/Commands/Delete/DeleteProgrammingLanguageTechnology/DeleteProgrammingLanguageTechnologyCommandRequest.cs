﻿using Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Delete.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommandRequest : IRequest<DeleteProgrammingLanguageTechnologyCommandResponse>
    {
        public int Id { get; set; }
    }
}
