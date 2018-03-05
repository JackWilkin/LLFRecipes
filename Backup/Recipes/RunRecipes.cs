using System;
using System.Collections.Generic;
using Recipes.Models;

namespace Recipes
{
    public class RunRecipes
    {
        static void Main() 
        {

            Ingredient apple = new Ingredient(0, "Whole Apples", 1.5, Unit.Self);
            Ingredient sugar = new Ingredient(1, "Sugar", 1, Unit.Cup);
            Ingredient cinnamon = new Ingredient(2, "Cinnamon", 2, Unit.Tbs);
            Ingredient salt = new Ingredient(3, "Salt", .5, Unit.tsp);
            List<Ingredient> ingredients = new List<Ingredient>(new Ingredient[] { apple, sugar, cinnamon, salt });

            Utensil whisk = new Utensil(0, "Whisk", "Whisk it");
            Utensil bowl = new Utensil(1, "Bowl", "Stir in it");
            List<Utensil> utensils = new List<Utensil>(new Utensil[] { whisk, bowl });

            Recipe appleCrisp = new Recipe(0, "Apple Crisp", ingredients, utensils, 350, "Whisk it all in a bowl", false);
            Console.WriteLine(appleCrisp.ToString());
        }
    }
}
