using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BlogNetCore.Models.DataContracts.UserContracts
{
    public class UserManagerResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public IdentityUser User { get; set; }
    }
}
