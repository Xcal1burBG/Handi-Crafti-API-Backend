namespace Handi_Crafti_API_Backend.Models.InputModels
{
    public class CreateOfferInputModel
    {
        public Guid HandiCrafterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
    }
}
