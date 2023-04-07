using Handi_Crafti_API_Backend.DataBase.DBModels;
using Handi_Crafti_API_Backend.Models.DTOs;

namespace Handi_Crafti_API_Backend.Services.OffersService
{
    public interface IOffersService
    {
        public Task<OfferDTO> CreateOffer(Guid handiCrafterId, string title, String description, String images);
        public Task<OfferDTO> GetOfferById(Guid offerId);
        public Task<IEnumerable<Offer>> GetOffersByUserId(Guid userId);
        public Task<IEnumerable<OfferDTO>> GetAllOffers();
        public Task<Offer> EditOffer(Guid offerId, string title, String description, String images);

        public Task<Offer> DeleteOffer(Guid offerId);


    }


}
