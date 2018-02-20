using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private Dictionary<string,string> cheeses = new Dictionary<string, string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            cheeses.Add(name, description);

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = cheeses;

            return View();
        }

        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(string cheese)
        {
            cheeses.Remove(cheese);

            return Redirect("/Cheese");
        }
    }
}
