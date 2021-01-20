using BlogNetCore.Models;
using BlogNetCore.Models.DataContracts.ArticleContracts;
using BlogNetCore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogNetCore.Services
{
    public class ArticleService: IArticleService
    {
        private readonly BlogDbContext db;
        public ArticleService(BlogDbContext context)
        {
            db = context;
        }
        

        public IEnumerable<Article> GetArticles() => db.Articles.Include(a => a.Categories).ToList();
        

        public Article GetArticle(int id) => (Article)db.Articles.Include(a => a.Categories).Where(a => a.Id == id);
        

        public Article CreateArticle(Article article, List<int> categoriesId)
        {
            
            List<Category> categories = db.Categories.Where(c => categoriesId.Contains(c.Id)).ToList();

            db.Articles.Add(article);

            for(int i = 0; i < categories.Count; i++)
            {
                article.Categories.Add(categories[i]);
            }

            db.SaveChanges();

            return article;
        }

        public  Article UpdateArticle(UpdateArticleDto articleContract)
        {
            if(!IsArticleExists(articleContract.Id))
            {
                throw new Exception("Article not found"); ;
            }

            Article article = db.Articles.Find(articleContract.Id);

            db.Entry(article).State = EntityState.Modified;

            db.SaveChanges();
            
            return article;
        }

        public void DeleteArticle(int id)
        {

            if (!IsArticleExists(id))
            {
                throw new Exception("Article not found"); ;
            }

            Article article = db.Articles.Find(id);
           
            db.Articles.Remove(article);
            db.SaveChanges();
        }

        public bool IsArticleExists(int id)
        {
            return db.Articles.Any(async => async.Id == id);
        }


    }
}
