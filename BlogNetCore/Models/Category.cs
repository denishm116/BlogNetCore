using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        
        public Category Parent { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
