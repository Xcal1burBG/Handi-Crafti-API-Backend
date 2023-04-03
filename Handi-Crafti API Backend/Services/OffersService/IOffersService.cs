using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Services.OffersService
{
    public interface IOffersService
    {
        public Task<Offer> CreateOffer(Guid handiCrafterId, string title, String description, String images);
        public Task<Offer> GetOfferById(Guid offerId);
        public Task<Offer> GetAllOffers();
        public Task<Offer> EditOffer(Guid offerId, string title, String description, String images);

        public Task<Offer> DeleteOffer(Guid offerId);


    }


}
