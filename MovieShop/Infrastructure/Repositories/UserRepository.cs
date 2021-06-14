using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task UpdateUser(User user)
        {
            var originalInfo = await GetUserByEmail(user.Email);
            if(user.FirstName != null)
            {
                originalInfo.FirstName = user.FirstName;
            }
            if(user.LastName != null)
            {
                originalInfo.LastName = user.LastName;
            }
            if(user.Email != null)
            {
                originalInfo.Email = user.Email;
            }

            var updatedInfo = _dbContext.Users.Update(originalInfo);
            return;
        }
    }
}
