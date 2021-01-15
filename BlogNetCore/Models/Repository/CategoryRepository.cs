using BlogNetCore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BlogNetCore.Models.Implementation
{
    public class CategoryRepository : ICategory
    {
        private readonly BlogDbContext db;
        public CategoryRepository(BlogDbContext context)
        {
            db = context;
        }
        public IEnumerable<Category> All()
        {
            return db.Categories.ToList();
        }       
        public Category GetOne(int id)
        {
            return db.Categories.Find(id);
        }
        
        public Category Put(int id, Category category)
        {
            if (id != category.Id)
            {
                return null;
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch 
            {
                throw;
            }

            return db.Categories.Find(id);
        }        
        public Category Post(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            
            return category;
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            db.Categories.Remove(category);
            db.SaveChanges();
        }

    }
}
