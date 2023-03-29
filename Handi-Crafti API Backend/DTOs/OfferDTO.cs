namespace Handi_Crafti_API_Backend.DTOs
{
    public class OfferDTO
    {
        public Guid Id { get; set; }
        public Guid HandiCrafterId { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public string Images { get; set; }
    }
}
