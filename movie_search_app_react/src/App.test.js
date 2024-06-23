import React from 'react';
import { render as rtlRender, screen, fireEvent, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom';
import App from './App';

jest.mock('./axiosInstance');

const render = (ui, options) =>
  rtlRender(ui, {
    container: document.body.appendChild(document.createElement('div')),
    ...options,
  });

test('renders the Movie Search App header', async () => {
  render(<App />);
  expect(await screen.findByText(/Movie Search App/i)).toBeInTheDocument();
});

test('renders the search input and allows input', async () => {
  render(<App />);
  const searchInput = screen.getByPlaceholderText(/Search for a movie.../i);
  expect(searchInput).toBeInTheDocument();

  fireEvent.change(searchInput, { target: { value: 'Inception' } });
  expect(searchInput.value).toBe('Inception');
});

test('renders the search button and performs search on click', async () => {
  render(<App />);
  const searchInput = screen.getByPlaceholderText(/Search for a movie.../i);
  const searchButton = screen.getByLabelText('search');
  
  expect(searchButton).toBeInTheDocument();

  fireEvent.change(searchInput, { target: { value: 'Inception' } });
  fireEvent.click(searchButton);

  await waitFor(() => {
    expect(screen.getByText(/No movies found./i)).toBeInTheDocument();
  });
});



