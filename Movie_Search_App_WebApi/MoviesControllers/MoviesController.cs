using Microsoft.AspNetCore.Mvc;
using MovieSearchApp_WebApi.Services.Interfaces;

namespace MovieSearchApp_WebApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;


        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies([FromQuery] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                _logger.LogWarning("SearchMovies called with empty title.");
                return BadRequest("Title is required");
            }

            try
            {
                var results = await _movieService.SearchMoviesAsync(title);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching for movies.");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{imdbID}")]
        public async Task<IActionResult> GetMovieDetails(string imdbID)
        {
            try
            {
                var result = await _movieService.GetMovieDetailsAsync(imdbID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting movie details.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
