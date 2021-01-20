using BlogNetCore.Models.DataContracts.CategoriesContracts;
using System.Collections.Generic;

namespace BlogNetCore.Models.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategory(int id);
        public Category CreateCategory(Category category);
        public Category UpdateCategory(UpdateCategoryDto categoryContract);
        public void DeleteCategory(int id);
        public bool IsCategoryExists(int id);
    }
}
