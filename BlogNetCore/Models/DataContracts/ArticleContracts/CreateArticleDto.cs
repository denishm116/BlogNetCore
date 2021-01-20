using Newtonsoft.Json;
using System.Collections.Generic;
//using System.Text.Json.Serialization;

namespace BlogNetCore.Models.DataContracts
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
         public List<int> Categories { get; set; } = new List<int>();
    }
}
