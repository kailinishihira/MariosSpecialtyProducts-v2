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

        // GET: Reviews
        public ActionResult Index()
        {
            var reviewList = reviewRepo.Reviews.ToList();
            return View();
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int reviewId)
        {
            var thisReview = reviewRepo.Reviews.Include(x => x.Product)
                                       .FirstOrDefault(x => x.ReviewId == reviewId);
            return View(thisReview);
        }

        // GET: Reviews/Create
        public ActionResult Create(int productId)
        {
            ViewBag.ProductId = new SelectList(reviewRepo.Products, "ProductId", "Name");
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {
            try
            {
                reviewRepo.Save(review);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int reviewId)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(thisReview);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review review)
        {
            try
            {
                reviewRepo.Edit(review);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int reviewId)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(thisReview);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int reviewId)
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