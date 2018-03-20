using System;
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

        public Recipe GetRecipe()
        {
            return Recipe.AppleCrisp();
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
                    var recipeDetail = Recipe.AppleCrisp();
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
