﻿using System;
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
        [Route("/create")]
        public async Task<IActionResult> CreateOffer(CreateOfferInputModel input)
        {

            var offer = await this._offersService.CreateOffer(input.HandiCrafterId, input.Title, input.Description, input.Images);

            var output = this._mapper.Map<OfferDTO>(offer);

            return Ok(output);

        }


        ////// Get 

        //[HttpGet]

        ////[HttpGet]
        ////[Route("/create")]
        ////public async Tasko

        //// Edit

        //[Route("{id}/edit")]


        //// Delete 
        //[Route("{id}/edit")]

    }
}
