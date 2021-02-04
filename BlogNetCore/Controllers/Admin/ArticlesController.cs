using BlogNetCore.Models;
using BlogNetCore.Extensions;
using BlogNetCore.Models.DataContracts;
using BlogNetCore.Models.DataContracts.ArticleContracts;
using BlogNetCore.Models.DataContracts.CategoriesContracts;
using BlogNetCore.Models.Interfaces;
using BlogNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlogNetCore.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        
        private readonly ArticleService _service;
        
        public ArticlesController(IArticleService service)
        {
            _service = (ArticleService)service;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public IEnumerable<ArticleDto> GetArticles()
        {
            List<ArticleDto> contracts = new List<ArticleDto>();
            List<Article> articles = (List<Article>)_service.GetArticles();
            foreach (Article article in articles)
            {
                ArticleDto a = article.ConvertArticleToArticleDto();
                contracts.Add(a);
            }
            return contracts;  
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public ActionResult<ArticleDto> GetArticle(int id)
        {
            if (!IsArticleExists(id))
            {
                throw new Exception("Article not found"); 
            }

            Article article = _service.GetArticle(id);
            return article.ConvertArticleToArticleDto();
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public ArticleDto PostArticle(CreateArticleDto createArticleDto)
        {
            Article art = new Article
            {
                Title = createArticleDto.Title,
                Description = createArticleDto.Description
            };
            List<int> categoriesId = createArticleDto.Categories;
            Article article = _service.CreateArticle(art, categoriesId);
            return article.ConvertArticleToArticleDto();
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public ArticleDto PutArticle(int id, UpdateArticleDto articleContract)
        {
            if (id != articleContract.Id)
            {
                throw new Exception("Article not found");
            }
            Article article = _service.UpdateArticle(articleContract);
            return article.ConvertArticleToArticleDto();
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public void DeleteArticle(int id)
        {
            if(!IsArticleExists(id))
            {
                throw new Exception("Article not found");
            }

            _service.DeleteArticle(id);
        }

        private bool IsArticleExists(int id)
        {
            return _service.IsArticleExists(id);
        }

    }
}
