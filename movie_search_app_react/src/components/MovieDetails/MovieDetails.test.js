import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import MovieDetails from './MovieDetails';

test('renders movie details correctly', () => {
  const movie = {
    title: 'Inception',
    year: '2010',
    plot: 'A thief who steals corporate secrets through the use of dream-sharing technology.',
    imdbRating: '8.8',
    poster: 'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg'
  };
  
  render(<MovieDetails {...movie} onHide={jest.fn()} />);

  expect(screen.getByText(`${movie.title} (${movie.year})`)).toBeInTheDocument();
  expect(screen.getByAltText(`${movie.title} Poster`)).toBeInTheDocument();
  expect(screen.getByText(/IMDB Rating:/i)).toBeInTheDocument();
  expect(screen.getByText(movie.imdbRating)).toBeInTheDocument();
  expect(screen.getByText(/Description:/i)).toBeInTheDocument();
  expect(screen.getByText(movie.plot)).toBeInTheDocument();
});

test('calls onHide when the hide button is clicked', () => {
  const handleHide = jest.fn();
  
  render(<MovieDetails title="Inception" year="2010" plot="A thief who steals corporate secrets through the use of dream-sharing technology." imdbRating="8.8" poster="https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg" onHide={handleHide} />);
  
  const hideButton = screen.getByText(/Hide/i);
  fireEvent.click(hideButton);

  expect(handleHide).toHaveBeenCalled();
});
