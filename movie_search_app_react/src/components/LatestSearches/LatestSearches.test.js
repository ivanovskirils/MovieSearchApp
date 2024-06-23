import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import LatestSearches from './LatestSearches';

test('renders Latest Searches header', () => {
  render(<LatestSearches queries={[]} onRecentSearchClick={jest.fn()} />);
  expect(screen.getByText(/Latest Searches/i)).toBeInTheDocument();
});

test('renders the list of recent searches', () => {
  const queries = ['Inception', 'Interstellar', 'Dunkirk'];
  render(<LatestSearches queries={queries} onRecentSearchClick={jest.fn()} />);
  
  queries.forEach(query => {
    expect(screen.getByText(query)).toBeInTheDocument();
  });
});

test('calls onRecentSearchClick when a recent search is clicked', () => {
  const queries = ['Inception', 'Interstellar', 'Dunkirk'];
  const handleRecentSearchClick = jest.fn();
  
  render(<LatestSearches queries={queries} onRecentSearchClick={handleRecentSearchClick} />);
  
  const recentSearch = screen.getByText('Inception');
  fireEvent.click(recentSearch);
  
  expect(handleRecentSearchClick).toHaveBeenCalledWith('Inception');
});
