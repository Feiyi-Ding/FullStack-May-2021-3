using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
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
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {                      
            // check validation on the server side
            if (ModelState.IsValid)
            {
                // save to database
                var user = await _userService.RegisterUser(model);

                // return to login
                return RedirectToAction("Login", "Account");
            }
            // take the info from view and save it to databsae
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            var user = await _userService.Login(model.Email, model.Password);
            if (user == null)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
