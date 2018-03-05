using System;
using System.Web.Script.Serialization;

namespace Recipes.Models
{
    public class Utensil
    {
        private int utensilId;
        private String utensilName;
        private String utensilInstructions;

        public int UtensilId {
            get { return this.utensilId; }
            private set { this.utensilId = value; }
        }

        public String UtensilName {
            get { return this.utensilName; }
            private set { this.utensilName = value; }
        }

        public String UtensilInstructions {
            get { return this.utensilInstructions; }
            private set { this.utensilInstructions = value; }
        }

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

        public string ToJson()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
