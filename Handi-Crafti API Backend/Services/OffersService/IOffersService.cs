using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Services.OffersService
{
    public interface IOffersService
    {   
        public Task<Offer> CreateOffer(Guid handiCrafterId, string title, String description, String images);
    }


}
