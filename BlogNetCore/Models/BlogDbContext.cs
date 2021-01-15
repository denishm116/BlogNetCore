using Microsoft.EntityFrameworkCore;
using System;

namespace BlogNetCore.Models
{
    public class BlogDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
