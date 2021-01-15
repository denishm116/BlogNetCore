using BlogNetCore.Models;
using BlogNetCore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogNetCore.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticle _article;
        public ArticlesController(IArticle article)
        {
            _article = article;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public IEnumerable<Article> GetArticles()
        {
            return _article.All();
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public ActionResult<Article> GetArticle(int id)
        {
            return _article.GetOne(id);
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public Article PostArticle(Article article)
        {

            return _article.Post(article);
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public Article PutArticle(int id, Article article)
        {
            return _article.Put(id, article);
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public void DeleteArticle(int id)
        {
            _article.Delete(id);
        }
    }
}
