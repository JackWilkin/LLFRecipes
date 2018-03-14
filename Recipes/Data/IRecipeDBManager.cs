using System;
using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.Data
{
    public interface IRecipeDBManager
    {
        List<Recipe> GetFullListRecipes();

        Recipe GetRecipeById(int recipeId);

        Recipe GetRecipeByTitle(string recipeTitle);

    }
}
