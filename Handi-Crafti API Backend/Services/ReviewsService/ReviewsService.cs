using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using Handi_Crafti_API_Backend.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Handi_Crafti_API_Backend.Services.ReviewsService
{
    public class ReviewsService : IReviewsService
    {
        private readonly ApplicationDbContext _db;

        public ReviewsService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Review> CreateReview(string text, Guid handiCrafterId, Guid customerId)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Text = text,
                HandiCrafterId = handiCrafterId,
                CustomerId = customerId
            };

            await _db.AddAsync(review);
            await _db.SaveChangesAsync();

            return review;

        }

        public async Task<OfferDetailsWithUserReviewsDTO[]> GetAllReviewsByUserId(Guid offerId)
        {
            var reviews = await this._db.Offers
                .Where(x => x.Id == offerId)
                .Select(x => new OfferDetailsWithUserReviewsDTO
                {
                    ReviewsForHandiCrafter = x.HandiCrafter.Reviews.Select(z => new ReviewDTO
                    {
                        Text = z.Text,
                        ReviewerUserName = z.Customer.UserName
                    }).ToArray()
                }).ToArrayAsync();

            return reviews;

        }
    }
}
