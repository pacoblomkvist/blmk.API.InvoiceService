using InvoiceService.Application.Common.Interfaces;
using InvoiceService.Infrastructure.Files;
using InvoiceService.Infrastructure.Identity;
using InvoiceService.Infrastructure.Persistence;
using InvoiceService.Infrastructure.Persistence.Settings;
using InvoiceService.Infrastructure.Repositories;
using InvoiceService.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InvoiceService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseInMemoryDatabase("InvoiceServiceDb"));
            //}
            //else
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            configuration.GetConnectionString("DefaultConnection"),
            //            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //}



            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            var a= configuration.GetSection("Logging");
            services.Configure<InvoiceDbSettings>(configuration.GetSection(nameof(InvoiceDbSettings)));
            services.AddSingleton<IInvoiceDbSettings>(sp => sp.GetRequiredService<IOptions<InvoiceDbSettings>>().Value);
            //services.AddScoped<MongoDbContext>();
            //services.AddScoped<IMongoContext>(provider => provider.GetRequiredService<MongoDbContext>());
            services.AddScoped<IMongoContext, MongoDbContext>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
           
            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            return services;
        }
    }
}