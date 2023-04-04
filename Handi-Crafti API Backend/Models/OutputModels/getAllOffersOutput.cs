using Handi_Crafti_API_Backend.Models.DTOs;

namespace Handi_Crafti_API_Backend.Models.OutputModels
{
    public class getAllOffersOutput
    {
        IEnumerable<OfferDTO> Offers { get; set; }
    }
}
