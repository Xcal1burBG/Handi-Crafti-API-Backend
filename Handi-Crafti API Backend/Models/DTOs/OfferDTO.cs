namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class OfferDTO
    {
        public Guid Id { get; set; }
        public Guid HandiCrafterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }

        public string MainPhoto
        {
            get
            {
#pragma warning disable CS8603 // Possible null reference return.
                return !string.IsNullOrEmpty(Images) ? Images.Split(',')[0] : null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
