import { useState } from 'react';
import axiosInstance from '../axiosInstance';

const useMovieSearch = () => {
  const [movies, setMovies] = useState([]);
  const [selectedMovie, setSelectedMovie] = useState(null);
  const [queries, setQueries] = useState([]);
  const [error, setError] = useState(null);

  const handleSearch = async (query) => {
    try {
      setSelectedMovie(null);
      setError(null);
      const result = await axiosInstance.get(`/search?title=${query}`);
      const movies = result.data.search || [];
      setMovies(movies);

      const normalizedQuery = query.toLowerCase();
      if (!queries.map(q => q.toLowerCase()).includes(normalizedQuery)) {
        setQueries([query, ...queries.slice(0, 4)]);
      }
    } catch (error) {
      console.error('Error fetching movie search results:', error);
      setError('An error occurred while fetching movie search results.');
    }
  };

  const handleSelectMovie = async (imdbID) => {
    try {
      setError(null);
      const result = await axiosInstance.get(`/${imdbID}`);
      setSelectedMovie(result.data);
      window.scrollTo({ top: 0, behavior: 'smooth' });
    } catch (error) {
      console.error('Error fetching movie details:', error);
      setError('An error occurred while fetching movie details.');
    }
  };

  const handleRecentSearchClick = (query) => {
    handleSearch(query);
  };

  const handleHideDetails = () => {
    setSelectedMovie(null);
  };

  return {
    movies,
    selectedMovie,
    queries,
    error,
    handleSearch,
    handleSelectMovie,
    handleRecentSearchClick,
    handleHideDetails,
  };
};

export default useMovieSearch;
