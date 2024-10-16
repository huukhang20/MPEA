﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPEA.Application;
using MPEA.Application.IRepository;
using MPEA.Application.IService;
using MPEA.Application.Mapper;
using MPEA.Application.Service;
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
            // Authen
            services.AddTransient<IAuthentication, Authentication>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //
            services.AddTransient<IUserRepository, UserRepository>();

            //
            services.AddScoped<IUserService, UserService>();



            services.AddAutoMapper(typeof(MapperConfig).Assembly);
            return services;
        }
    }
}