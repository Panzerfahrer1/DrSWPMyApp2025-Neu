using _02MovieList.Models;
using _02MovieList.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace _02MovieList.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            return View(_movieRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(_movieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(Movie values)
        {
            _movieRepository.Add(values);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_movieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie update)
        {
            _movieRepository.Update(update);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_movieRepository.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieRepository.Delte(id);

            return RedirectToAction("Index");
        }
    }
}