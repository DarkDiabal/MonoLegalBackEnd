using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonoLegal.Persistence.Implementations;
using MonoLegal.Persistence.Interfaces;

namespace MonoLegal.Persistence
{
    public static class MonoLegalServicesPersistenceExtension
    {
        public static IServiceCollection AddConfigureServicesPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //Collection
            services.AddScoped<IInvoiceCollection, InvoiceCollection>();
            services.AddScoped<ITemplateCollection, TemplateCollection>();

            return services;
        }
    }
}
