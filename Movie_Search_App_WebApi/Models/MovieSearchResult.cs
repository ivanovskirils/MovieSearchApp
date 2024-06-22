namespace MovieSearchApp_WebApi.Models
{
    public class MovieSearchResult
    {
        public List<Movie> Search { get; set; }

        public MovieSearchResult(List<Movie> search)
        {
            Search = search;
        }

        public MovieSearchResult()
        {
            Search = new List<Movie>();
        }
    }
}
