using _02MovieList.Models;
using _02MovieList.Repositories;

namespace _02MovieList.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repos)
        {
            _repository = repos;
        }

        public void Create(string title, DateTime releaseDate, string genre, decimal price)
        {
            var newMovie = new Movie(title, releaseDate, genre, price);
            _repository.Add(newMovie);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            return _repository.GetAll();
        }

        public Movie? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(string title, DateTime releaseDate, string genre, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
