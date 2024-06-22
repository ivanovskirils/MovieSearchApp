namespace MovieSearchApp_WebApi.Models
{
    public class Movie : BaseMovie
    {
        public Movie(string title, string year, string imdbID, string type, string poster)
            : base(title, year, imdbID, type, poster)
        {
        }

        public Movie() : base()
        {
        }
    }
}
