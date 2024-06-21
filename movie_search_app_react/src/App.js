import React, { useState } from 'react';
import axiosInstance from './axiosInstance';
import SearchBar from './components/SearchBar';
import MovieList from './components/MovieList';
import MovieDetails from './components/MovieDetails';
import './styles/animations.css';
import './styles/buttons.css';
import './styles/layout.css';
import './styles/search-bar.css';

const App = () => {
  const [movies, setMovies] = useState([]);
  const [selectedMovie, setSelectedMovie] = useState(null);
  const [queries, setQueries] = useState([]);
  const [isFadingOut, setIsFadingOut] = useState(false);

  const handleSearch = async (query) => {
    try {
      setSelectedMovie(null);
      const result = await axiosInstance.get(`/api/movies/search?title=${query}`);
      const movies = result.data.search || [];
      setMovies(movies);

      const normalizedQuery = query.toLowerCase();
      if (!queries.map(q => q.toLowerCase()).includes(normalizedQuery)) {
        setQueries([query, ...queries.slice(0, 4)]);
      }
    } catch (error) {
      console.error('Error fetching movie search results:', error);
    }
  };

  const handleSelectMovie = async (imdbID) => {
    try {
      const result = await axiosInstance.get(`/api/movies/${imdbID}`);
      setSelectedMovie(result.data);
      window.scrollTo({ top: 0, behavior: 'smooth' });
      setIsFadingOut(false);
    } catch (error) {
      console.error('Error fetching movie details:', error);
    }
  };

  const handleRecentSearchClick = (query) => {
    handleSearch(query);
  };

  const handleHideDetails = () => {
    setIsFadingOut(true);
    setTimeout(() => {
      setSelectedMovie(null);
    }, 400);
  };

  return (
    <div className="container">
      <header className="app-header">
        <div className="app-title">
          <i className="fas fa-film"></i>
          <h1>Movie Search App</h1>
        </div>
        <SearchBar onSearch={handleSearch} />
      </header>
      {selectedMovie && (
        <div className={isFadingOut ? 'fade-out' : 'fade-in'}>
          <MovieDetails {...selectedMovie} onHide={handleHideDetails} />
        </div>
      )}
      <div className="latest-searches">
        <h2>Latest Searches</h2>
        <ul>
          {queries.map((query, index) => (
            <li key={index} onClick={() => handleRecentSearchClick(query)} style={{ cursor: 'pointer' }}>
              {query}
            </li>
          ))}
        </ul>
      </div>
      <MovieList movies={movies} onSelect={handleSelectMovie} />
    </div>
  );
};

export default App;
