using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Recipes.Models;

namespace Recipes.Data
{
    public class RecipeContext : IRecipeDBManager
    {

        public static string Get(string uri)
        {
            string endPoint = uri;
            var client = new RestClient(endPoint);
            var json = client.MakeRequest();

            return json;
        }

        public static string GetAllRecipes() {
            return Get(DataUtils.DB_ROOT_ADDRESS + "recipe");
        }

        List<Recipe> GetFullListRecipes() {
            string recipeList = GetAllRecipes();
            return DataUtils.JsonToList<Recipe>(recipeList);
        }

        Recipe GetListRecipeById(int recipeId) {
            return Get("https://llfrecipes-6c4b.restdb.io/rest/recipe?q={%22RecipeId%22:1}");
        }

        Recipe GetListRecipeByTitle(string recipeTitle) {
            return Get("https://llfrecipes-6c4b.restdb.io/rest/recipe");
        }

        ///////////////////Private Methods//////////////////

    }
}
