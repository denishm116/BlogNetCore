using BlogNetCore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json;

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
            List<Article> articles = db.Articles.Include(a=>a.Categories).ToList();
            return articles;
        }

        public Article GetOne(int id)
        {
            return (Article)db.Articles.Include(a => a.Categories).Where(a => a.Id == id);
        }

        public Article Post(Dictionary<string, object> data)
        {
            var options = new JsonSerializerOptions()
            {
                MaxDepth = 0,
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };
            var serializedArticle = @data["Article"].ToString().Replace("\"", "\'");
            Article article = JsonConvert.DeserializeObject<Article>(serializedArticle);

            var serilizaedCategories = @data["Categories"].ToString().Replace("\"", "\'");
            var serilizaedCategoriesTrimmed = serilizaedCategories.Substring(1, serilizaedCategories.Length - 2);
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(serilizaedCategoriesTrimmed);



            db.Articles.Add(article);

            foreach(Category cat in categories)
            {
                article.Categories.Add(cat);
            }

            db.SaveChanges();


            return article;

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
