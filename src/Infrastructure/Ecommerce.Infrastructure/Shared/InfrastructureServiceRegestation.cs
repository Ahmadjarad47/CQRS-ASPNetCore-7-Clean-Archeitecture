using Ecommerce.Application.Persistance.Email;
using Ecommerce.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Shared
{
    public static class InfrastructureServiceRegestation
    {
        public static void ConfigureInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<EmailSender>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
