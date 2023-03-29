using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _db;

        public UsersService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(String username, String email, string avatarImage)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Email = email,
                AvatarImage = avatarImage
            };

            await this._db.Users.AddAsync(user);
            await this._db.SaveChangesAsync();

            return user;

        }



    }
}
