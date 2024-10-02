using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPEA.Application.IRepository;
using MPEA.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) 
        {
            //
            services.AddTransient<IUserRepository, UserRepository>();

            //

            return services;
        }
}
