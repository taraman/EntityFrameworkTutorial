using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03.Services
{
	public class CatalogService : ICatalogService, IDisposable
	{
		private readonly IUnitOfWork uow;

		public CatalogService(IUnitOfWork dal)
		{
			uow = dal;
		}

		public List<Category> GetCategories()
		{
			return uow.Categories.All().ToList();
		}

		public List<Product> GetProducts()
		{
			return uow.Products.All().ToList();
		}

		public Product CreateProduct(string categoryName, string productName, int price)
		{
			var category = new Category { CategoryName = categoryName };
			var product = new Product { ProductName = productName, UnitPrice = price, Category = category };
			uow.Products.Create(product);
			uow.SaveChanges();
			return product;
		}



		public void Dispose()
		{
			if (uow != null)
				uow.Dispose();
		}
	}
}