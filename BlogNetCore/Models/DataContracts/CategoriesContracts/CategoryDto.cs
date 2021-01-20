using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNetCore.Models.DataContracts.CategoriesContracts
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }



    }
}
