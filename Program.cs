namespace HowClient;

using Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Services.ClientAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.SetupServices(builder.Configuration);

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddOptions();

        builder.Services.AddHttpClient<AuthorizedClientAPI>("how-api-client.authorized", client =>
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppConfigurations:BackendUrl")))
            .AddHttpMessageHandler(httpBuilder =>
            {
                var handler = httpBuilder.GetService<AuthorizationMessageHandler>()!
                    .ConfigureHandler(
                        authorizedUrls: new[] { builder.Configuration.GetValue<string>("AppConfigurations:BackendUrl") },
                        scopes: new[] { "scope.how-api" });

                return handler;
            });

        builder.Services.AddHttpClient<AnonymousClientAPI>("how-api-client.unauthorized", client =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppConfigurations:BackendUrl"));
        });

        builder.Services.AddScoped(sp =>  sp.GetService<IHttpClientFactory>()!.CreateClient("api-test-client.authorized"));
        builder.Services.AddScoped(sp =>  sp.GetService<IHttpClientFactory>()!.CreateClient("api-test-client.unauthorized"));
        builder.Services.AddScoped(sp => 
            new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppConfigurations:BackendUrl") ?? builder.HostEnvironment.BaseAddress)
            });

        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("oidc", options.ProviderOptions);
            options.UserOptions.RoleClaim = "role"; 
        })
        .AddAccountClaimsPrincipalFactory<CustomAccountClaimsPrincipalFactory<RemoteUserAccount>>();

        await builder.Build().RunAsync();
    }
}