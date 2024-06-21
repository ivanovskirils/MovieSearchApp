
using MovieSearchApp_WebApi.Interfaces;
using MovieSearchApp_WebApi.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MovieSearchApp_WebApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MovieService(HttpClient httpClient, IOptions<OmdbSettings> settings)
        {
            _httpClient = httpClient;
            _apiKey = settings.Value.OmdbApiKey;
        }

        public async Task<MovieSearchResult> SearchMoviesAsync(string title)
        {
            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?s={title}&apikey={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MovieSearchResult>(content);
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(string imdbID)
        {
            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?i={imdbID}&apikey={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MovieDetails>(content);
        }
    }
}
