namespace API.Startup.Extensions
{
    using API.Athentication;
    using API.Comparers;
    using API.Interfaces.Services;
    using API.Services;
    using DataAccess.Entities;

    internal static class Service
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Helpers
            services.AddScoped<AuthenticationHelper>();
            services.AddScoped<IHelperService, HelperService>();

            //Controller
            services.AddScoped<IConfigService, ConfigService>();

            //Entities
            services.AddScoped<IConstantService<APIConstant>, APIConstantService>();
            services.AddScoped<IConstantService<InfrastructureVariable>, InfrastructureVariablesService>();
            services.AddScoped<IInfrastructureService, InfrastructureService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();

            //CRUD
            services.AddScoped<ICRUDService<Client>, ClientService>();
            //services.AddScoped<ICRUDService<State>, StateService>();
            services.AddScoped<ICRUDService<Infrastructure>, InfrastructureService>();
            services.AddScoped<ICRUDService<Configuration>, ConfigurationService>();
            services.AddScoped<ICRUDService<Instance>, InstanceService>();
            services.AddScoped<ICRUDService<Product>, ProductService>();
            services.AddScoped<ICRUDService<TypeInfrastructure>, TypeInfrastructureService>();
            services.AddScoped<ICRUDService<TypeInstance>, TypeInstanceService>();

            return services;
        }

        internal static IServiceCollection AddComparers(this IServiceCollection services)
        {
            services.AddScoped<IEqualityComparer<Client>, ClientComparer>();
            services.AddScoped<IEqualityComparer<Configuration>, ConfigurationComparer>();
            services.AddScoped<IEqualityComparer<Infrastructure>, InfrastructureComparer>();
            services.AddScoped<IEqualityComparer<Instance>, InstanceComparer>();
            services.AddScoped<IEqualityComparer<Product>, ProductComparer>();

            return services;
        }
    }
}
