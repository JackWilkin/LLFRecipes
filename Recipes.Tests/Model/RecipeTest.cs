using System.Collections.Generic;
using Recipes.Models;
using NUnit.Framework;
using System.Linq;

namespace Recipes.Tests.Model
{
    [TestFixture]
    public class RecipeTest
    {
        Recipe appleCrisp;

        private void GenerateTestData() { 
            Ingredient Apple = new Ingredient(0, "Whole Apples", 1.5, Unit.Self);
            Ingredient Sugar = new Ingredient(1, "Sugar", 1, Unit.Cup);
            Ingredient Cinnamon = new Ingredient(2, "Cinnamon", 2, Unit.Tbs);
            Ingredient Salt = new Ingredient(3, "Salt", .5, Unit.tsp);

            Utensil whisk = new Utensil(0, "Whisk", "Whisk it");
            Utensil bowl = new Utensil(1, "Bowl", "Stir in it");

            List<Ingredient> ingredients = new List<Ingredient> { Apple, Sugar, Cinnamon, Salt };
            List<Utensil> utensils = new List<Utensil> { whisk, bowl };

            this.appleCrisp = new Recipe(0, "Apple Crisp", ingredients, utensils, 350,
                        "Whisk it all in a bowl", false);
        }

        [Test]
        public void TestScaler()
        {
            GenerateTestData();
            Recipe testAppleCrisp = appleCrisp.Clone();
            List<double> initialQuantities = new List<double>(testAppleCrisp.Ingredients.Select(i => i.Quantity));

            for (int i = 0; i < initialQuantities.Count; i++) {
                Assert.AreEqual(testAppleCrisp.Ingredients[i].Quantity, initialQuantities[i], .01);
            }

            testAppleCrisp.ScaleRecipe(.5);

            Assert.AreEqual(testAppleCrisp.Ingredients[0].Quantity, .75, .01);

            for (int i = 0; i < initialQuantities.Count; i++)
            {
                Assert.AreEqual(testAppleCrisp.Ingredients[i].Quantity, initialQuantities[i]*.5, .01);
            }

        }
        [Test]
        public void TestCovertTemperature()
        {
            GenerateTestData();
            Recipe testAppleCrisp = appleCrisp.Clone();

            Assert.AreEqual(testAppleCrisp.OvenHeat, 350);
            Assert.AreEqual(testAppleCrisp.IsCelsius, false);

            testAppleCrisp.ConvertTemperature();

            Assert.AreEqual(testAppleCrisp.OvenHeat, 177);
            Assert.AreEqual(testAppleCrisp.IsCelsius, true);

            testAppleCrisp.ConvertTemperature();

            Assert.AreEqual(testAppleCrisp.OvenHeat, 350);
            Assert.AreEqual(testAppleCrisp.IsCelsius, false);
        }

        [Test]
        public void TestToString()
        {
            GenerateTestData();
            Recipe testAppleCrisp = appleCrisp.Clone();
            Assert.AreEqual("Recipe: Apple Crisp \nOven Heat: 350° Fahrenheit\nUtensils: Whisk, Bowl \n" +
                    "Instructions: Whisk it all in a bowl \nIngredients: 1.5  Whole Apples, 1 Cup Sugar, " +
                            "2 Tablespoon Cinnamon, 0.5 Teaspoon Salt", testAppleCrisp.ToString());

            testAppleCrisp.ConvertTemperature();
            testAppleCrisp.ScaleRecipe(2);

            Assert.AreEqual("Recipe: Apple Crisp \nOven Heat: 177° Celsius\nUtensils: Whisk, Bowl \n" +
                    "Instructions: Whisk it all in a bowl \nIngredients: 3  Whole Apples, 2 Cup Sugar, " +
                            "4 Tablespoon Cinnamon, 1 Teaspoon Salt", testAppleCrisp.ToString());
        }
    }
}


