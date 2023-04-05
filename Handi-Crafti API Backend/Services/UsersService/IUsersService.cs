using Handi_Crafti_API_Backend.DataBase.DBModels;
using Handi_Crafti_API_Backend.Models.DTOs;
using Microsoft.Identity.Client;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public interface IUsersService
    {
        public Task<User> CreateUser(String username, String email, string phoneNumber, string password);
        public Task<LoginUserDTO> Login(String userName, String password);
        public Task<User> GetUserById(Guid userId);
        public Task<User> EditUserById(Guid userId, String email, string phoneNumber, string password);
    }
}
