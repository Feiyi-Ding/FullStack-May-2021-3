using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("/Account/{id}")]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpPost("/Account")]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpGet("/Account")]
        public IActionResult GetAccount()
        {
            return View();
        }

        [HttpPost("/Account/login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
