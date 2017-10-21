using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MariosSpecialtyProducts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;

namespace MariosSpecialtyProducts.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;
        public ReviewsController(IReviewRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.reviewRepo = new EFReviewRepository();

            }
            else
            {
                this.reviewRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var reviewList = reviewRepo.Reviews.ToList();
            ViewBag.ProductId = new SelectList(reviewRepo.Products, "ProductId", "Name");
            return View(reviewList);
        }

        public IActionResult Details(int reviewId)
        {
            var thisReview = reviewRepo.Reviews.Include(x => x.Product)
                                       .FirstOrDefault(x => x.ReviewId == reviewId);
            return View(thisReview);
        }

        public IActionResult Create(int productId)
        {
            ViewBag.ProductId = new SelectList(reviewRepo.Products, "ProductId", "Name");  
            return View();
        }	

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                reviewRepo.Save(review);
            }

            return RedirectToAction("Index");
        }

		
		public IActionResult AddReview(int productId)
		{
			ViewBag.ProductId = reviewRepo.Products.FirstOrDefault(x => x.ProductId == productId);
			return View();
		}

		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddReview(Review review)
		{
			if (ModelState.IsValid)
			{
				reviewRepo.Save(review);
			}

			return RedirectToAction("Details", "Products", new { productId = review.ProductId });
		}

		public IActionResult Edit(int reviewId)
        {
            var thisReview = reviewRepo.Reviews.Include(x => x.Product)
                                       .FirstOrDefault(x => x.ReviewId == reviewId);
			return View(thisReview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Review review)
        {
			if (ModelState.IsValid)
			{
                reviewRepo.Edit(review);
            }

            return RedirectToAction("Details", "Products", new { productId = review.ProductId});
		}

        public IActionResult Delete(int reviewId)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(thisReview);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmation(int reviewId)
        {
            Contract.Ensures(Contract.Result<ActionResult>() != null);
            try
            {
                var thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
                reviewRepo.Remove(thisReview);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}