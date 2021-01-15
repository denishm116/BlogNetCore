using System.Collections.Generic;

namespace BlogNetCore.Models.Interfaces
{
    public interface IArticle
    {
        public IEnumerable<Article> All();
        public Article GetOne(int id);
        public Article Put(int id, Article article);
        public Article Post(Article article);
        public void Delete(int id);
    }
}
