using BlogNetCore.Models;
using BlogNetCore.Models.DataContracts.CategoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore.Extensions
{
    public static class ConvertToCategoryDto
    {
        public static CategoryDto ConvertCategoryToCategoryDto(this Category category)
        {
            if(category == null)
            {
                throw new Exception("Category not found");
            }

            CategoryDto categoryDto = new CategoryDto
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                ParentId = category.ParentId
            };

            return categoryDto;
        }
    }
}
