using System;
using Recipes.Models;
using NUnit.Framework;
using Recipes.Data;
using System.Collections.Generic;

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
            Assert.AreEqual(recipe.RecipeId, 1);

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

            Recipe notARecipe = db.GetRecipeByTitle("Not a recipe name");
            Assert.IsNull(notARecipe);
        }
    }
}
