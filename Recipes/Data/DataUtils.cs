using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recipes.Data
{
    public static class DataUtils
    {
        public static List<T> JsonToList<T>(string jsonList)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonList);
        }

        public static T JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string DB_ROOT_ADDRESS = "https://llfrecipes-6c4b.restdb.io/rest/";
    }
}
