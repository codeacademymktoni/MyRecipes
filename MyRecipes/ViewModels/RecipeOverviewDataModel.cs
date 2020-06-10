using MyRecipes.Services.DtoModels;
using System.Collections.Generic;

namespace MyRecipes.ViewModels
{
    public class RecipeOverviewDataModel
    {
        public List<RecipeOverviewModel> Recipes { get; set; }
        public SidebarData SidebarData { get; set; }
    }
}
