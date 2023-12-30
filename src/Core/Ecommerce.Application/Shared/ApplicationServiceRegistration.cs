using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared
{
    public static class ApplicationServiceRegistration
    {
        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            //Configure AutoMapper && MediatR && Fluient Validation
            services.AddAutoMapper(typeof(CategoryMappingProfile));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
