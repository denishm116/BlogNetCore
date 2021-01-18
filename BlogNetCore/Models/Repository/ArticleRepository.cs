using BlogNetCore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

using BlogNetCore.Models.Repository.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace BlogNetCore.Models.Repository
{
    public class ArticleRepository : IArticle
    {
        private readonly BlogDbContext db;
        public ArticleRepository(BlogDbContext context)
        {
            db = context;
        }
        public IEnumerable<Article> All()
        {
            return db.Articles.Include(a=>a.Categories).ToList();
        }

        public Article GetOne(int id)
        {
            return (Article)db.Articles.Include(a => a.Categories).Where(a => a.Id == id);
        }

        public void Post(Dictionary<string, object> data)
        {
            var dstr = data["Article"];
            var title = dstr.ToString();
            //Article article = (Article)data["Article"];



            //string json = JsonSerializer.Serialize<Article>(dstr);
            //var article = JsonSerializer.Deserialize<Article>(dstr);



            //foreach (var a in article)
            //{

            //}

            db.Articles.ToList();

            //foreach (Category category in categories.ToList())
            //{
            //    article.Categories.Add(category);
            //}

            //db.SaveChanges();
            //return article;

        }

        public Article Put(int id, Article article)
        {
            if (id != article.Id)
            {
                return null;
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw;
            }

            return db.Articles.Find(id);
        }


        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            db.Articles.Remove(article);
            db.SaveChanges();
        }
    }
}
