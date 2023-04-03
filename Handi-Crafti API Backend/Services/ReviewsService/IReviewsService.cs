using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Services.ReviewsService
{
    public interface IReviewsService
    {
        public Task<Review> CreateReview(int value, String text, Guid handiCrafterId, Guid CustomerId);

    }


}
