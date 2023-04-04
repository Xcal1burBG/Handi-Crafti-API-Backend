using System.ComponentModel.DataAnnotations;

namespace Handi_Crafti_API_Backend.DataBase.DBModels
{
    public class Offer
    {
        public Guid Id { get; set; }
        public Guid HandiCrafterId { get; set; }
        public User HandiCrafter { get; set; }

        [MinLength(10), MaxLength(100)]
        public string Title { get; set; }    
        public String Description { get; set; }
        public string Images { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
