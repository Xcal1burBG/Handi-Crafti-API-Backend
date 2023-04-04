namespace Handi_Crafti_API_Backend.Models.InputModels
{
    public class EditUserInputModel
    {
        public Guid UserId { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Password { get; set; }
        public String Repass { get; set; }

    }
}
