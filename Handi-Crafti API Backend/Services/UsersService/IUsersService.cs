using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public interface IUsersService
    {
        public Task<User> CreateUser(String username, String email, string avatarImage);
    }
}
