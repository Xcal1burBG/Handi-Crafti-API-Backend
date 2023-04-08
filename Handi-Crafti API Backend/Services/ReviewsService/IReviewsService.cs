using Handi_Crafti_API_Backend.DataBase.DBModels;
using Handi_Crafti_API_Backend.Models.DTOs;

namespace Handi_Crafti_API_Backend.Services.ReviewsService
{
    public interface IReviewsService
    {
        public Task<Review> CreateReview(String text, Guid handiCrafterId, Guid reviewerId);
        public Task<OfferDetailsWithUserReviewsDTO[]> GetAllReviewsByUserId(Guid handicrafterId);


    }


}
