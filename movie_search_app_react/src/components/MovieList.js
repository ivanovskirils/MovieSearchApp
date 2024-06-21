import React from 'react';

const MovieList = ({ movies = [], onSelect }) => {
  if (movies.length === 0) {
    return <div>No movies found.</div>;
  }

  return (
    <div className="movie-list">
      {movies.map(movie => (
        <div key={movie.imdbID} className="movie-item" onClick={() => onSelect(movie.imdbID)}>
          <img src={movie.poster} alt={`${movie.title} Poster`} />
          <h3>{movie.title} ({movie.year})</h3>
        </div>
      ))}
    </div>
  );
};

export default MovieList;
