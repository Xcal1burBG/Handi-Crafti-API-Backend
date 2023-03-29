using Handi_Crafti_API_Backend.Data;

namespace Handi_Crafti_API_Backend.Services.OffersService
{
    public class OffersService : IOffersService
    {
        private readonly ApplicationDbContext _db;

        public OffersService(ApplicationDbContext db)
        {
            _db = db;
        }




    }
}
