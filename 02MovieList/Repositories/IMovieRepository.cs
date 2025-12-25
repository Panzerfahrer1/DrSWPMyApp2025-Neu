using _02MovieList.Controllers;
using _02MovieList.Models;

namespace _02MovieList.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delte(int id);
    }
}
