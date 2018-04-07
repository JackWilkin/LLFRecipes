using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recipes.Data;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class RecipeController : Controller
    {
        private Recipe currentRecipe;

        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }
        

        // GET: /Recipe/Home
        public ActionResult Home()
        {
            return View();
        }

        // GET: /Recipe/Display/
        public ActionResult Display(int recipeId)
        {
            IRecipeDBManager db = new RecipeContext();
            currentRecipe = db.GetRecipeById(recipeId);
            return View(currentRecipe);
        }
    }
}
