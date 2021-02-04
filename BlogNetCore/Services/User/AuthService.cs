using BlogNetCore.Models.DataContracts.UserContracts;
using BlogNetCore.Models.Interfaces;
using BlogNetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogNetCore.Services.User
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private IMailService _mailService;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager/*IMailService mailService*/)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            //_mailService = mailService;
        }

        public async Task<UserManagerResponse> LoginUserAsync(UserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Token = "There is no user with that Email address",
                    Success = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Token = "Invalid password",
                    Success = false,
                };

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Token = tokenAsString,
                Success = true,
                User = user
                //ExpireDate = token.ValidTo
            };
        }

        public async Task<UserManagerResponse> RegisterUserAsync(UserRegisterDto model)
        {
            if (model == null)
                throw new NullReferenceException("Register model is null");

            if (model.Password != model.PasswordConfirm)
            {
                return new UserManagerResponse
                {
                    Token = "Password or email is wrong",
                    Success = false
                };
            }

            var user = new IdentityUser { Email = model.Email, UserName = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Token = "User Created",
                    Success = true
                };
            }

            return new UserManagerResponse
            {
                Token = "User didn't Created",
                Success = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        public async Task<IdentityUser> GetUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new NullReferenceException("Incorrect User Id");
            }
            IdentityUser user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async void Logout() => await _signInManager.SignOutAsync();
    }
}
