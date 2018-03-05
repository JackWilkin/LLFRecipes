using System;
using System.Web.Script.Serialization;

namespace Recipes.Models
{
    public class Ingredient
    {
        private int ingredientId;
        private string ingredientName;
        private double quantity;
        private Unit unit;

        public int IngredientId {
            get { return this.ingredientId; }
            private set { this.ingredientId = value; }
        }
        public string IngredientName {
            get { return this.ingredientName; }
            private set { this.ingredientName = value; }
        }
        public double Quantity {
            get { return this.quantity; }
            private set { this.quantity = value; }
        }
        public Unit Unit {
            get { return this.unit; }
            private set { this.unit = value; }
        }

        public Ingredient(int ingredientId, String ingredientName, double quantity, Unit unit)
        {
            this.IngredientId = ingredientId;
            this.IngredientName = ingredientName;
            this.Quantity = quantity;
            this.Unit = unit;
        }


        public override String ToString() => $"{Math.Round(1000.0 * quantity) / 1000.0} {UnitUtils.UnitName(unit)} {ingredientName}";

        public void ScaleIngredient(double scaler)
        {
            this.quantity = this.quantity * scaler;
        }

        public string ToJson()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
