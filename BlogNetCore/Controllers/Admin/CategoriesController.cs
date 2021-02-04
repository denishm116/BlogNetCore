using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BlogNetCore.Models;
using BlogNetCore.Models.Interfaces;
using BlogNetCore.Models.DataContracts.CategoriesContracts;
using System;
using BlogNetCore.Extensions;

namespace BlogNetCore.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            List<CategoryDto> contracts = new List<CategoryDto>();
            List<Category> categories = (List<Category>)_service.GetCategories();

            foreach (Category category in categories)
            {
                CategoryDto categoryDto = category.ConvertCategoryToCategoryDto();
                
                contracts.Add(categoryDto);
            }
            return contracts;
          }

        //GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(int id)
        {
            if(IsCategoryExists(id))
            {
                throw new Exception("Category not Found");
            }
            Category category = _service.GetCategory(id);

            return category.ConvertCategoryToCategoryDto();

        }

        // POST: api/Categories
        [HttpPost]
        public CategoryDto PostCategory(CreateCategoryDto categoriesContract)
        {
            Category newCategory = new Category
            {
                Title = categoriesContract.Title,
                Description = categoriesContract.Description,
                ParentId = categoriesContract.ParentId
            };

            Category category =  _service.CreateCategory(newCategory);
            return category.ConvertCategoryToCategoryDto();
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public CategoryDto PutCategory(int id, UpdateCategoryDto categoriesContract)
        {
            if (!IsCategoryExists(id))
            {
                throw new Exception("Category not found");
            }

            Category category = _service.UpdateCategory(categoriesContract);
            return category.ConvertCategoryToCategoryDto();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            if (!IsCategoryExists(id))
            {
                throw new Exception("Catregory not found"); ;
            }
            _service.DeleteCategory(id);
        }
        private bool IsCategoryExists(int id)
        {
            return _service.IsCategoryExists(id);
        }
    }
}
