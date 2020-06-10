using System;

namespace MyRecipes.Services.DtoModels
{
    public class SidebarRecipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int Views { get; set; }
    }
}
