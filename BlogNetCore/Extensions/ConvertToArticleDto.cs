using BlogNetCore.Models;
using BlogNetCore.Models.DataContracts.ArticleContracts;
using BlogNetCore.Models.DataContracts.CategoriesContracts;
using System;

namespace BlogNetCore.Extensions
{
    public static class ConvertToArticleDto
    {
        public static ArticleDto ConvertArticleToArticleDto(this Article article)
        {
            if (article is null)
            {
                throw new Exception("Article not found");
            }

            ArticleDto articleDto = new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description
            };
            foreach (Category category in article.Categories)
            {
                CategoryDto categoryDto = new CategoryDto
                {
                    Id = category.Id,
                    Description = category.Description,
                    Title = category.Title,
                    ParentId = category.ParentId
                };
                articleDto.Categories.Add(categoryDto);
            }

            return articleDto;
        }
    }
}
