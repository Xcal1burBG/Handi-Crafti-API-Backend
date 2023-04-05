using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Handi_Crafti_API_Backend;
using Handi_Crafti_API_Backend.Models.DTOs;
using System.Configuration;

namespace Handi_Crafti_API_Backend.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _db;
        private IConfiguration Configuration;

        public UsersService(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            Configuration = configuration;
        }


        // Create

        public async Task<User> CreateUser(String username, String email, String phoneNumber, string password)
        {

            var hasher = new PasswordHasher<User>();


            var user = new User();

            user.Id = Guid.NewGuid();
            user.UserName = username;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);


            await this._db.Users.AddAsync(user);
            await this._db.SaveChangesAsync();

            return user;

        }


        // Login
        public async Task<LoginUserDTO> Login(String userName, String password)
        {
            var user = await this._db.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            Console.WriteLine(user);

            if (user == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }


            var hashedPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (hashedPassword)
            {
                var token = this.GenerateToken(user);
                var loginUserDTO = new LoginUserDTO();
                loginUserDTO.Id = user.Id;
                loginUserDTO.UserName = user.UserName;
                loginUserDTO.PhoneNumber = user.PhoneNumber;
                loginUserDTO.Email = user.Email;
                loginUserDTO.Token = token;

                return loginUserDTO;

            }

#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.

        }


        // Generating token

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSettings:Key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        // Get User by Id

        public async Task<User> GetUserById(Guid userId)
        {
            var user = await this._db.Users.FirstOrDefaultAsync(x => x.Id == userId);

#pragma warning disable CS8603 // Possible null reference return.
            return user;
#pragma warning restore CS8603 // Possible null reference return.
        }


        // Edit

        public async Task<User> EditUserById(Guid userId, string email, string phoneNumber, string password)
        {
            var user = await this._db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            return user;

        }



    }
}
