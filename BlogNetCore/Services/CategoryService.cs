using BlogNetCore.Models;
using BlogNetCore.Models.DataContracts.CategoriesContracts;
using BlogNetCore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogNetCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogDbContext db;
        public CategoryService(BlogDbContext context)
        {
            db = context;
        }

        public IEnumerable<Category> GetCategories() => db.Categories.ToList();

        public Category GetCategory(int id) => (Category)db.Categories.Find(id);

        
        public Category CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }
        public Category UpdateCategory(UpdateCategoryDto categoryContract)
        {
            if (!IsCategoryExists(categoryContract.Id))
            {
                throw new Exception("Catregory not found"); ;
            }

            Category category = db.Categories.Find(categoryContract.Id);

            db.Entry(category).State = EntityState.Modified;

            db.SaveChanges();

            return category;
        }


        public void DeleteCategory(int id)
        {
            if (!IsCategoryExists(id))
            {
                throw new Exception("Catregory not found"); ;
            }

            Category category = db.Categories.Find(id);

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public bool IsCategoryExists(int id)
        {
             return db.Categories.Any(async => async.Id == id);
        }

    }
}
