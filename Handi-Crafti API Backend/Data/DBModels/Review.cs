using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handi_Crafti_API_Backend.DataBase.DBModels
{
    public class Review
    {
        public Guid Id { get; set; }
        public int Value { get; set; }

        [MinLength(3), MaxLength(200)]
        public String Text { get; set; }

        public Guid HandiCrafterId { get; set; }
        public User HandiCrafter { get; set; }

        public Guid CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTime CreatedAt { get; set; }



    }
}
