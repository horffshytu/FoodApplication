using System.Net.Http.Headers;
using System.Net.Mime;
using FoodApplication.APIHandler;
using FoodApplication.Helpers;

namespace FoodApplication.IOC;

public static class ServiceCollection
{
    public static void AddHttpClientFactory(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection(Constants.API_SETTINGS_SECTION).Get<ApiSettings>();

        if (settings == null || string.IsNullOrWhiteSpace(settings.ClientName) || string.IsNullOrWhiteSpace(settings.BaseUrl))
        {
            throw new ArgumentException("Invalid API settings in configuration.");
        }

        services.AddHttpClient(settings.ClientName, client =>
        {
            client.Timeout = TimeSpan.FromMinutes(1);
            client.BaseAddress = new Uri(settings.BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        });
    }

    public static IServiceCollection AddApiHandler(this IServiceCollection services)
    {
        return services.AddScoped<IForkifyApiHandler, ForkifyApiHandler>();
    }
}
