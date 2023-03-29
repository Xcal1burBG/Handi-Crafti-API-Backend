namespace Handi_Crafti_API_Backend.DTOs
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public String Text { get; set; }
        public Guid HandiCrafterId { get; set; }
        public Guid CustomerId { get; set; }
        
    }
}
