using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using Handi_Crafti_API_Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Handi_Crafti_API_Backend.Services.OffersService
{
    public class OffersService : IOffersService
    {
        private readonly ApplicationDbContext _db;

        public OffersService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Create
        public async Task<OfferDTO> CreateOffer(Guid handiCrafterId, string title, String description, String images)
        {
            var offer = new Offer
            {
                Id = Guid.NewGuid(),
                HandiCrafterId = handiCrafterId,
                Title = title,
                Description = description,
                Images = images
            };

            await this._db.Offers.AddAsync(offer);
            await this._db.SaveChangesAsync();

            var offerDTO = await this._db.Offers
                .Include(o => o.HandiCrafter)
                .Where(o => o.Id == offer.Id)
                .Select(o => new OfferDTO
                {
                    Id = o.Id,
                    HandiCrafterId = o.HandiCrafterId,
                    HandiCraftersUsername = o.HandiCrafter.UserName,
                    Title = o.Title,
                    Description = o.Description,
                    Email = o.HandiCrafter.Email,
                    PhoneNumber = o.HandiCrafter.PhoneNumber,
                    Images = o.Images
                })
                .FirstOrDefaultAsync();

#pragma warning disable CS8603 // Possible null reference return.
            return offerDTO;
#pragma warning restore CS8603 // Possible null reference return.

        }

        // Get offerDetails with reviews of the handicrafter
        [HttpGet]


        // Get by Id

        public async Task<OfferDTO> GetOfferById(Guid offerId)
        {
            var offerDTO = await _db.Offers
            .Where(x => x.Id == offerId)
            .Select(x => new OfferDTO
            {
                Id = x.Id,
                HandiCrafterId = x.HandiCrafterId,
                HandiCraftersUsername = x.HandiCrafter.UserName,
                Title = x.Title,
                Description = x.Description,
                Email = x.HandiCrafter.Email,
                PhoneNumber = x.HandiCrafter.PhoneNumber,
                Images = x.Images
            })
            .FirstOrDefaultAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return offerDTO;
#pragma warning restore CS8603 // Possible null reference return.


        }

        public async Task<IEnumerable<Offer>> GetOffersByUserId(Guid userId)
        {
            var offers = await this._db.Offers.Where(x => x.HandiCrafterId == userId).ToListAsync();

            return offers;
        }


        // Get all

        public async Task<IEnumerable<OfferDTO>> GetAllOffers()
        {
            var offerDTOs = await this._db.Offers
                .Select(x => new OfferDTO
                {
                    Id = x.Id,
                    HandiCrafterId = x.HandiCrafterId,
                    HandiCraftersUsername = x.HandiCrafter.UserName,
                    Title = x.Title,
                    Description = x.Description,
                    Email = x.HandiCrafter.Email,
                    PhoneNumber = x.HandiCrafter.PhoneNumber,                    
                    Images = x.Images
                })
                .ToListAsync();

            return offerDTOs;

  
        }


        // Edit

        public async Task<Offer> EditOffer(Guid offerId, string title, string description, string images)
        {
            var offer = await this._db.Offers.FirstOrDefaultAsync(x => x.Id == offerId);

            if (offer == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            offer.Title = title;
            offer.Description = description;
            offer.Images = images;

            await this._db.SaveChangesAsync();

            return offer;
        }


        // Delete

        public async Task<Offer> DeleteOffer(Guid offerId)
        {
            var offer = await this._db.Offers.FindAsync(offerId);

            if (offer != null)
            {
                this._db.Offers.Remove(offer);
                await this._db.SaveChangesAsync();
            }

#pragma warning disable CS8603 // Possible null reference return.
            return offer;
#pragma warning restore CS8603 // Possible null reference return.



        }
    }
}
