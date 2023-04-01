using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Services.OffersService
{
    public class OffersService : IOffersService
    {
        private readonly ApplicationDbContext _db;

        public OffersService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Offer> CreateOffer(Guid handiCrafterId, string title, String description, String images)
        {
            var offer = new Offer
            {
                Id = Guid.NewGuid(),
                HandiCrafterId = handiCrafterId,
                Title = title,
                Description = description,
                Images = images

            };

            await this._db.Offers.AddAsync(offer);
            await this._db.SaveChangesAsync();

            return offer;

        }
          



    }
}
