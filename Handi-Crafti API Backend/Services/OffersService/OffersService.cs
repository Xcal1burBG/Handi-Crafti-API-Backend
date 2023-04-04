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


       

       
        // Get
        
        public Task<Offer> GetOfferById(Guid offerId)
        {
            throw new NotImplementedException();
        } 


        public Task<Offer> GetAllOffers()
        {
            throw new NotImplementedException();
        }


        // Edit

        public Task<Offer> EditOffer(Guid offerId, string title, string description, string images)
        {
            throw new NotImplementedException();
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
