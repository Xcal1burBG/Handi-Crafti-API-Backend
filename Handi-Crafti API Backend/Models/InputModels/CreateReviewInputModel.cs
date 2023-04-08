namespace Handi_Crafti_API_Backend.Models.InputModels
{
    public class CreateReviewInputModel
    {

        //public int Value { get; set; }
        public String Text { get; set; }
        public Guid HandiCrafterId { get; set; }
        public Guid ReviewerId { get; set; }
    }
}
