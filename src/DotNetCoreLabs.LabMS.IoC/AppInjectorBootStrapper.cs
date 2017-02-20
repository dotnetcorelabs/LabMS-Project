using DotNetCoreLabs.LabMS.Application.Interfaces;
using DotNetCoreLabs.LabMS.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNetCoreLabs.LabMS.Data;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Service;
using DotNetCoreLabs.LabMS.Domain.Services;
using AutoMapper;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Repository;
using DotNetCoreLabs.LabMS.Data.Repository;
using DotNetCoreLabs.LabMS.Data.Interfaces;
using DotNetCoreLabs.LabMS.Context.Interfaces;
using DotNetCoreLabs.LabMS.Context;
using DotNetCoreLabs.LabMS.Context.DbProviders;

namespace DotNetCoreLabs.LabMS.IoC
{
    public class AppInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IListAppService, ListAppService>();

            //domain
            services.AddScoped<IListDefinitionService, ListDefinitionService>();

            //data
            services.AddScoped<DbOptions>(c => new DbOptions
            {
                ConnectionString = @"Data Source=C:\temp\dbb\mydb1.db",
                DatabaseProvider = DatabaseProviderString.SQLiteProvider
            });
            // Infra - Data
            services.AddScoped<IListDefinitionRepository, ListDefinitionRepository>();
            services.AddScoped<IDataContext, DapperContext>();
            services.AddScoped<IDatabaseProvider, ContextDatabaseProvider>();

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<EquinoxContext>();
        }
    }
}
