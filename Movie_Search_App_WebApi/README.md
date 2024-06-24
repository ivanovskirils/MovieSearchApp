Movie Search Web API

### Description
This is a Web API for searching movies. It provides endpoints to search for movies, retrieve movie details, and manage related data. The API uses modern C# features and follows best practices for a clean and maintainable codebase.

### Features
Movie Search: Search for movies by title.
Movie Details: Retrieve detailed information about a specific movie.
Secure Data Handling: Sanitizes HTML to prevent XSS attacks.
Configurable: Uses appsettings for configuration.

### Technologies Used
.NET 7: Framework for building and running the API.
ASP.NET Core: For building web APIs.
Newtonsoft.Json: JSON framework for .NET.
AngleSharp: Library for parsing and querying HTML documents.
HtmlSanitizer: Library for sanitizing HTML content.

### Getting Started
Prerequisites
Make sure you have the following installed:

.NET 7 SDK
Visual Studio or any C# code editor

### Installation
### Clone the repository:

bash
Copy code
git clone https://github.com/your-username/movie-search-webapi.git
cd movie-search-webapi

### Restore dependencies:

bash
dotnet restore

### Running the Application
To start the development server, run:

bash
dotnet run
By default, the API will be available at https://localhost:5001.

### Running Tests
To run the tests, use the following command:

bash
dotnet test

### Building for Production
To create a production build, run:

bash
dotnet publish -c Release
The production-ready files will be in the bin/Release/net7.0/publish directory.

### Project Structure
Controllers/: Contains the API controllers.
MoviesController.cs: Controller for movie-related endpoints.
Models/: Contains the data models.
BaseMovie.cs: Base movie model.
Movie.cs: Movie model.
MovieDetails.cs: Detailed movie model.
MovieSearchResult.cs: Model for search results.
OmdbSettings.cs: Configuration model for OMDb API settings.
Services/: Contains the service interfaces and implementations.
Interfaces/: Service interfaces.
IHtmlSanitizer.cs: Interface for HTML sanitizer service.
IHttpClient.cs: Interface for HTTP client service.
IMovieService.cs: Interface for movie service.
Implementations/: Service implementations.
HtmlSanitizerWrapper.cs: Implementation of the HTML sanitizer.
HttpClientWrapper.cs: Implementation of the HTTP client.
MovieService.cs: Implementation of the movie service.
Properties/: Contains project properties.
launchSettings.json: Settings for launching the application.
appsettings.json: Application configuration file.
appsettings.Development.json: Development-specific configuration.
Program.cs: Entry point of the application.

### Environment Variables
To run this project, you will need to add the following environment variables to your appsettings.json or appsettings.Development.json file:

json
{
  "OmdbSettings": {
    "ApiKey": "your_api_key_here",
    "ApiUrl": "https://api.example.com"
  }
}
