using System;
using System.Web.Mvc;


namespace Recipes.Controllers
{
    public class RecipeController : Controller
    {
        // GET: /Recipe/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Recipe/Display/
        public ActionResult Display(){
            return View();
        }
    }
}
