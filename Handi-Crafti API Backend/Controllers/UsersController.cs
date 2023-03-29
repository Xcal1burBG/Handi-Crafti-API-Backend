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
using Handi_Crafti_API_Backend.Services.UsersService;
using Handi_Crafti_API_Backend.Models.DTOs;

namespace Handi_Crafti_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
           
            _usersService = usersService;
            _mapper = mapper;
        }


        // Create User
        [HttpPost]
        [Route("/register")]

        public async Task<IActionResult> CreateUser(UserDTO input)
        {
            var user = await this._usersService.CreateUser(input.Username, input.Email, input.AvatarImage);
            var output = this._mapper.Map<UserDTO>(user);


            return Ok(output);

        }


    }
}
