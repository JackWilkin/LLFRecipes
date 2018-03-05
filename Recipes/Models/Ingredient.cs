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
            get { return Math.Round(1000.0 * this.quantity) / 1000.0; }
            private set { this.quantity = value; }
        }
        public String Unit {
            get { return UnitUtils.UnitName(this.unit); }
        }

        public Ingredient(int ingredientId, String ingredientName, double quantity, Unit unit)
        {
            this.ingredientId = ingredientId;
            this.ingredientName = ingredientName;
            this.quantity = quantity;
            this.unit = unit;
        }


        public override String ToString() => $"{Quantity} {UnitUtils.UnitName(unit)} {ingredientName}";

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
