using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handi_Crafti_API_Backend.DataBase.DBModels
{
    public class Message
    {
        public Guid Id { get; set; }
        public User Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public User Receiver { get; set; }

        [MinLength(3), MaxLength(1000)]
        public String Text { get; set; }
        public DateTime CreatedAt { get; set; }
         public String Pictures { get; set; } // All paths are saved as an string /separated by comma

    }
}
