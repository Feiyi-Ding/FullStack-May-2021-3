using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        [HttpGet("/Cast/{id}")]
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
