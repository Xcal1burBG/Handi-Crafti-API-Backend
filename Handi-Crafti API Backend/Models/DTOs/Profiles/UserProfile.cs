using AutoMapper;
using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Models.DTOs.Profiles
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Offer, OfferDTO>();
            CreateMap<Review, ReviewDTO>();
        }

    }
}
