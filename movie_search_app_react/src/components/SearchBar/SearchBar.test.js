import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import SearchBar from './SearchBar';

test('renders the search input and allows input', () => {
  render(<SearchBar onSearch={jest.fn()} />);
  const searchInput = screen.getByPlaceholderText(/Search for a movie.../i);
  
  expect(searchInput).toBeInTheDocument();
  
  fireEvent.change(searchInput, { target: { value: 'Inception' } });
  expect(searchInput.value).toBe('Inception');
});

test('calls onSearch when the search button is clicked', () => {
  const handleSearch = jest.fn();
  render(<SearchBar onSearch={handleSearch} />);
  
  const searchInput = screen.getByPlaceholderText(/Search for a movie.../i);
  const searchButton = screen.getByLabelText('search');
  
  fireEvent.change(searchInput, { target: { value: 'Inception' } });
  fireEvent.click(searchButton);
  
  expect(handleSearch).toHaveBeenCalledWith('Inception');
});

test('calls onSearch when Enter key is pressed', () => {
  const handleSearch = jest.fn();
  render(<SearchBar onSearch={handleSearch} />);
  
  const searchInput = screen.getByPlaceholderText(/Search for a movie.../i);
  
  fireEvent.change(searchInput, { target: { value: 'Inception' } });
  fireEvent.keyPress(searchInput, { key: 'Enter', code: 'Enter', charCode: 13 });
  
  expect(handleSearch).toHaveBeenCalledWith('Inception');
});

test('does not call onSearch when input is empty', () => {
  const handleSearch = jest.fn();
  render(<SearchBar onSearch={handleSearch} />);
  
  const searchButton = screen.getByLabelText('search');
  fireEvent.click(searchButton);
  
  expect(handleSearch).not.toHaveBeenCalled();
});
