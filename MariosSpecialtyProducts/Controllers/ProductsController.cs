using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MariosSpecialtyProducts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MariosSpecialtyProducts.Controllers
{
    public class ProductsController : Controller
    {
		private MariosSpecialtyProductsContext db = new MariosSpecialtyProductsContext();

		private IProductRepository productRepo;
        public ProductsController(IProductRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.productRepo = new EFProductRepository();

            }
            else
            {
                this.productRepo = thisRepo;
            }
        }

            public IActionResult Index()
        {
            var productList = productRepo.Products.ToList();
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            var thisProduct = productRepo.Products.Include(x => x.Reviews)
                                         .FirstOrDefault(x => x.ProductId == productId);


            return View(thisProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
			if (ModelState.IsValid)
			{
                productRepo.Save(product);
                return RedirectToAction("Index");               
            }
            else 
            {
                return View("Error");    
            }
			
        }

        public IActionResult Edit(int productId)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == productId);   
            return View(thisProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
			if (ModelState.IsValid)
			{
                productRepo.Edit(product);
                return RedirectToAction("Details", new { productId = product.ProductId });
            }
            else 
            {
                return View("Error");
            }
			
		}

        public IActionResult Delete(int productId)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == productId);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmation(int productId)
        {
            try
            {
                var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == productId);
                productRepo.Remove(thisProduct);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }       

		[HttpPost]
		public IActionResult NewReview(string author, string contentBody, int rating, int productId)
		{
    		Review newReview = new Review(author, contentBody, rating, productId);
    		db.Reviews.Add(newReview);
    		db.SaveChanges();
    		return Json(newReview);		
		}

		//[HttpGet]
		//public IActionResult AddReview()
        //{
        //    return View();
        //}
    }
}