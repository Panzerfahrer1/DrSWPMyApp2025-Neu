using System.ComponentModel.DataAnnotations;

namespace _02MovieList.Models
{
    public class Movie
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }

        public Movie()
        {

        }

        public Movie(string title, DateTime releaseDate, string genre, decimal price)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Genre = genre;
            Price = price;
            Id = nextId++;
        }

        public bool Update(Movie movie)
        {
            if(!CheckValues(movie))
            {
                return false;
            }

            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            Genre = movie.Genre;
            Price = movie.Price;

            return true;
        }

        public bool CheckValues(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Title) ||
                string.IsNullOrEmpty(movie.Genre) ||
                string.IsNullOrEmpty(movie.ReleaseDate.ToString()) ||
                movie.Price < 0)
            {
                return false;
            }
            return true;
        }
    }
}
