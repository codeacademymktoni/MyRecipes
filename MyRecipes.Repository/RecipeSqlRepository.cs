using MyRecipes.Models;
using MyRecipes.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyRecipes.Repository
{
    public class RecipeSqlRepository : IRecipeRepository
    {
        public void Add(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }

        public List<Recipe> GetAll()
        {
            var result = new List<Recipe>();

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyRecipesSqlDemo; Integrated Security = true"))
            {
                cnn.Open();

                var cmd = new SqlCommand("SELECT * FROM Recipes", cnn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var recipe = new Recipe();

                    recipe.Id = reader.GetInt32(0);
                    recipe.Title = reader.GetString(1);
                    recipe.Description = reader.GetString(2);
                    recipe.ImageUrl = reader.GetString(3);
                    recipe.Ingredients = reader.GetString(4);
                    recipe.Directions = reader.GetString(5);

                    result.Add(recipe);
                }
            }

            return result;
        }

        public Recipe GetById(int id)
        {
            Recipe result = null;

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyRecipesSqlDemo; Integrated Security = true"))
            {
                cnn.Open();

                var cmd = new SqlCommand($"SELECT * FROM Recipes where id = {id}", cnn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Recipe();

                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Description = reader.GetString(2);
                    result.ImageUrl = reader.GetString(3);
                    result.Ingredients = reader.GetString(4);
                    result.Directions = reader.GetString(5);
                }
            }

            return result;
        }
    }
}
