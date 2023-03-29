using Handi_Crafti_API_Backend.Data;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _db;

        public UsersService(ApplicationDbContext db)
        {
            _db = db;
        }



    }
}
