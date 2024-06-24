Movie Search React App

### Description 
This is a React-based web application for searching movies. Users can search for movies, view details, and see a list of their latest searches. The application uses modern React hooks and follows best practices for a clean and maintainable codebase.

### Features 

Movie Search: Search for movies by title.
Movie Details: View detailed information about a selected movie.
Latest Searches: Keep track of the latest movie searches.
Responsive Design: Mobile-friendly UI.

### Technologies Used 
React: Frontend framework for building user interfaces.
Axios: HTTP client for making API requests.
Jest: Testing framework for JavaScript.
ESLint: Linter for identifying and fixing problems in JavaScript code.
Babel: JavaScript compiler.

### Getting Started 
Prerequisites
Make sure you have the following installed:

Node.js
npm (Node package manager)
Installation

### Clone the repository:

bash
git clone https://github.com/your-username/movie-search-react-app.git
cd movie-search-react-app

### Install dependencies:

bash
npm install

### Running the Application
To start the development server, run:

bash
npm start
Open http://localhost:3000 in your browser to view the app.

### Running Tests
To run the tests, use the following command:

bash
npm test

### Building for Production
To create a production build, run:

bash
npm run build
The production-ready files will be in the build directory.

### Project Structure
public/: Contains the static assets and the index.html file.
src/: Contains the source code.
components/: Reusable React components.
LatestSearches/: Component for displaying the latest searches.
MovieDetails/: Component for displaying movie details.
MovieList/: Component for displaying a list of movies.
SearchBar/: Component for the search bar.
hooks/: Custom React hooks.
App.js: Main App component.
index.js: Entry point for the React app.
axiosInstance.js: Axios instance configuration.
reportWebVitals.js: For measuring performance.
setupTests.js: Jest setup file.
coverage/: Contains the test coverage reports.
.env: Environment variables.
babel.config.js: Babel configuration.
eslintrc.json: ESLint configuration.
jest.config.js: Jest configuration.
jest.setup.js: Jest setup file.
package.json: Project metadata and dependencies.
package-lock.json: Dependency tree.

### Environment Variables
To run this project, you will need to add the following environment variables to your .env file:

makefile
Copy code
REACT_APP_API_KEY=your_api_key_here
REACT_APP_API_URL=https://api.example.com