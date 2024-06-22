namespace MovieSearchApp_WebApi.Models
{
    public class BaseMovie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }

        public BaseMovie(string title, string year, string imdbID, string type, string poster)
        {
            Title = title;
            Year = year;
            ImdbID = imdbID;
            Type = type;
            Poster = poster;
        }

        public BaseMovie()
        {
            Title = string.Empty;
            Year = string.Empty;
            ImdbID = string.Empty;
            Type = string.Empty;
            Poster = string.Empty;
        }
    }
}
