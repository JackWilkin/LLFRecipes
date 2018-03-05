using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Recipes.Controllers
{
    public class RecipeController : Controller
    {
        // GET: /Recipe/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Recipe/Test/
        public String Test(){
            return "Test";
        }
    }
}
