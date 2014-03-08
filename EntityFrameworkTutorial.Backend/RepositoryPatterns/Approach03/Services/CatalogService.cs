using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03.Services
{
	public class CatalogService : ICatalogService, IDisposable
	{
		private IUnitOfWork context;

		public CatalogService(IUnitOfWork dal)
		{
			context = dal;
		}

		public List<Category> GetCategories()
		{
			return context.Categories.All().ToList();
		}

		public List<Product> GetProducts()
		{
			return context.Products.All().ToList();
		}

		public Product CreateProduct(string categoryName, string productName, int price)
		{
			var category = new Category() { CategoryName = categoryName };
			var product = new Product() { ProductName = productName, UnitPrice = price, Category = category };
			context.Products.Create(product);
			context.SaveChanges();
			return product;
		}



		public void Dispose()
		{
			if (context != null)
				context.Dispose();
		}
	}
}