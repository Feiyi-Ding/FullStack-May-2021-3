using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService service)
        {
            _movieService = service;
        }
        [HttpGet("/movies")]
        public IActionResult Index()
        {
            return View();
        }
        //localhost/movies/details/23
        // Always have HttpMethod Type Attribute, by default if you don't have anything it's HttpGET
        [HttpGet("/movies/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movies = await _movieService.GetMovieDetailsById(id);
            return View(movies);
        }

        [HttpGet]
        public IActionResult TopRated()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopRevenue()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Genre(int id)
        {
            return View();
        }

        [HttpGet("/movies/{id}/reviews")]
        public IActionResult Reviews(int id)
        {
            return View();
        }
    }
}
