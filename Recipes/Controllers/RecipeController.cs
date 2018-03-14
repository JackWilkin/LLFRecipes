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
        // GET: Recipe
        public ActionResult Index()
        {
            return View();//db.Recipes.ToList());
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
            Recipe recipe = db.GetRecipeById(recipeId);
            return View(recipe);
        }
    }
}
