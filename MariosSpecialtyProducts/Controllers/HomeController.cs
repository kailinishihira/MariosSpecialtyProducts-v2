using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MariosSpecialtyProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace MariosSpecialtyProducts.Controllers
{
    public class HomeController : Controller
    {
		private readonly MariosSpecialtyProductsContext _db;
		public HomeController(MariosSpecialtyProductsContext db)
		{
			_db = db;
		}


        public IActionResult Index()
        {
            return View(_db.Products.OrderByDescending(x => x.ProductId).Take(3).ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
