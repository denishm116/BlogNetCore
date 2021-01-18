using System.Collections.Generic;

namespace BlogNetCore.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
