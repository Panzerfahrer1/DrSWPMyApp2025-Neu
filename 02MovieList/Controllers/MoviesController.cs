using _02MovieList.Models;
using _02MovieList.Repositories;
using _02MovieList.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02MovieList.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View(_movieService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(_movieService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(Movie values)
        {
            _movieService.Create(values.Title, values.ReleaseDate, values.Genre, values.Price);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_movieService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie update)
        {
            _movieService.Update(id, update.Title, update.ReleaseDate, update.Genre, update.Price);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_movieService.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}