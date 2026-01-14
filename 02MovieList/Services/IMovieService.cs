using _02MovieList.Models;

namespace _02MovieList.Services
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Create(string title, DateTime releaseDate, string genre, decimal price);
        void Update(int id, string title, DateTime releaseDate, string genre, decimal price);
        void Delete(int id);
    }
}
