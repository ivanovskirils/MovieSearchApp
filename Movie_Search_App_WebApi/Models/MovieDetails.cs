namespace MovieSearchApp_WebApi.Models
{
    public class MovieDetails : Movie
    {
        public string Plot { get; set; }
        public string ImdbRating { get; set; }
    }
}
