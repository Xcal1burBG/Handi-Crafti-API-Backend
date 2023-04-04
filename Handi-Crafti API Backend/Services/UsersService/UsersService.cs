using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _db;

        public UsersService(ApplicationDbContext db)
        {
            _db = db;
        }


        // Create

        public async Task<User> CreateUser(String username, String email, String phoneNumber, string password)
        {

            var hasher = new PasswordHasher<User>();


            var user = new User();

            user.Id = Guid.NewGuid();
            user.UserName = username;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            user.PasswordHash = hasher.HashPassword(user, password);


            await this._db.Users.AddAsync(user);
            await this._db.SaveChangesAsync();

            return user;

        }


        // Get User by Id

        public async Task<User> GetUserById(Guid userId)
        {
            var user = await this._db.Users.FirstOrDefaultAsync(x => x.Id == userId);

#pragma warning disable CS8603 // Possible null reference return.
            return user;
#pragma warning restore CS8603 // Possible null reference return.
        }


        // Edit

        public async Task<User> EditUserById(Guid userId, string email, string phoneNumber, string password)
        {
            var user = await this._db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            return user;

        }



    }
}
