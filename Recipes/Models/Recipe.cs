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

        public int Fahrenheit {
            get {
                if (this.IsCelsius) {
                    return (int)Math.Floor(OvenHeat * 9.0 / 5.0 + 32);
                }
                else {
                    return OvenHeat;
                }
            }
        }

        public int Celsius
        {
            get
            {
                if (this.IsCelsius)
                {
                    return OvenHeat;
                }
                else
                {
                    return (int)Math.Round((OvenHeat - 32) * 5.0 / 9.0);
                }
            }
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

      
    }
}
