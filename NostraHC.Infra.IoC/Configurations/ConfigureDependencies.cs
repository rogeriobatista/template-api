using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NostraHC.Domain.Companies.Interfaces;
using NostraHC.Domain.Companies.Services;
using NostraHC.Infra.Data.Contexts;
using NostraHC.Infra.Data.Repositories;
using NostraHC.Infra.Data.UnityOfWork;

namespace NostraHC.Infra.IoC.Configurations
{
    public static class ConfigureDependencies
    {
        public static void AddContextDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NostraHCContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("NostraHC.Infra.Data")));
        }

        public static void AddApplicationDependecies(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnitOfWork>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
