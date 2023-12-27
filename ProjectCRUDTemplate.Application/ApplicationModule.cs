using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUDTemplate.Application;

public static class ApplicationModule
{
    public static IServiceCollection LoadApplicationDependencies(this IServiceCollection service)
    {
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return service;
    }
}
