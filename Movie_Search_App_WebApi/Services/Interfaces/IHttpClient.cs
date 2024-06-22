public interface IHttpClient
{
    Task<HttpResponseMessage> GetAsync(string requestUri);
}
