using Handi_Crafti_API_Backend.DataBase.DBModels;
using System.ComponentModel.DataAnnotations;

namespace Handi_Crafti_API_Backend.Models.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public double AverageRating { get; set; }

    }
}
