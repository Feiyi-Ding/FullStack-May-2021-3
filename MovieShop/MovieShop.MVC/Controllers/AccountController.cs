using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        //[HttpGet("/Account/{id}")]
        //public IActionResult Details(int id)
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Register()
        {
            // show a view with empty text boes for name, dob, email, password
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterRequestModel model)
        {                      
            // check validation on the server side
            if (ModelState.IsValid)
            {
                // save to database
            }
            // take the info from view and save it to databsae
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            return View();
        }
    }
}
