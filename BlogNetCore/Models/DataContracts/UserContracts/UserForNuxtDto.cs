using Microsoft.AspNetCore.Identity;

namespace BlogNetCore.Models.DataContracts.UserContracts
{
    public class UserForNuxtDto
    {
        public IdentityUser User { get; set; }
    }
}
