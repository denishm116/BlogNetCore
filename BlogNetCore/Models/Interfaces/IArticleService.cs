using BlogNetCore.Models.DataContracts.ArticleContracts;
using System.Collections.Generic;

namespace BlogNetCore.Models.Interfaces
{
    public interface IArticleService
    {
        public IEnumerable<Article> GetArticles();
        public Article GetArticle(int id);
        public Article CreateArticle(Article article, List<int> categoriesId);
        public Article UpdateArticle(UpdateArticleDto articleContract);
        public void DeleteArticle(int id);
        public bool IsArticleExists(int id);
    }
}
