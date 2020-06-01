using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.ViewModels
{
    public class RecipeCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
    }
}
