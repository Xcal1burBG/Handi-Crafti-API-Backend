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
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Handi_Crafti_API_Backend.Controllers
{
    [Route("users")]
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
        [Route("register")]

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


        // Login

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginInputModel input)
        {
            var loginUserDTO = await this._usersService.Login(input.UserName, input.Password);
            
            return Ok(loginUserDTO);
        }



        // Edit User profile
        [HttpPut]
        [Route("{userId}edit")]
        public async Task<IActionResult> EditUser(EditUserInputModel input)
        {
            var user = await this._usersService.EditUserById(input.UserId, input.Email, input.PhoneNumber, input.Password);

            var output = this._mapper.Map<UserDTO>(user);

            return Ok(output);
        }


    }
}
