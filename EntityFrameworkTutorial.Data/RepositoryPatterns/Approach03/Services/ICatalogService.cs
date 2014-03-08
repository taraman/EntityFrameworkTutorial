using System.Collections.Generic;
using System.Text;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach03.Services
{
	public interface ICatalogService
	{
		Product CreateProduct(string categoryName, string productName, int price);

		List<Category> GetCategories();

		List<Product> GetProducts();
	}
}
