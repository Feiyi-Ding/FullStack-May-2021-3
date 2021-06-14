using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;

        public AccountController(IUserService userService, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
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

            // user entered his correct un/pw
            // we willl create a cookie, movieshopauthcookie => FirstName, LastName, Id, Email, expiration time, claims info
            // cookies based Authentication
            // cookies stored on the browser, will auto send to the service

            // create claim obj and store required information
            var claims = new List<Claim> {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // ***HttpContext => 
            // method type => get/post
            // URL
            // browsers
            // headers
            // forms
            // cookies

            // create an identity object
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create a cookie that stores the identity information

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect("~/");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserRegisterRequestModel model)
        {
            if(model.Email == null)
            {
                model.Email = _currentUserService.Email;
            }
            if (model.FirstName == null)
            {
                model.FirstName = _currentUserService.FullName.Split(" ")[0];
            }
            if (model.LastName == null)
            {
                model.LastName = _currentUserService.FullName.Split(" ")[1];
            }
            var user = await _userService.UpdateProfile(model);
            return RedirectToAction("ViewProfile", "Account");
        }
    }
}
