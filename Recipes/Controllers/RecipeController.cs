using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class RecipeController : Controller
    {
        //private RecipeContext db = new RecipeContext();

        
        // GET: Recipe
        public ActionResult Index()
        {
            return View();//db.Recipes.ToList());
        }
        

        // GET: /Recipe/Home
        public ActionResult Home()
        {
            return View();
        }

        // GET: /Recipe/Display/
        public ActionResult Display()
        {
            return View(Recipe.AppleCrisp());
        }
    }
}
