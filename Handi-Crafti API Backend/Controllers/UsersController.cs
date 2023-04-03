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
using Handi_Crafti_API_Backend.Models.InputModels;

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

        public async Task<IActionResult> CreateUser(CreateUserInputModel input)
        {
            var user = new User();

            if (input.Password == input.Repass)
            {
                user = await this._usersService.CreateUser(input.UserName, input.Email, input.PhoneNumber, input.Password);
            }
            var output = this._mapper.Map<UserDTO>(user);

            return Ok(output);

        }


    }
}
