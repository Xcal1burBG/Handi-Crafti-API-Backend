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

        //[HttpGet]
        //public async Task<IActionResult> GetAllReviews()
        //{

           
        //}

    }
}
