using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ganss.Xss;
using MovieSearchApp_WebApi.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MovieSearchApp_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;
        private readonly IHtmlSanitizer _sanitizer;

        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger, IHtmlSanitizer sanitizer)
        {
            _movieService = movieService;
            _logger = logger;
            _sanitizer = sanitizer;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest(new { Message = "Title cannot be empty" });
            }

            var sanitizedTitle = _sanitizer.Sanitize(title);

            try
            {
                var result = await _movieService.SearchMoviesAsync(sanitizedTitle);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                return NotFound(new { Message = "Movie not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while searching for movies.");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpGet("{imdbID}")]
        public async Task<IActionResult> GetMovieDetails(string imdbID)
        {
            if (string.IsNullOrWhiteSpace(imdbID))
            {
                return BadRequest(new { Message = "IMDb ID cannot be empty" });
            }

            var sanitizedImdbID = _sanitizer.Sanitize(imdbID);

            try
            {
                var result = await _movieService.GetMovieDetailsAsync(sanitizedImdbID);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                return NotFound(new { Message = "Movie not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting movie details.");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }
    }
}
