using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);

        Task<UserLoginResponseModel> Login(string email, string password);

        Task<UserRegisterResponseModel> UpdateProfile(UserRegisterRequestModel userRegisterRequestModel);

        // delete
        // edit user
        // change password
        // purchase movie
        // favorite movie
        // add review
        // get all purchased movies
        // get all favorite movies
        // delete review
        // remove favorite
        // get user details

    }
}
