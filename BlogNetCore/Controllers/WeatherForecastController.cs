using BlogNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private BlogDbContext db;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(BlogDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
          

            //User user1 = new User { Email = "Tom@bom.be", Password = "1234", Role = "user" };
            //User user2 = new User { Email = "jake@bom.be", Password = "1234", Role = "admin" };

            //db.Users.AddRange(user1, user2);
            //db.SaveChanges();
            
            //Category cat1 = new Category { Title = "Первая категория", Description = "Описание первой категории", Parent = null };
            //Category cat2 = new Category { Title = "Вторая категория", Description = "Описание второй категории", Parent = null };
        
            //db.Categories.AddRange(cat1, cat2);
            //db.SaveChanges();
            
            
            List<User> users = db.Users.ToList();
            return (IEnumerable<User>)users;

            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
