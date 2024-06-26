﻿using System.Threading.Tasks;
using MovieSearchApp_WebApi.Models;

namespace MovieSearchApp_WebApi.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieSearchResult> SearchMoviesAsync(string title);
        Task<MovieDetails> GetMovieDetailsAsync(string imdbID);
    }
}
