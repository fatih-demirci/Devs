﻿using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Devs.Application.Features.Auth.Rules;
using Devs.Application.Features.Developers.Rules;
using Devs.Application.Features.ProgrammingLanguages.Rules;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<ProgrammingLanguageTechnologyBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<DeveloperBusinesRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            return services;
        }
    }
}
