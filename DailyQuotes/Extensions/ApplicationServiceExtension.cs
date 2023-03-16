using DailyQuotes.Features.Command;
using DailyQuotes.Repositories;
using MediatR;
using System.Reflection;

namespace DailyQuotes.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddHttpClient();

            services.AddScoped<IDailyQuoteRepository, DailyQuoteRepository>();

            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetDailyQuoteRequestHandler).Assembly));

            return services;
        }
    }
}
