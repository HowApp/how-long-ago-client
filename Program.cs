namespace HowClient;

using Extensions;
using Services.ClientAPI;
using Services.CookieHandler;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        
        builder.Services.SetupServices(builder.Configuration);
        
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddOptions();

        builder.Services.AddScoped(sp => 
            new HttpClient
            {
                BaseAddress = new Uri( builder.Configuration.GetValue<string>("AppConfigurations:FrontendUrl") ?? 
                                       builder.HostEnvironment.BaseAddress)
            });

        builder.Services.AddHttpClient<AnonymousClientAPI>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppConfigurations:BackendUrl") ??
                                         builder.HostEnvironment.BaseAddress);
        });

        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("oidc", options.ProviderOptions);
        });

        // builder.Services.AddAuthorizationCore();
        
        // TODO: refactor authorized client
        // builder.Services.AddHttpClient<AuthorizedClientAPI>(client =>
        // {
        //     client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppConfigurations:BackendUrl") ??
        //                                  builder.HostEnvironment.BaseAddress);
        // }).AddHttpMessageHandler<CookieHandler>();
        //
        
        await builder.Build().RunAsync();
    }
}