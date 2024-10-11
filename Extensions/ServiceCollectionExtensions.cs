namespace HowClient.Extensions;

using Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using Services.Auth;
using Services.CookieHandler;
using Services.InternalNotification;
using Services.Private.Event;
using Services.Private.Record;
using Services.Provider;
using Services.Public.Event;
using Services.Public.Record;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConfigurations(configuration)
            .AddCustomServices()
            .AddBlazorBootstrap();

        return services;
    }

    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<CookieHandler>();
        services.AddScoped<CustomStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
        services.AddScoped<IAuthServices, AuthServices>();
        services.AddSingleton<InternalNotificationService>();

        //Public
        services.AddScoped<IEventPublicService, EventPublicService>();
        services.AddScoped<IRecordPublicService, RecordPublicService>();

        // Private
        services.AddScoped<IEventPrivateService, EventPrivateService>();
        services.AddScoped<IRecordPrivateService, RecordPrivateService>();
        
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