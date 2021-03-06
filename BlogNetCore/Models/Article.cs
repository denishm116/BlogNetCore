﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

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
