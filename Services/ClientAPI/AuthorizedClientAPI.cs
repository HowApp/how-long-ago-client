namespace HowClient.Services.ClientAPI;

public sealed class AuthorizedClientAPI : BaseClientAPI
{
    public AuthorizedClientAPI(HttpClient httpClient) : base(httpClient)
    {
    }
    
    internal new async Task<TReturn> GetAsync<TReturn>(string uri) => 
        await base.GetAsync<TReturn>(uri);

    internal new async Task<TReturn> PostAsync<TReturn, TRequest>(string uri, TRequest request) =>
        await base.PostAsync<TReturn, TRequest>(uri, request);

    internal new async Task<TReturn> PostAsync<TReturn>(string uri) => 
        await base.PostAsync<TReturn>(uri);
    
    internal new async Task<TReturn> PatchAsync<TReturn, TRequest>(string uri, TRequest request) =>
        await base.PatchAsync<TReturn, TRequest>(uri, request);
    
    internal new async Task<TReturn> PatchAsync<TReturn>(string uri) =>
        await base.PatchAsync<TReturn>(uri);
}