namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class OfferDTO
    {
        public Guid Id { get; set; }
        public Guid HandiCrafterId { get; set; }
        public string HandiCraftersUsername { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Images { get; set; }

    }
}
