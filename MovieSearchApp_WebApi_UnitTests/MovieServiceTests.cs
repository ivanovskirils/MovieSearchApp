using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using MovieSearchApp_WebApi.Models;
using MovieSearchApp_WebApi.Services;
using MovieSearchApp_WebApi.Services.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace MovieSearchApp_WebApi_UnitTests
{
    [TestClass]
    public class MovieServiceTests
    {
        private Mock<IOptions<OmdbSettings>> _mockSettings = null!;
        private Mock<ILogger<MovieService>> _mockLogger = null!;
        private Mock<IHttpClient> _mockHttpClient = null!;
        private MovieService _movieService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockSettings = new Mock<IOptions<OmdbSettings>>();
            _mockSettings.Setup(s => s.Value).Returns(new OmdbSettings
            {
                OmdbApiKey = "test_api_key",
                BaseUrl = "http://www.omdbapi.com/"
            });

            _mockLogger = new Mock<ILogger<MovieService>>();
            _mockHttpClient = new Mock<IHttpClient>();
            _movieService = new MovieService(_mockHttpClient.Object, _mockSettings.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task SearchMoviesAsync_ValidTitle_ReturnsResults()
        {
            // Arrange
            var title = "Avatar";
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(new MovieSearchResult { Search = new List<Movie> { new Movie { Title = "Avatar" } } })
            };
            _mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            var result = await _movieService.SearchMoviesAsync(title);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Search.Any(m => m.Title == "Avatar"));
        }

        [TestMethod]
        public async Task GetMovieDetailsAsync_ValidImdbID_ReturnsDetails()
        {
            // Arrange
            var imdbID = "tt0099785";
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(new MovieDetails { ImdbID = "tt0099785", Title = "Home Alone" })
            };
            _mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            var result = await _movieService.GetMovieDetailsAsync(imdbID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("tt0099785", result.ImdbID);
            Assert.AreEqual("Home Alone", result.Title);
        }

        [TestMethod]
        public async Task SearchMoviesAsync_InvalidTitle_ThrowsException()
        {
            // Arrange
            var title = "InvalidMovieTitle";
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            _mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _movieService.SearchMoviesAsync(title));
        }

        [TestMethod]
        public async Task GetMovieDetailsAsync_InvalidImdbID_ThrowsException()
        {
            // Arrange
            var imdbID = "invalidID";
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            _mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _movieService.GetMovieDetailsAsync(imdbID));
        }
    }
}
