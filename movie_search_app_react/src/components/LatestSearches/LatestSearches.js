import React from 'react';
import './latest-searches.css'; 

const LatestSearches = ({ queries, onRecentSearchClick }) => {
  return (
    <div className="latest-searches">
      <h2>Latest Searches</h2>
      <ul>
        {queries.map((query, index) => (
          <li key={index} onClick={() => onRecentSearchClick(query)} style={{ cursor: 'pointer' }}>
            {query}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default LatestSearches;
