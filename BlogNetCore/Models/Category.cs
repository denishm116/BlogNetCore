using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlogNetCore.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        
        public Category Parent { get; set; }
        //[JsonIgnore]
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
