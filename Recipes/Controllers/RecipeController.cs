using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recipes.Data;
using Recipes.Models;
using Recipes.Cache;
using System.Runtime.Caching;

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
            //GlobalCachingProvider.Instance.Dispose();
            return View();
        }
        
        // GET: /Recipe/Display/
		public ActionResult Display(int recipeId, double scaler = 1, bool? isCelsius = null)
        {
            string key = recipeId.ToString();
            if (GlobalCachingProvider.Instance.IsCached(key)) {
                //This casting is bad should fix later on down the road
                currentRecipe = (Recipe) GlobalCachingProvider.Instance.GetItem(key);
            }
            else {
                IRecipeDBManager db = new RecipeContext();
                currentRecipe = db.GetRecipeById(recipeId);
				GlobalCachingProvider.Instance.AddItem(key, currentRecipe);
            }

			RecipeViewModel viewModel;
			if (isCelsius == null) {
				viewModel = new RecipeViewModel(currentRecipe.ScaleRecipe(scaler), scaler);
			}
			else {
				viewModel = new RecipeViewModel(currentRecipe.ScaleRecipe(scaler), scaler, (bool)isCelsius);
			}
			 
            
			return View(viewModel);
        }
                                                
        // GET: /Recipe/_Ingredients/
        [HttpGet]
        public ActionResult _Ingredients()
        {

            //List<Ingredient> model = ingredients;
            return PartialView("Recipe/_Ingredients");
        }
    }
}
