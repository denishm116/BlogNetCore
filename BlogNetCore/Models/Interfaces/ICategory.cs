using System.Collections.Generic;

namespace BlogNetCore.Models.Interfaces
{
    public interface ICategory
    {
       public IEnumerable<Category> All();
       public Category GetOne(int id);
       public Category Put(int id, Category category);
       public Category Post(Category category);
       public void Delete(int id);
    }
}
