using System.ComponentModel.DataAnnotations;

namespace Handi_Crafti_API_Backend.DataBase.DBModels
{
    public class Offer
    {
        public Guid Id { get; set; }

        [MinLength(10), MaxLength(100)]
        public string Title { get; set; }    
        public Guid HandiCrafterId { get; set; }
        public User HandiCrafter { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Image { get; set; }
        public String Description { get; set; }

    }
}
