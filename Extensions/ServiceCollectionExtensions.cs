namespace HowClient.Extensions;

using Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using Services.Auth;
using Services.CookieHandler;
using Services.Provider;
using Services.Public.Event;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConfigurations(configuration)
            .AddCustomServices();

        return services;
    }
    
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<CookieHandler>();
        services.AddScoped<CustomStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
        services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<IEventService, EventService>();
        
        return services;
    }
    
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppConfigurations>(configuration.GetSection(nameof(AppConfigurations)));
        
        services.AddSingleton(resolver =>
            resolver.GetRequiredService<IOptions<AppConfigurations>>().Value);
        
        return services;
    }
}