using Handi_Crafti_API_Backend.DataBase.DBModels;
using System.ComponentModel.DataAnnotations;

namespace Handi_Crafti_API_Backend.DTOs
{
    public class UserDTO
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public string AvatarImage { get; set; }
        public double AverageRating { get; set; }
        

    }
}
