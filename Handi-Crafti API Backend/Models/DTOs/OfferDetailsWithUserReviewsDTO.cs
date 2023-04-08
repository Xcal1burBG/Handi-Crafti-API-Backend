using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class OfferDetailsWithUserReviewsDTO
    {
        public ReviewDTO[] ReviewsForHandiCrafter { get; set; }
    }
}
