import React from 'react';
import '../styles/buttons.css';

const MovieDetails = ({ title, year, plot, imdbRating, poster, onHide, className }) => {
  return (
    <div className={`movie-details ${className}`}>
      <button className="button hide-button" onClick={onHide}>Hide</button>
      <h2>{title} ({year})</h2>
      <img src={poster} alt={`${title} Poster`} />
      <p><strong>IMDB Rating:</strong> {imdbRating}</p>
      <p><strong>Description:</strong> {plot}</p>
    </div>
  );
};

export default MovieDetails;
