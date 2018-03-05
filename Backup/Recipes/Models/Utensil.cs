using System;
namespace Recipes.Models
{
    public class Utensil
    {
        int UtensilId;
        String UtensilName;
        String UtensilInstructions;

        public Utensil(int utensilId, String utensilName, String utensilInstructions)
        {
            this.UtensilId = utensilId;
            this.UtensilName = utensilName;
            this.UtensilInstructions = utensilInstructions;
        }

    
        public override string ToString()
        {
            return UtensilName;
        }
    }
}
