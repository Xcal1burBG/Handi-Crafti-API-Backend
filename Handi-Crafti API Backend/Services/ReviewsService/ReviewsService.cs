using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
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

        public async Task<Review> CreateReview(int value, String text, Guid handiCrafterId, Guid customerId)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Value = value,
                Text = text,
                HandiCrafterId = handiCrafterId,
                CustomerId = customerId
            };

            await _db.AddAsync(review);
            await _db.SaveChangesAsync();

            return review;

        }

        public async Task<IEnumerable<Review>> GetAllReviewsByUserId(Guid handicrafterId)
        {
            var reviews = await this._db.Reviews
                .Where(x => x.HandiCrafterId == handicrafterId)
                .ToListAsync();

            return reviews;

        }
    }
}
