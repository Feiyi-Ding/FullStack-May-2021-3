using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        [HttpPost("/Admin/movie")]
        public IActionResult PostMovie()
        {
            return View();
        }

        [HttpPut("/Admin/movie")]
        public IActionResult PutMovie()
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
