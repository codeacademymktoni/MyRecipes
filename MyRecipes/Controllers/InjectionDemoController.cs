using Microsoft.AspNetCore.Mvc;
using MyRecipes.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyRecipes.Controllers
{
    public class InjectionDemoController : Controller
    {
        public IActionResult Index(string name)
        {
            var injectionModels = new List<InjectionModel>();

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyRecipesSqlDemo; Integrated Security = true"))
            {
                cnn.Open();
                var query = "select * from InjectionDemo";

                if(name != null)
                {
                    query = $"{query} where name = @Name";
                }

                var cmd = new SqlCommand(query, cnn);

                if(name != null)
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                }


                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var injectionModel = new InjectionModel();
                    injectionModel.Id = reader.GetInt32(0);
                    injectionModel.Name = reader.GetString(1);
                    injectionModels.Add(injectionModel);
                }
            }

            return View(injectionModels);
        }
    }
}