using System;
namespace Recipes.Models
{
    public enum Unit
    {
        Tbs, tsp, Cup, Self
    }

    //utils for units: calculations, to string, etc...
    public static class UnitUtils {

        //private final String displayName;
        public static string UnitName(Unit unit)
        {
            switch (unit)
            {
                case Unit.Tbs:
                    return "Tablespoon";
                case Unit.tsp:
                    return "Teaspoon";
                case Unit.Cup:
                    return "Cup";
                default:
                    return "";
            }
        }

    }
}
