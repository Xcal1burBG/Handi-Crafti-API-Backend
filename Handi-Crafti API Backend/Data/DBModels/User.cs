using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Handi_Crafti_API_Backend.DataBase.DBModels
{
    public class User : IdentityUser<Guid>    {
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
