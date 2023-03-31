using Handi_Crafti_API_Backend.DataBase.DBModels;
using Microsoft.Identity.Client;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public interface IUsersService
    {
        public Task<User> CreateUser(String username, String email, string phoneNumber, string password);
    }
}
