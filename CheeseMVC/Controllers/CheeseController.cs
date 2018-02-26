using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //static private Dictionary<string,string> Cheeses = new Dictionary<string, string>();
        private static List<Cheese> cheeses = new List<Cheese>();

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
            cheeses.Add(new Cheese(name, description));

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = cheeses;

            return View();
        }

        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(string cheeseName)
        {
            foreach (Cheese cheese in cheeses.ToArray())
            {
                if (cheese.Name == cheeseName)
                {
                    cheeses.Remove(cheese);
                }
            }

            return Redirect("/Cheese");
        }
    }
}
