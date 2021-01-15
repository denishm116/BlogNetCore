using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BlogNetCore.Models;
using BlogNetCore.Models.Interfaces;

namespace BlogNetCore.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _category.All();
        }

        //GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
           return _category.GetOne(id);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public Category PutCategory(int id, Category category)
        {
            return _category.Put(id, category);
        }

        // POST: api/Categories
        [HttpPost]
        public Category PostCategory(Category category)
        {
            
            return _category.Post(category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _category.Delete(id);
        }

    }
}
