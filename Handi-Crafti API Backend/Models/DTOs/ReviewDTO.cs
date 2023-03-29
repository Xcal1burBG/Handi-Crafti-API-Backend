namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }
        public Guid HandiCrafterId { get; set; }
        public Guid CustomerId { get; set; }

    }
}
