using Handi_Crafti_API_Backend.DataBase.DBModels;
using System.ComponentModel.DataAnnotations;

namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
