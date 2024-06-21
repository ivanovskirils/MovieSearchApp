using Microsoft.AspNetCore.Mvc;
using MovieSearchApp_WebApi.Interfaces;

namespace MovieSearchApp_WebApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies([FromQuery] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Title is required");
            }

            var results = await _movieService.SearchMoviesAsync(title);

            if (results == null || results.Search == null)
            {
                return NotFound("No movies found.");
            }

            return Ok(results);
        }


        [HttpGet("{imdbID}")]
        public async Task<IActionResult> GetMovieDetails(string imdbID)
        {
            var result = await _movieService.GetMovieDetailsAsync(imdbID);
            return Ok(result);
        }
    }
}
