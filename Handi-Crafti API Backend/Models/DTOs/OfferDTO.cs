namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class OfferDTO
    {
        public Guid Id { get; set; }
        public Guid HandiCrafterId { get; set; }
        public String HandiCraftersUsername { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }

    }
}
