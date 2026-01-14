using _02MovieList.Models;

namespace _02MovieList.Repositories
{
    public class InMemoryMovieRespository : IMovieRepository
    {
        private List<Movie> movies = new List<Movie>()
        {
            new Models.Movie("Inception", new DateTime(2010, 7, 16), "Science Fiction", 14.99m),
            new Models.Movie("The Dark Knight", new DateTime(2008, 7, 18), "Action", 12.99m),
            new Models.Movie("Interstellar", new DateTime(2014, 11, 7), "Science Fiction", 15.99m),
            new Models.Movie("Pulp Fiction", new DateTime(1994, 10, 14), "Crime", 9.99m)
        };

        public void Update(int id, string title, DateTime releaseDate, string genre, decimal price)
        {
            Movie movie = new Movie(title, releaseDate, genre, price);

            var existingMovie = GetById(id);

            existingMovie?.Update(movie);
        }   
        public void Add(Movie movie)
        {
            if (movie.CheckValues(movie) == false)
            {
                throw new ArgumentException("Movie has invalid values", nameof(movie));
            }

            Movie newMovie = new(movie.Title, movie.ReleaseDate, movie.Genre, movie.Price);

            movies.Add(movie);
        }

        public void Delte(int id)
        {
            movies.RemoveAt(id);
        }

        public List<Movie> GetAll()
        {
            return movies;
        }

        public Movie? GetById(int id)
        {
            return movies[id];
        }
    }
}
