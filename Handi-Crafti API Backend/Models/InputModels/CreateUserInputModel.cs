namespace Handi_Crafti_API_Backend.Models.InputModels
{
    public class CreateUserInputModel
    {        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set;}
        public string Repass { get; set; }
    }
}
