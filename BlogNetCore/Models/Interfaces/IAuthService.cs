using BlogNetCore.Models.DataContracts.UserContracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore.Models.Interfaces
{
    public interface IAuthService
    {
        public Task<UserManagerResponse> RegisterUserAsync(UserRegisterDto model);
        public Task<UserManagerResponse> LoginUserAsync(UserLoginDto model);
        public Task<IdentityUser> GetUserAsync(string userId);
        public void Logout();
    }
}
