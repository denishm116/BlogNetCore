using BlogNetCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(BlogDbContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                            {
                                new User
                                    {
                                        
                                        UserName = "denishm116",
                                        Email = "denishm116@test.com"
                                    },

                                new User
                                    {
                                        
                                        UserName = "denishm117",
                                        Email = "denishm117@test.com"
                                    }
                              };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "qwe123");
                }
            }
        }
    }
}
