using DotNetCoreLabs.LabMS.Application.Interfaces;
using DotNetCoreLabs.LabMS.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNetCoreLabs.LabMS.Data;

namespace DotNetCoreLabs.LabMS.IoC
{
    public class AppInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<IListService, ListService>();

            services.Configure<DbOptions>(opts =>
            {
                opts.ConnectionString = configuration["Data:ConnectionString"];
            });
        }
    }
}
