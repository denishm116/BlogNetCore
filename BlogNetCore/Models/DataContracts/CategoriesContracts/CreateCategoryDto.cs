using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore.Models.DataContracts.CategoriesContracts
{
    public class CreateCategoryDto
    {
        public int? ParentId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<int> Articles { get; set; } = new List<int>();

    }
}
