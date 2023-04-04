using Handi_Crafti_API_Backend.DataBase.DBModels;
using System.ComponentModel.DataAnnotations;

namespace Handi_Crafti_API_Backend.Models.InputModels
{
    public class EditOfferInputModel
    {
        public Guid Id { get; set; }
        public Guid HandiCrafterId { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public string Images { get; set; }
    }
}
