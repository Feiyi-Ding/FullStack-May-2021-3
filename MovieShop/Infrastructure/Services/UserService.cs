﻿using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            // go to database and get user info row by email
            var user = await _userRepository.GetUserByEmail(email);

            if(user == null)
            {
                return null;
            }

            // get the password from the UI and salt from above step from database and call 
            var hashedPassword = CreateHashedPassword(password, user.Salt);
            if (hashedPassword == user.HashedPassword)
            {
                // user entered correct password

                var loginResponseModel = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return loginResponseModel;
            }

            return null;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            //first we need to check that email does not exist in our database
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);

            if(dbUser != null)
            {
                throw new Exception("User alreasy exists, please try to login");
            }
            // generate a unique Salt
            var salt = CreateSalt();

            // hash the password with userRegisterRequestModel.Password + salt from above step
            // never ever create your own hashing algorithms
            var hashedPassword = CreateHashedPassword(userRegisterRequestModel.Password, salt);

            // call the user repository to save the user info
            var user = new User
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email,
                DateOfBirth = userRegisterRequestModel.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword,
            };

            var createdUser = await _userRepository.Add(user);

            // convert the returned user entity to UserRegisterResponseModel
            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email,
            };

            return response;
        }

        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public async Task<UserRegisterResponseModel> UpdateProfile(UserRegisterRequestModel userRegisterRequestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);

            var user = new User
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email
            };
            await _userRepository.UpdateUser(user);

            var response = new UserRegisterResponseModel
            {
                Id = dbUser.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };

            return response;
        }
    }
}
