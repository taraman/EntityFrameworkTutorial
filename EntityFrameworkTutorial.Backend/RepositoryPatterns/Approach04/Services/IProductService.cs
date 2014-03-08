using System.Collections.Generic;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Services
{
	public interface IProductService
	{
		IEnumerable<Product> GetProducts();
		Product GetProductById(int id);
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int id);
		void SaveProduct();
	}
}
