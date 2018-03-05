using System.Web.Http;
using Recipes.Models;
using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class RecipeApiController : ApiController
    {
        
        public Recipe GetRecipe()
        {
            return Recipe.AppleCrisp();
        }

        [HttpPost]
        public JsonResult Create()
        {
            return Json("Response from Create");
        }
    }
}
