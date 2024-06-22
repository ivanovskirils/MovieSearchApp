namespace MovieSearchApp_WebApi.Models
{
    public class OmdbSettings
    {
        public string OmdbApiKey { get; set; }
        public string BaseUrl { get; set; }

        public OmdbSettings(string omdbApiKey, string baseUrl)
        {
            OmdbApiKey = omdbApiKey;
            BaseUrl = baseUrl;
        }

        public OmdbSettings()
        {
            OmdbApiKey = string.Empty;
            BaseUrl = string.Empty;
        }
    }
}
