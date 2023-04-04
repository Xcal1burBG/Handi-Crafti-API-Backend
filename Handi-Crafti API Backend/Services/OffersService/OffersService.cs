using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using Microsoft.EntityFrameworkCore;

namespace Handi_Crafti_API_Backend.Services.OffersService
{
    public class OffersService : IOffersService
    {
        private readonly ApplicationDbContext _db;

        public OffersService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Create
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


        // Get by Id

        public async Task<Offer> GetOfferById(Guid offerId)
        {
            var offer = await this._db.Offers.FirstOrDefaultAsync(x => x.Id == offerId);
#pragma warning disable CS8603 // Possible null reference return.
            return offer;
#pragma warning restore CS8603 // Possible null reference return.


        }


        // Get all

        public async Task<IEnumerable<Offer>> GetAllOffers()
        {
            var offers = await this._db.Offers.ToListAsync();
            //#pragma warning disable CS8603 // Possible null reference return.
            return offers;
            //#pragma warning restore CS8603 // Possible null reference return.

        }


        // Edit

        public async Task<Offer> EditOffer(Guid offerId, string title, string description, string images)
        {
            var offer = await this._db.Offers.FirstOrDefaultAsync(x => x.Id == offerId);

            if (offer == null)
            {
                return null;
            }

            offer.Title = title;
            offer.Description = description;
            offer.Images = images;

            await this._db.SaveChangesAsync();

            return offer;
        }


        // Delete

        public async Task<Offer> DeleteOffer(Guid offerId)
        {
            var offer = await this._db.Offers.FindAsync(offerId);

            if (offer != null)
            {
                this._db.Offers.Remove(offer);
                await this._db.SaveChangesAsync();
            }

            return offer;



        }
    }
}
