import { useState } from 'react';
import axios from 'axios';

const MoviesSearch = () => {
    const [title, setTitle] = useState('');
    const [genre, setGenre] = useState('');
    const [movies, setMovies] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');

    const fetchMovies = async () => {
        if (!title) {
            setError('Please provide a title and optional genre.');
            return;
        }

        setLoading(true);
        setError('');
        try {
            const response = await axios.get('/movies', {
                params: {
                    title: title,
                    genre: genre
                }
            });

            setMovies(response.data);
        } catch (err) {
            setError('Failed to fetch movies.');
            console.error(err);
        } finally {
            setLoading(false);
        }
    };

    const handleSearchTermChange = (e) => {
        setTitle(e.target.value);
    };

    const handleGenreChange = (e) => {
        setGenre(e.target.value);
    };

    const handleSearchClick = () => {
        setMovies([]); // Clear previous results
        fetchMovies();
    };

    return (
        <div>
            <h1>Movie Search</h1>

            <div>
                <input
                    type="text"
                    value={title}
                    onChange={handleSearchTermChange}
                    placeholder="Search by title"
                />
                <input
                    type="text"
                    value={genre}
                    onChange={handleGenreChange}
                    placeholder="Search by genre"
                />
                <button onClick={handleSearchClick}>Search</button>
            </div>

            {loading && <p>Loading...</p>}
            {error && <p>{error}</p>}

            {Array.isArray(movies) && movies.length > 0 && (
                <div>
                    <ul>
                        {movies.map((movie, index) => (
                            <li key={index}>
                                <div>
                                    <h2>{movie.Title}</h2>
                                    <img
                                        src={movie.Poster_Url}
                                        alt={movie.Title}
                                        style={{ width: '100px', height: '150px' }}
                                    />
                                    <p><strong>Release Date:</strong> {movie.Release_Date}</p>
                                    <p><strong>Genre:</strong> {movie.Genre}</p>
                                    <p><strong>Overview:</strong> {movie.Overview}</p>
                                    <p><strong>Popularity:</strong> {movie.Popularity}</p>
                                    <p><strong>Vote Count:</strong> {movie.Vote_Count}</p>
                                    <p><strong>Vote Average:</strong> {movie.Vote_Average}</p>
                                    <p><strong>Original Language:</strong> {movie.Original_Language}</p>
                                </div>
                            </li>
                        ))}
                    </ul>
                </div>
            )}

            {movies.length === 0 && !loading && <p>No movies found.</p>}
        </div>
    );
};

export default MoviesSearch;
