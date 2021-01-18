using BlogNetCore.Models.Repository.UseCases;
using System.Collections.Generic;

namespace BlogNetCore.Models.Interfaces
{
    public interface IArticle
    {
        public IEnumerable<Article> All();
        public Article GetOne(int id);
        public Article Put(int id, Article article);
        public void Post(Dictionary<string, object> data);
        public void Delete(int id);
    }
}
