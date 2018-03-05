using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Recipes.Models
{
    public class Recipe
    {
        int RecipeId;
        string RecipeTitle;
        List<Ingredient> Ingredients;
        List<Utensil> Utensils;
        int OvenHeat;
        bool IsCelsius;
        string RecipeInstructions;

        public Recipe(int recipeId, String recipeTitle, List<Ingredient> ingredients, List<Utensil> utensils, int ovenHeat,
               String recipeInstructions, bool isCelsius)
        {
            this.RecipeId = recipeId;
            this.RecipeTitle = recipeTitle;
            this.Ingredients = ingredients;
            this.Utensils = utensils;
            this.OvenHeat = ovenHeat;
            this.RecipeInstructions = recipeInstructions;
            this.IsCelsius = isCelsius;
        }

        private string GetDegree()
        {
            if (IsCelsius)
            {
                return "Celsius";
            }
            else
            {
                return "Fahrenheit";
            }
        }

        public void ConvertTemperature()
        {
            if (IsCelsius)
            {
                OvenHeat = (int)Math.Floor(OvenHeat * 9.0 / 5.0 + 32);
            }
            else
            {
                OvenHeat = (int)Math.Ceiling((OvenHeat - 32) * 5.0 / 9.0);
            }
            IsCelsius = !IsCelsius;
        }

        public void ScaleRecipe(double scaler)
        {
            foreach (Ingredient i in this.Ingredients)
            {
                i.ScaleIngredient(scaler);
            }
        }


        public override string ToString()
        {

            String ingredientsList = String.Join(",", Ingredients.Select(i => i.ToString()));
            String utensilsList = String.Join(",", Utensils.Select(i => i.ToString()));
            String form = $"Recipe: {this.RecipeTitle} \nOven Heat: {this.OvenHeat}° {this.GetDegree()}" +
                "\nUtensils: {utensilsList} \nInstructions: {this.RecipeInstructions} \nIngredients: {ingredientsList}";

            return form;

        }


        public Recipe Clone()
        {
            return new Recipe(RecipeId, RecipeTitle, Ingredients, Utensils, OvenHeat, RecipeInstructions, IsCelsius);
        }


        //////////////////////////Testing/////////////////////////
        public static Recipe AppleCrisp() {
            Ingredient apple = new Ingredient(0, "Whole Apples", 1.5, Unit.Self);
            Ingredient sugar = new Ingredient(1, "Sugar", 1, Unit.Cup);
            Ingredient cinnamon = new Ingredient(2, "Cinnamon", 2, Unit.Tbs);
            Ingredient salt = new Ingredient(3, "Salt", .5, Unit.tsp);
            List<Ingredient> ingredients = new List<Ingredient>(new Ingredient[] { apple, sugar, cinnamon, salt });

            Utensil whisk = new Utensil(0, "Whisk", "Whisk it");
            Utensil bowl = new Utensil(1, "Bowl", "Stir in it");
            List<Utensil> utensils = new List<Utensil>(new Utensil[] { whisk, bowl });

            Recipe appleCrisp = new Recipe(0, "Apple Crisp", ingredients, utensils, 350, "Whisk it all in a bowl", false);

            return appleCrisp;
        }
    }
}
