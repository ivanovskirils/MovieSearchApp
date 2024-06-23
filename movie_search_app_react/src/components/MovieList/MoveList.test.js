import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import MovieList from './MovieList';

test('renders "No movies found" when there are no movies', () => {
  render(<MovieList movies={[]} />);
  
  expect(screen.getByText(/No movies found/i)).toBeInTheDocument();
});

test('renders a list of movies', () => {
  const movies = [
    { imdbID: 'tt1375666', title: 'Inception', year: '2010', poster: 'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg' },
    { imdbID: 'tt0137523', title: 'Fight Club', year: '1999', poster: 'https://m.media-amazon.com/images/M/MV5BMmEzYjM4NjItYzNjNS00ZmUyLWE0MjQtYWI0M2JlZmEzYzNmXkEyXkFqcGdeQXVyNDkzNTM2ODg@._V1_SX300.jpg' }
  ];

  render(<MovieList movies={movies} />);
  
  expect(screen.getByText(/Inception/i)).toBeInTheDocument();
  expect(screen.getByText(/2010/i)).toBeInTheDocument();
  expect(screen.getByAltText(/Inception Poster/i)).toBeInTheDocument();
  expect(screen.getByText(/Fight Club/i)).toBeInTheDocument();
  expect(screen.getByText(/1999/i)).toBeInTheDocument();
  expect(screen.getByAltText(/Fight Club Poster/i)).toBeInTheDocument();
});

test('calls onSelect when a movie is clicked', () => {
  const movies = [
    { imdbID: 'tt1375666', title: 'Inception', year: '2010', poster: 'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg' }
  ];
  const handleSelect = jest.fn();

  render(<MovieList movies={movies} onSelect={handleSelect} />);
  
  const movieItem = screen.getByText(/Inception/i).closest('.movie-item');
  expect(movieItem).toBeInTheDocument();
  
  fireEvent.click(movieItem);

  expect(handleSelect).toHaveBeenCalledWith('tt1375666');
});
