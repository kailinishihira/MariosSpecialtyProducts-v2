using MariosSpecialtyProducts.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MariosSpecialtyProducts.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Moq;
using MariosSpecialtyProductsTests.Models;

namespace MariosSpecialtyProductsTests
{
    [TestClass]
    public class ProductsControllerTest : IDisposable
    {
		Mock<IProductRepository> mock = new Mock<IProductRepository>();
		EFProductRepository db = new EFProductRepository(new TestDbContext());

		private void DbSetup()
		{
			mock.Setup(m => m.Products).Returns(new Product[]{
				new Product(){ProductId = 1, Name = "Linguine", Cost = "3.00", CountryOfOrigin = "Italy"},
				new Product(){ProductId = 2, Name = "Pasta Sauce", Cost = "5.00", CountryOfOrigin = "USA"},
				new Product(){ProductId = 3, Name = "EVOO", Cost = "10.00", CountryOfOrigin = "Italy"}
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
			ProductsController controller = new ProductsController(mock.Object);
			//Act
			var result = controller.Index();
			//Assert
			Assert.IsInstanceOfType(result, typeof(ActionResult));
		}

		[TestMethod]
		public void Mock_IndexListOfProducts_Test()
		{
			DbSetup();
			//Arrange
			ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;
			//Act
			var result = indexView.ViewData.Model;
			//Assert
			Assert.IsInstanceOfType(result, typeof(List<Product>));
		}

		[TestMethod]
		public void Mock_ConfirmEntry_Test()
		{
			DbSetup();
			ProductsController controller = new ProductsController(mock.Object);
			Product testProduct = new Product();
            testProduct.ProductId = 1;
			testProduct.Name = "Linguine";
			testProduct.Cost = "3.00";
            testProduct.CountryOfOrigin = "Italy";
			
			ViewResult indexView = controller.Index() as ViewResult;
			var collection = indexView.ViewData.Model as List<Product>;
			CollectionAssert.Contains(collection, testProduct);
		}

		[TestMethod]
		public void DB_CreateNewEntry_Test()
		{
			//Arrange
			ProductsController controller = new ProductsController(db);
			Product testProduct = new Product()
			{ ProductId = 1, Name = "Linguine", Cost = "3.00", CountryOfOrigin = "Italy" };
	
			//Act
			controller.Create(testProduct);
			var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

			//Assert
			CollectionAssert.Contains(collection, testProduct);
		}

	}
}
