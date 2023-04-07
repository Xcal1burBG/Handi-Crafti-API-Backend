using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using AutoMapper;
using Handi_Crafti_API_Backend.Services.ReviewsService;
using Handi_Crafti_API_Backend.Services.OffersService;
using Handi_Crafti_API_Backend.Models.InputModels;
using Handi_Crafti_API_Backend.Models.DTOs;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Handi_Crafti_API_Backend.Models.OutputModels;

namespace Handi_Crafti_API_Backend.Controllers
{
    [Route("offers")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersService _offersService;
        private readonly IMapper _mapper;

        public OffersController(IOffersService offersService, IMapper mapper)
        {
            _offersService = offersService;
            _mapper = mapper;
        }


        // Create 

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOffer(CreateOfferInputModel input)
        {

            var offerDTO = await this._offersService.CreateOffer(input.HandiCrafterId, input.Title, input.Description, input.Images);

                       return Ok(offerDTO);

        }


        // Get all offers

        [HttpGet]
        [Route("catalog")]
        public async Task<IActionResult> GetAllOffers()
        {
            var offerDTOs = await this._offersService.GetAllOffers();

            return Ok(offerDTOs);
        }


        // Get offers by UserId
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetOffersByUserId(Guid userId)
        {
            var offers = await this._offersService.GetOffersByUserId(userId);
            var output = this._mapper.Map<IEnumerable<OfferDTO>>(offers);

            return Ok(output);
        }


        // Get offer By id

        [HttpGet]
        [Route("details/{offerId}")]

        public async Task<IActionResult> GetOfferById(Guid offerId)
        {
            var offer = await this._offersService.GetOfferById(offerId);
            var output = this._mapper.Map<OfferDTO>(offer);
           

            return Ok(output);
        }



        // Edit

        [HttpPut]
        [Route("{id}/edit")]
        public async Task<IActionResult> EditOffer(EditOfferInputModel input)
        {
            var offer = await this._offersService.EditOffer(input.Id, input.Title, input.Description, input.Images);
            var output = this._mapper.Map<OfferDTO>(offer);

            return Ok(output);

        }

        // Delete
        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteOffer(Guid offerId)
        {
            await this._offersService.DeleteOffer(offerId);
            return Ok();
        }


    }
}
