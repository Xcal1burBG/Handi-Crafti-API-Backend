using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using Microsoft.AspNetCore.Identity;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _db;

        public UsersService(ApplicationDbContext db)
        {
            _db = db;
        }

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



    }
}
