namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class LoginUserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
