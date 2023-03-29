namespace Handi_Crafti_API_Backend.DTOs
{
    public class OfferDTO
    {
        public Guid Id { get; set; }

        [MinLength(10), MaxLength(100)]
        public string Title { get; set; }
        public Guid HandiCrafterId { get; set; }
        public User HandiCrafter { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Image { get; set; }
        public String Description { get; set; }
    }
}
