using ITBees.FAS.Setup;
using ITBees.Interfaces.ExternalSalesPlatformIntegration;
using ITBees.PipedriveIntegration.Interfaces;
using ITBees.PipedriveIntegration.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITBees.PipedriveIntegration
{
    public class PipedriveIntegrationSetup : IFasDependencyRegistrationWithGenerics
    {
        public void Register<TContext, TIdentityUser>(IServiceCollection services, IConfigurationRoot configurationRoot) where TContext : DbContext where TIdentityUser : IdentityUser, new()
        {
            services.AddScoped<IPipedriveConnectorService, PipedriveConnectorService>();
            services.AddScoped<INewPipedriveLeadService, PipedriveConnectorService>();
            services.AddScoped<INewExternalSalesPlatformIntegrationService, PipedriveConnectorService>();
        }
    }
}
