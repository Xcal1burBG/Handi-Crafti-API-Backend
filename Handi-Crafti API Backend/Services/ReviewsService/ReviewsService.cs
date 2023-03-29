using Handi_Crafti_API_Backend.Data;

namespace Handi_Crafti_API_Backend.Services.ReviewsService
{
    public class ReviewsService : IReviewsService
    {
        private readonly ApplicationDbContext _db;

        public ReviewsService(ApplicationDbContext db)
        {
            _db = db;
        }



    }
}
