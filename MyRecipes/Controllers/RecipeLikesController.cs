using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;

namespace MyRecipes.Controllers
{
    [Authorize]
    public class RecipeLikesController : Controller
    {
        private readonly IRecipeLikesService recipeLikesService;

        public RecipeLikesController(IRecipeLikesService recipeLikesService)
        {
            this.recipeLikesService = recipeLikesService;
        }

        [HttpPost]
        public IActionResult Like([FromBody]RecipeLikeRequestModel request)
        {
            var userId = Convert.ToInt32(User.FindFirst("Id").Value);
            recipeLikesService.AddLike(request.RecipeId, userId);
            return Ok();
        }


        [HttpPost]
        public IActionResult RemoveLike([FromBody]RecipeLikeRequestModel request)
        {
            var userId = Convert.ToInt32(User.FindFirst("Id").Value);
            recipeLikesService.RemoveLike(request.RecipeId, userId);
            return Ok();
        }


        [HttpPost]
        public IActionResult Dislike([FromBody]RecipeLikeRequestModel request)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult RemoveDislike([FromBody]RecipeLikeRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}