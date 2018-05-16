using System;
namespace Recipes.Models
{
	public class RecipeViewModel
	{
		private Recipe recipe;
		private double scaler;
		private bool isCelsius;

		public Recipe Recipe {
			get {return this.recipe;}
			private set {this.recipe = value;}
		}

		public double Scaler
        {
			get { return this.scaler; }
			private set { this.scaler = value; }
        }

		public bool IsCelsius
        {
			get { return this.isCelsius; }
			private set { this.isCelsius = value; }
        }

        public RecipeViewModel(Recipe recipe)
        {
			this.recipe = recipe;
			this.scaler = 1;
			this.isCelsius = recipe.IsCelsius;
        }

		public RecipeViewModel(Recipe recipe, double scaler)
        {
            this.recipe = recipe;
            this.scaler = scaler;
            this.isCelsius = recipe.IsCelsius;
        }

		public RecipeViewModel(Recipe recipe, double scaler, bool isCelsius)
        {
            this.recipe = recipe;
            this.scaler = scaler;
			this.isCelsius = isCelsius;
        }
    }
}
