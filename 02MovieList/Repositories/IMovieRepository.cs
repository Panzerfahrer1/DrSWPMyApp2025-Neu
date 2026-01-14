using _02MovieList.Controllers;
using _02MovieList.Models;

namespace _02MovieList.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        void Update(int id, string title, DateTime releaseDate, string genre, decimal price);
        void Delte(int id);
    }
}
