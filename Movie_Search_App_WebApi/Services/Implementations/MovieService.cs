using Microsoft.Extensions.Options;
using MovieSearchApp_WebApi.Models;
using MovieSearchApp_WebApi.Services.Interfaces;
using Newtonsoft.Json;

public class MovieService : IMovieService
{
    private readonly IHttpClient _httpClient;
    private readonly OmdbSettings _settings;
    private readonly ILogger<MovieService> _logger;

    public MovieService(IHttpClient httpClient, IOptions<OmdbSettings> settings, ILogger<MovieService> logger)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
        _logger = logger;
    }

    public async Task<MovieSearchResult> SearchMoviesAsync(string title)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_settings.BaseUrl}?s={title}&apikey={_settings.OmdbApiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MovieSearchResult>(content) ?? new MovieSearchResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while searching for movies.");
            throw;
        }
    }

    public async Task<MovieDetails> GetMovieDetailsAsync(string imdbID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_settings.BaseUrl}?i={imdbID}&apikey={_settings.OmdbApiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MovieDetails>(content) ?? new MovieDetails();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting movie details.");
            throw;
        }
    }
}
