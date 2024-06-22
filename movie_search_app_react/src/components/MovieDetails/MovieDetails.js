import React from 'react';
import './movie-details.css';

const MovieDetails = ({ title, year, plot, imdbRating, poster, onHide }) => {
  return (
    <div className="movie-details">
      <button className="button hide-button" onClick={onHide}>Hide</button>
      <h2>{title} ({year})</h2>
      <img src={poster} alt={`${title} Poster`} />
      <p><strong>IMDB Rating:</strong> {imdbRating}</p>
      <p><strong>Description:</strong> {plot}</p>
    </div>
  );
};

export default MovieDetails;
