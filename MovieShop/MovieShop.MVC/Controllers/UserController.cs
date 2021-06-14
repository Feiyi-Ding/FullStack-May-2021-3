using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasedMovies()
        {
            var userId = _currentUserService.UserId;
            // check whether user is logged in and 
            // if the user is not logged in, redirect to the login page
            // make a request to the database and get info from Purchase Table
            // select * from Purchase where userid = @getfromcookie

            return View();//movie cards
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie()
        {
            // get userid from currentUser and create a row in Purchase Table
            return View();
        }

        //[HttpPost("/User/purchase")]
        //public IActionResult Purchase()
        //{
        //    return View();
        //}

        //[HttpPost("/User/favorite")]
        //public IActionResult Favorite()
        //{
        //    return View();
        //}

        //[HttpPost("/User/unfavorite")]
        //public IActionResult Unfavorite()
        //{
        //    return View();
        //}

        //[HttpGet("/User/{id}/movie/{movieId}/favorite")]
        //public IActionResult GetUserMovieFavorite(int id, int movieId)
        //{
        //    return View();
        //}

        //[HttpPost("/User/review")]
        //public IActionResult PostReview()
        //{
        //    return View();
        //}

        //[HttpPut("/User/review")]
        //public IActionResult PutReview()
        //{
        //    return View();
        //}

        //[HttpDelete("/User/{userId}/movie/{movieId}")]
        //public IActionResult DeleteUserMovie(int userId, int movieId)
        //{
        //    return View();
        //}

        //[HttpGet("/User/{id}/purchases")]
        //public IActionResult Purchases(int id)
        //{
        //    return View();
        //}

        //[HttpGet("/User/{id}/favorites")]
        //public IActionResult Favorites(int id)
        //{
        //    return View();
        //}

        //[HttpGet("/User/{id}/reviews")]
        //public IActionResult Reviews(int id)
        //{
        //    return View();
        //}
    }
}
