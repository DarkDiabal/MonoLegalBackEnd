using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonoLegal.Business.Helpers;
using MonoLegal.Business.Implementations;
using MonoLegal.Business.Interfaces;

namespace MonoLegal.Business
{
    public static class MonoLegalServicesBusinessExtension
    {
        public static IServiceCollection AddConfigureServicesBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            //Business
            services.AddScoped<IInvoiceBusiness, InvoiceBusiness>();
            services.AddScoped<INotificationHelper, NotificationHelper>();

            return services;
        }
    }
}
