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
        Recipe chocolateCake;

        private void GenerateTestData() { 
            Ingredient Apple = new Ingredient(0, "Whole Apples", 1.5, Unit.Self);
            Ingredient Sugar = new Ingredient(1, "Sugar", 1, Unit.Cup);
            Ingredient Cinnamon = new Ingredient(2, "Cinnamon", 2, Unit.Tbs);
            Ingredient Salt = new Ingredient(3, "Salt", .5, Unit.tsp);

            Utensil whisk = new Utensil(0, "Whisk", "Whisk it");
            Utensil bowl = new Utensil(1, "Bowl", "Stir in it");

            List<Ingredient> ingredientsAC = new List<Ingredient> { Apple, Sugar, Cinnamon, Salt };
            List<Utensil> utensils = new List<Utensil> { whisk, bowl };

            this.appleCrisp = new Recipe(0, "Apple Crisp", ingredientsAC, utensils, 350,
                        "Whisk it all in a bowl", false);

            Ingredient butter = new Ingredient(0, "Butter", 1.5, Unit.Cup);
            Ingredient sugar = new Ingredient(1, "Sugar", 1, Unit.Cup);
            Ingredient chocolate = new Ingredient(2, "Chocolate", 2, Unit.Tbs);
            Ingredient salt = new Ingredient(3, "Salt", .5, Unit.tsp);
            List<Ingredient> ingredientsCC = new List<Ingredient>(new Ingredient[] { butter, sugar, chocolate, salt });


            this.chocolateCake = new Recipe(1, "Chocolate Cake", ingredientsCC, new List<Utensil>(), 170, "Whisk it all in a bowl", true);
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
        public void TestToString()
        {
            GenerateTestData();
            Recipe testAppleCrisp = appleCrisp.Clone();
            Recipe testChocolateCake = chocolateCake.Clone();
            Assert.AreEqual("Recipe: Apple Crisp \nOven Heat: 350° Fahrenheit\nUtensils: Whisk, Bowl \n" +
                    "Instructions: Whisk it all in a bowl \nIngredients: 1.5  Whole Apples, 1 Cup Sugar, " +
                            "2 Tablespoon Cinnamon, 0.5 Teaspoon Salt", testAppleCrisp.ToString());
            
            testChocolateCake.ScaleRecipe(2);

            Assert.AreEqual("Recipe: Chocolate Cake \nOven Heat: 170° Celsius\nUtensils:  \n"+
                    "Instructions: Whisk it all in a bowl \nIngredients: 3 Cup Butter, 2 Cup Sugar, " +
                            "4 Tablespoon Chocolate, 1 Teaspoon Salt", testChocolateCake.ToString());
        }

        [Test]
        public void TestCelsiusFahrenheit()
        {
            GenerateTestData();
            Recipe testAppleCrisp = appleCrisp.Clone();
            Recipe testChocolateCake = chocolateCake.Clone();

            Assert.AreEqual(350, testAppleCrisp.OvenHeat, "Apple Crisp OvenHeat is 350");
            Assert.AreEqual(false, testAppleCrisp.IsCelsius, "Apple Crisp is in F");

            Assert.AreEqual(350, testAppleCrisp.Fahrenheit, "Apple Crisp is 350 F");
            Assert.AreEqual(177, testAppleCrisp.Celsius, "Apple Crisp is 177 C");

            Assert.AreEqual(170, testChocolateCake.OvenHeat, "Chocolate Cake OvenHeat is 170");
            Assert.AreEqual(true, testChocolateCake.IsCelsius, "Apple Crisp is in C");

            Assert.AreEqual(338, testChocolateCake.Fahrenheit, "Chocolate Cake is 338 F");
            Assert.AreEqual(170, testChocolateCake.Celsius, "Chocolate Cake is 170 C");
        }
    }
}


