using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieSearchApp_WebApi.Controllers;
using MovieSearchApp_WebApi.Models;
using MovieSearchApp_WebApi.Services.Interfaces;

namespace MovieSearchApp_WebApi_UnitTests
{
    [TestClass]
    public class MoviesControllerTests
    {
        private Mock<IMovieService> _mockMovieService = null!;
        private Mock<ILogger<MoviesController>> _mockLogger = null!;
        private Mock<IHtmlSanitizer> _mockSanitizer = null!;
        private MoviesController _controller = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockMovieService = new Mock<IMovieService>();
            _mockLogger = new Mock<ILogger<MoviesController>>();
            _mockSanitizer = new Mock<IHtmlSanitizer>();
            _controller = new MoviesController(_mockMovieService.Object, _mockLogger.Object, _mockSanitizer.Object);
        }

        [TestMethod]
        public async Task SearchMovies_ValidTitle_ReturnsOkResult()
        {
            var title = "Home Alone";
            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>())).Returns(title);
            _mockMovieService.Setup(service => service.SearchMoviesAsync(It.IsAny<string>()))
                             .ReturnsAsync(new MovieSearchResult());

            var result = await _controller.SearchMovies(title);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetMovieDetails_ValidImdbID_ReturnsOkResult()
        {
            var imdbID = "tt0099785";
            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>())).Returns(imdbID);
            _mockMovieService.Setup(service => service.GetMovieDetailsAsync(It.IsAny<string>()))
                             .ReturnsAsync(new MovieDetails());

            var result = await _controller.GetMovieDetails(imdbID);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task SearchMovies_InvalidTitle_ReturnsNotFoundResult()
        {
            var title = "InvalidMovieTitle";
            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>())).Returns(title);
            _mockMovieService.Setup(service => service.SearchMoviesAsync(It.IsAny<string>()))
                             .ThrowsAsync(new HttpRequestException("Movie not found"));

            var result = await _controller.SearchMovies(title);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task GetMovieDetails_InvalidImdbID_ReturnsNotFoundResult()
        {
            var imdbID = "invalidID";
            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>())).Returns(imdbID);
            _mockMovieService.Setup(service => service.GetMovieDetailsAsync(It.IsAny<string>()))
                             .ThrowsAsync(new HttpRequestException("Movie not found"));

            var result = await _controller.GetMovieDetails(imdbID);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task SearchMovies_EmptyTitle_ReturnsBadRequest()
        {
            var title = "";

            var result = await _controller.SearchMovies(title);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task GetMovieDetails_EmptyImdbID_ReturnsBadRequest()
        {
            var imdbID = "";

            var result = await _controller.GetMovieDetails(imdbID);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task SearchMovies_NullTitle_ReturnsBadRequest()
        {
            string? title = null;

            var result = await _controller.SearchMovies(title!);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task GetMovieDetails_NullImdbID_ReturnsBadRequest()
        {
            string? imdbID = null;

            var result = await _controller.GetMovieDetails(imdbID!);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task SearchMovies_SanitizesInput()
        {
            var title = "<script>alert('XSS')</script>";
            var sanitizedTitle = "alert('XSS')";
            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>())).Returns(sanitizedTitle);
            _mockMovieService.Setup(service => service.SearchMoviesAsync(It.Is<string>(s => s == sanitizedTitle)))
                             .ReturnsAsync(new MovieSearchResult());

            var result = await _controller.SearchMovies(title);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetMovieDetails_SanitizesInput()
        {
            var imdbID = "<script>alert('XSS')</script>";
            var sanitizedImdbID = "alert('XSS')";
            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>())).Returns(sanitizedImdbID);
            _mockMovieService.Setup(service => service.GetMovieDetailsAsync(It.Is<string>(s => s == sanitizedImdbID)))
                             .ReturnsAsync(new MovieDetails());

            var result = await _controller.GetMovieDetails(imdbID);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
