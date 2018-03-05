using System;
namespace Recipes.Models
{
    public class Ingredient
    {
        int IngredientId;
        string IngredientName;
        double Quantity;
        Unit Unit;

        public Ingredient(int ingredientId, String ingredientName, double quantity, Unit unit)
        {
            this.IngredientId = ingredientId;
            this.IngredientName = ingredientName;
            this.Quantity = quantity;
            this.Unit = unit;
        }


        public override String ToString() => $"{Math.Round(1000.0 * Quantity) / 1000.0} {Unit} {IngredientName}";

        public void ScaleIngredient(double scaler)
        {
            this.Quantity = this.Quantity * scaler;
        }
    }
}
