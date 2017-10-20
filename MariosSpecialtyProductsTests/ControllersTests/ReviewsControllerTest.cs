using MariosSpecialtyProducts.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MariosSpecialtyProducts.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Moq;
using MariosSpecialtyProductsTests.Models;

namespace MariosSpecialtyProductsTests.ControllersTests
{
    [TestClass]
    public class ReviewsControllerTest : IDisposable
    {
		Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
		EFReviewRepository db = new EFReviewRepository(new TestDbContext());
		EFProductRepository db2 = new EFProductRepository(new TestDbContext());

		private void DbSetup()
		{
			mock.Setup(m => m.Reviews).Returns(new Review[]{
				new Review(){ReviewId =1, Author = "Kaili", ContentBody = "We enjoyed this pasta. It cooked quickly and evenly.", Rating = 5,  ProductId = 1 },
				new Review(){ReviewId =2, Author = "Scott", ContentBody = "So delicious and for a reasonable price. Will buy again!", Rating = 5,  ProductId = 1 },
				new Review(){ReviewId =3, Author = "Momo", ContentBody = "It was okay. I would not buy again or recommend to others.", Rating = 2,  ProductId = 1 }
			}.AsQueryable());
		}

		public void Dispose()
		{
			db.DeleteAll();
		}

		[TestMethod]
		public void Mock_GetViewResultIndex_Test()
		{
			DbSetup();
			//Arrange
			ReviewsController controller = new ReviewsController(mock.Object);
			//Act
			var result = controller.Index();
			//Assert
			Assert.IsInstanceOfType(result, typeof(ActionResult));
		}

		[TestMethod]
		public void Mock_IndexListOfReviews_Test()
		{
			DbSetup();
			//Arrange
			ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;
			//Act
			var result = indexView.ViewData.Model;
			//Assert
			Assert.IsInstanceOfType(result, typeof(List<Review>));
		}

		[TestMethod]
		public void Mock_ConfirmEntry_Test()
		{
			DbSetup();
			ReviewsController controller = new ReviewsController(mock.Object);
			Review testReview = new Review();
            testReview.ReviewId = 1;
			testReview.Author = "We enjoyed this pasta. It cooked quickly and evenly.";
            testReview.Rating = 5;
            testReview.ProductId = 1;
		

			ViewResult indexView = controller.Index() as ViewResult;
			var collection = indexView.ViewData.Model as List<Review>;

			CollectionAssert.Contains(collection, testReview);
		}

		[TestMethod]
		public void DB_CreateNewEntry_Test()
		{
			//Arrange
			ReviewsController controller = new ReviewsController(db);
		    ProductsController productsController = new ProductsController(db2);
			Product testProduct = new Product()
			{ ProductId = 1, Name = "Linguine", Cost = "3.00", CountryOfOrigin = "Italy" };
            Review testReview = new Review()
            { Author = "Kaili", ContentBody = "We enjoyed this pasta. It cooked quickly and evenly.", Rating = 5, ProductId = 1 };
            controller.Create(testReview);
			productsController.Create(testProduct);
			var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

			//Assert
			CollectionAssert.Contains(collection, testReview);
		}

    }
}
