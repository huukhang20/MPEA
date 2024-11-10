using Microsoft.Extensions.Configuration;
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

            // Category
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            // SparePart
            services.AddTransient<ISparePartRepository, SparePartRepository>();
            services.AddScoped<ISparePartService, SparePartService>();
            // Wishlist
            
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();

            //
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();

            //
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationService, NotificationService>();

            //
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddScoped<IMembershipService, MembershipService>();

            // 
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            //
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IMailService, MailService>();
            services.AddAutoMapper(typeof(MapperConfig).Assembly);
            return services;
        }
    }
}
