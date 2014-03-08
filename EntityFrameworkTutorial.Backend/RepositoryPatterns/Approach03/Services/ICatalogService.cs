using System.Collections.Generic;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03.Services
{
	public interface ICatalogService
	{
		Product CreateProduct(string categoryName, string productName, int price);

		List<Category> GetCategories();

		List<Product> GetProducts();
	}
}
