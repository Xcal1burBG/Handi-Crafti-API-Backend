using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using Handi_Crafti_API_Backend.Services.ReviewsService;
using AutoMapper;
using Handi_Crafti_API_Backend.Models.InputModels;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using Handi_Crafti_API_Backend.Models.DTOs;

namespace Handi_Crafti_API_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase

    {
        private readonly IReviewsService _reviewsService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewsService reviewsService, IMapper mapper)
        {

            _reviewsService = reviewsService;
            _mapper = mapper;
        }


        // Create review
        [HttpPost]
        [Route("/postreview")]

        public async Task<IActionResult> CreateReview(CreateReviewInputModel input)
        {
            var review = await this._reviewsService.CreateReview(input.Value, input.Text, input.HandiCrafterId, input.CustomerId);

            var output = this._mapper.Map<ReviewDTO>(review);
            return Ok(output);

        }
        

    }
}
