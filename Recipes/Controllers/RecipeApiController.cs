using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Recipes.Data;
using Recipes.Models;

namespace Recipes.Controllers
{
    [System.Web.Http.RoutePrefix("api/recipe")]
    public class RecipeApiController : ApiController
    {
        public static Recipe AppleCrisp()
        {
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("applecrisp")]
        public async Task<HttpResponseMessage> GetAppleCrisp()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {             
                var result = await Task.Run(() => {
                    //Get the order details first: 
                    var recipeDetail = AppleCrisp();
                    return recipeDetail;
                });

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(result.ToJson(), System.Text.Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {                
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to get apple crisp recipe");
            }            
            return response;
        }
    }
}
