public class HttpClientWrapper : IHttpClient
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetAsync(string requestUri)
    {
        return await _httpClient.GetAsync(requestUri);
    }

    // Implement other methods as needed
}
