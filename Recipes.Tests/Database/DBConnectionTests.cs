﻿using System.Collections.Generic;

using NUnit.Framework;

using Recipes.Models;
using Recipes.Data;

namespace Recipes.Tests.Database
{
    [TestFixture]
    public class DBConnectionTests
    {

        [Test]
        public void TestGetFullListRecipes()
        {
            IRecipeDBManager db = new RecipeContext();
            List<Recipe> recipes = db.GetFullListRecipes();

            Assert.NotNull(recipes);
            Assert.AreEqual(recipes.Count, 2);
        }

        [Test]
        public void TestGetRecipeById()
        {
            IRecipeDBManager db = new RecipeContext();
            Recipe recipe = db.GetRecipeById(1);

            Assert.NotNull(recipe);
            Assert.NotNull(recipe.Ingredients);
            Assert.NotNull(recipe.Utensils);
            Assert.AreEqual(recipe.RecipeId, 1);
            Assert.AreEqual(recipe.Utensils.Count, 0);
            Assert.AreEqual(recipe.Ingredients.Count, 4);

            recipe = db.GetRecipeById(0);
            Assert.NotNull(recipe);
            Assert.NotNull(recipe.Ingredients);
            Assert.NotNull(recipe.Utensils);
            Assert.AreEqual(recipe.RecipeId, 0);
            Assert.AreEqual(recipe.Utensils.Count, 2);
            Assert.AreEqual(recipe.Ingredients.Count, 4);

            Recipe notARecipe = db.GetRecipeById(-1);
            Assert.IsNull(notARecipe);
        }

        [Test]
        public void TestGetRecipeByTitle()
        {
            IRecipeDBManager db = new RecipeContext();
            Recipe recipe = db.GetRecipeByTitle("Apple Crisp");

            Assert.NotNull(recipe);
            Assert.AreEqual(recipe.RecipeTitle, "Apple Crisp");
            Assert.Null(recipe.Ingredients);
            Assert.Null(recipe.Utensils);

            Recipe notARecipe = db.GetRecipeByTitle("Not a recipe name");
            Assert.IsNull(notARecipe);
        }
    }
}
