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

            // GET: Products
            public IActionResult Index()
        {
            var productList = productRepo.Products.ToList();
            return View(productList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int productId)
        {
            var thisProduct = productRepo.Products.Include(x => x.Reviews)
                                         .FirstOrDefault(x => x.ProductId == productId);
            return View(thisProduct);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
			if (ModelState.IsValid)
			{
                productRepo.Save(product);
               
            }
			return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int productId)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == productId);   
            return View(thisProduct);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
			if (ModelState.IsValid)
			{
                productRepo.Edit(product);
            }
			return RedirectToAction("Details", new { productId = product.ProductId });
		}

        // GET: Products/Delete/5
        public IActionResult Delete(int productId)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == productId);
            return View(thisProduct);
        }

        // POST: Products/Delete/5
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
    }
}