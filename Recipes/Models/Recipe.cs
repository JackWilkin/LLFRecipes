using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using Recipes.Data;

namespace Recipes.Models
{
    public class Recipe
    {
        private int recipeId;
        private string recipeTitle;
        private List<Ingredient> ingredients;
        private List<Utensil> utensils;
        private int ovenHeat;
        private bool isCelsius;
        private string recipeInstructions;

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

        ///////////////////////Properties//////////////////////

        public int RecipeId 
        {
            get {return this.recipeId;}
            private set{this.recipeId = value;}
        }

        public string RecipeTitle
        {
            get { return this.recipeTitle; }
            private set { this.recipeTitle = value; }
        }

        public static explicit operator List<object>(Recipe v)
        {
            throw new NotImplementedException();
        }

        public List<Ingredient> Ingredients
        {
            get { return this.ingredients; }
            set { this.ingredients = value; }
        }

        public List<Utensil> Utensils
        {
            get { return this.utensils; }
            set { this.utensils = value; }
        }

        public int OvenHeat
        {
            get { return this.ovenHeat; }
            private set { this.ovenHeat = value; }
        }

        public bool IsCelsius
        {
            get { return this.isCelsius; }
            private set { this.isCelsius = value; }
        }

        public string RecipeInstructions
        {
            get { return this.recipeInstructions; }
            private set { this.recipeInstructions = value; }
        }

        /////////////////Methods////////////////////
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

            String ingredientsList = String.Join(", ", Ingredients.Select(i => i.ToString()));
            String utensilsList = String.Join(", ", Utensils.Select(i => i.ToString()));
            String form = $"Recipe: {this.RecipeTitle} \nOven Heat: {this.OvenHeat}° {this.GetDegree()}" +
                $"\nUtensils: {utensilsList} \nInstructions: {this.RecipeInstructions} \nIngredients: {ingredientsList}";

            return form;

        }


        public Recipe Clone()
        {
            return new Recipe(RecipeId, RecipeTitle, Ingredients, Utensils, OvenHeat, RecipeInstructions, IsCelsius);
        }

        public string ToJson() {
            return new JavaScriptSerializer().Serialize(this);
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

        public static Recipe ChocolateCake()
        {
            Ingredient butter = new Ingredient(0, "Butter", 1.5, Unit.Cup);
            Ingredient sugar = new Ingredient(1, "Sugar", 1, Unit.Cup);
            Ingredient chocolate = new Ingredient(2, "Chocolate", 2, Unit.Tbs);
            Ingredient salt = new Ingredient(3, "Salt", .5, Unit.tsp);
            List<Ingredient> ingredients = new List<Ingredient>(new Ingredient[] { butter, sugar, chocolate, salt });

            Utensil whisk = new Utensil(0, "Whisk", "Whisk it");
            Utensil bowl = new Utensil(1, "Bowl", "Stir in it");
            List<Utensil> utensils = new List<Utensil>(new Utensil[] { whisk, bowl });

            Recipe chocolateCake = new Recipe(0, "Chocolate Cake", ingredients, utensils, 350, "Whisk it all in a bowl", false);

            return chocolateCake;
        }
    }
}
