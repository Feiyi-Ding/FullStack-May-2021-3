using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet("/Admin/movie")]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost("/Admin/movie")]
        public IActionResult CreateMovie(MovieCreateResponseModel model)
        {
            return View();
        }

        [HttpGet("/Admin/Purchases")]
        public IActionResult Purchases()
        {
            return View();
        }
    }
}
