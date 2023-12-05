using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;


namespace BuberDinner.Api;

public static class DependecyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,
         BuberDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }

}