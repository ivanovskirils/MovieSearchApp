import React from 'react';
import SearchBar from './components/SearchBar/SearchBar';
import MovieList from './components/MovieList/MovieList';
import MovieDetails from './components/MovieDetails/MovieDetails';
import LatestSearches from './components/LatestSearches/LatestSearches'; 
import useMovieSearch from './hooks/useMovieSearch'; 
import './index.css';
import './components/SearchBar/search-bar.css';
import './components/LatestSearches/latest-searches.css'; 
import './components/MovieList/movie-list.css'; 
import './components/MovieDetails/movie-details.css'; 

const App = () => {
  const {
    movies,
    selectedMovie,
    queries,
    error,
    handleSearch,
    handleSelectMovie,
    handleRecentSearchClick,
    handleHideDetails,
  } = useMovieSearch();

  return (
    <div className="container">
      <header className="app-header">
        <div className="app-title">
          <i className="fas fa-film"></i>
          <h1>Movie Search App</h1>
        </div>
        <SearchBar onSearch={handleSearch} />
      </header>
      {error && <div className="error-message">{error}</div>}
      {selectedMovie && (
        <div className="fade-in">
          <MovieDetails {...selectedMovie} onHide={handleHideDetails} />
        </div>
      )}
      <LatestSearches queries={queries} onRecentSearchClick={handleRecentSearchClick} />
      <MovieList movies={movies} onSelect={handleSelectMovie} />
    </div>
  );
};

export default App;
