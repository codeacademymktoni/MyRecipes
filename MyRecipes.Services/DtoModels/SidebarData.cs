using MyRecipes.Data;
using System.Collections.Generic;

namespace MyRecipes.Services.DtoModels
{
    public class SidebarData
    {
        public List<SidebarRecipe> TopRecipes{ get; set; }
        public List<SidebarRecipe> RecentRecipes{ get; set; }
    }
}
