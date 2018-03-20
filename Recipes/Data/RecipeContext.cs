using System;
using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.Data
{
    public class RecipeContext : IRecipeDBManager
    {

        public static string Get(string uri)
        {
            var client = new RestClient(uri);
            var json = client.MakeRequest();

            return json;
        }

        public List<Recipe> GetFullListRecipes() {
            string recipeList = Get(DataUtils.DB_ROOT_ADDRESS + "recipe");
            return DataUtils.JsonToList<Recipe>(recipeList);
        }

        public Recipe GetRecipeById(int recipeId) {
            string recipeQuery = DataUtils.DB_ROOT_ADDRESS + "recipe?q={\"RecipeId\":"+recipeId+"}";
            string recipeListJson = Get(recipeQuery);
            List<Recipe> recipeAsList = DataUtils.JsonToList<Recipe>(recipeListJson);

            string ingredientQuery = DataUtils.DB_ROOT_ADDRESS + "ingredient?q={\"RecipeId\":"+recipeId+"}";
            string ingredientListJson = Get(ingredientQuery);
            string ingredientListJsonParsable = ingredientListJson.Replace("[\"", "\"").Replace("\"]", "\"");                                         
            List<Ingredient> ingredientsAsList = DataUtils.JsonToList<Ingredient>(ingredientListJsonParsable);

            string toolsQuery = DataUtils.DB_ROOT_ADDRESS + "tools?q={\"RecipeId\":" + recipeId + "}&h={\"$fields\":{\"UtensilId\":1}}";
            string utensilsIdsJson = Get(toolsQuery);
            List<Utensil> utensilsAsList = new List<Utensil>();

            if (!utensilsIdsJson.Equals("[]")) {
                string utensilsQuery = DataUtils.DB_ROOT_ADDRESS + "utensil?q={\"$or\":" + utensilsIdsJson + "}";
                string utensilLisstJson = Get(utensilsQuery);
                utensilsAsList = DataUtils.JsonToList<Utensil>(utensilLisstJson);
            }
           
            if (recipeAsList.Count > 1)
            {
                throw new Exception("There are more than one recipe with that RecipeId");
            }
            else if (recipeAsList.Count == 0)
            {
                return null;
            }
            else
            {
                recipeAsList[0].Ingredients = ingredientsAsList;
                recipeAsList[0].Utensils = utensilsAsList;
                return recipeAsList[0];
            }
        }

        public Recipe GetRecipeByTitle(string recipeTitle) {
            string queryString = DataUtils.DB_ROOT_ADDRESS + "recipe?q={\"RecipeTitle\":\""+recipeTitle + "\"}";
            string recipeListJson = Get(queryString);
            List<Recipe> recipeAsList = DataUtils.JsonToList<Recipe>(recipeListJson);

            if (recipeAsList.Count > 1)
            {
                throw new Exception("There are more than one recipe with that RecipeTitleS");
            }
            else if (recipeAsList.Count == 0)
            {
                return null;
            }
            else
            {
                return recipeAsList[0];
            }
        }


        ///////////////////Private Methods//////////////////





    }
}
