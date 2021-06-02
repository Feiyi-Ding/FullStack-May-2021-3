using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet("/movies")]
        public IActionResult Index()
        {
            return View();
        }
        //localhost/movies/details/23
        // Always have HttpMethod Type Attribute, by default if you don't have anything it's HttpGET
        [HttpGet("/movies/{id}")]
        public IActionResult Details(int id)
        {
            return View();
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
