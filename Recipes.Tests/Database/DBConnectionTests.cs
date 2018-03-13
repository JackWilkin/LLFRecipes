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
        public void TestGetAllRecipes()
        {
            string recipes = RecipeContext.GetAllRecipes();
            Assert.AreEqual(recipes, "[{\"_id\":\"5aa5a36e5eff707300007bed\",\"RecipeTitle\":\"Apple " +
                            "Crisp\",\"OvenHeat\":350,\"RecipeId\":0,\"IsCelsius\":false,\"RecipeInstructions\"" +
                            ":\"Whisk it all in a bowl\"},{\"_id\":\"5aa5a3c85eff707300007bf0\",\"RecipeTitle\":\"Chocolate " +
                            "Cake\",\"OvenHeat\":170,\"RecipeId\":1,\"IsCelsius\":true,\"RecipeInstructions\"" +
                            ":\"Put it in a bowl, and whisk it\"}]");
        }

        [Test]
        public void TestJsonListToRecipeList()
        {
            string recipes = RecipeContext.GetAllRecipes();

            Assert.AreEqual(RecipeContext.JsonListToRecipeList(recipes), new List<Recipe>());
        }
    }
}
