namespace MovieSearchApp_WebApi.Models
{
    public class MovieDetails : BaseMovie
    {
        public string Plot { get; set; }
        public string ImdbRating { get; set; }

        public MovieDetails(string plot, string imdbRating, string title, string year, string imdbID, string type, string poster)
            : base(title, year, imdbID, type, poster)
        {
            Plot = plot;
            ImdbRating = imdbRating;
        }

        public MovieDetails() : base()
        {
            Plot = string.Empty;
            ImdbRating = string.Empty;
        }
    }
}
