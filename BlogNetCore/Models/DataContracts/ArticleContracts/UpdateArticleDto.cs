using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlogNetCore.Models.DataContracts.ArticleContracts
{
    public class UpdateArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<int> Categories { get; set; } = new List<int>();
    }
}
